using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ToolsLab
{
    public partial class MainForm : Form
    {
        static string conn_str = ConfigurationManager.AppSettings["conn_str"];
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!check() || !confirm("是否将本条消息发送给【应用管理员】以便验证？")) return;

            using (var db = new SqlConnection(conn_str))
            {
                var sql = @"DECLARE @msgid INT;	
                                INSERT  INTO dbo.Messages ( subject , msgText , Priority , ThreadID , CreatedDate , SentBy , MsgTemplateID )
                                 VALUES  ( @subject ,@msgText , 1 , 
                                                (SELECT WorkflowInstanceID FROM dbo.UserTasks WHERE UserTaskID = @UserTaskID) , 
                                                (SELECT ModifiedDate FROM dbo.UserTasks WHERE UserTaskID = @UserTaskID) ,
                                                @SentBy  , @MsgTemplateID);
                                SELECT  @msgid = SCOPE_IDENTITY();		
                                INSERT  INTO dbo.MessageRecipients ( msgID , RecipientID , DeliverType , Status )					
                                VALUES  ( @msgid , '100255' , 1 , 'NEW' );";
                db.Execute(sql, new
                {
                    subject = txtMsgSubject.Text,
                    msgText = rtxMsgText.Text,
                    SentBy = txtSendUserID.Text,
                    MsgTemplateID = getMsgTemplateID(),
                    UserTaskID = txtUserTaskID.Text
                });
            }
            MessageBox.Show("已发送。");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!check() || !confirm("确定发送？")) return;

            using (var db = new SqlConnection(conn_str))
            {
                var sql = @"DECLARE @msgid INT;	
                                INSERT  INTO dbo.Messages ( subject , msgText , Priority , ThreadID , CreatedDate , SentBy , MsgTemplateID )
                                 VALUES  ( @subject ,@msgText , 1 , 
                                                (SELECT WorkflowInstanceID FROM dbo.UserTasks WHERE UserTaskID = @UserTaskID) , 
                                                (SELECT ModifiedDate FROM dbo.UserTasks WHERE UserTaskID = @UserTaskID) ,
                                                @SentBy  , @MsgTemplateID);
                                SELECT  @msgid = SCOPE_IDENTITY();																				
                                DECLARE @userid INT; 																						
                                DECLARE cursor_name CURSOR FORWARD_ONLY STATIC READ_ONLY													
                                FOR																										
                                    SELECT DISTINCT UserID																					
                                    FROM    dbo.UserTasks																					
                                    WHERE   WorkflowInstanceID = ( SELECT   WorkflowInstanceID												
                                                                   FROM     dbo.WorkflowInstances											
                                                                   WHERE    ObjectID = @ObjectID AND ObjectType = 'IRBApplicationAnswer' )
				                                AND UserTaskID <> @UserTaskID AND DeletedDate IS NULL;															
                                OPEN cursor_name;																							
                                FETCH NEXT FROM cursor_name 																				
                                INTO @userid;																								
                                WHILE @@fetch_status = 0																					
                                    BEGIN																									
                                        INSERT  INTO dbo.MessageRecipients ( msgID , RecipientID , DeliverType , Status )					
                                        VALUES  ( @msgid , @userid , 1 , 'NEW' );															
                                        FETCH NEXT FROM cursor_name 																		
                                    INTO @userid;																							
                                    END;																									
                                CLOSE cursor_name;																							
                                DEALLOCATE cursor_name;	";
                db.Execute(sql, new
                {
                    ObjectID = txtObjectID.Text,
                    subject = txtMsgSubject.Text,
                    msgText = rtxMsgText.Text,
                    SentBy = txtSendUserID.Text,
                    MsgTemplateID = getMsgTemplateID(),
                    UserTaskID = txtUserTaskID.Text
                });
            }
            MessageBox.Show("已发送。");
        }

        private bool check()
        {
            if (!string.IsNullOrWhiteSpace(txtObjectID.Text) &&
                     !string.IsNullOrWhiteSpace(txtSendUserID.Text) &&
                     !string.IsNullOrWhiteSpace(txtMsgSubject.Text) &&
                     !string.IsNullOrWhiteSpace(txtUserTaskID.Text) &&
                     !string.IsNullOrWhiteSpace(txtSendUserID.Text))
            {
                using (var db = new SqlConnection(conn_str))
                {
                    var sql = @"SELECT Status FROM dbo.WorkflowInstances WHERE ObjectID = @ObjectID AND ObjectType = 'IRBApplicationAnswer'";
                    string result = db.QueryFirstOrDefault<string>(sql, new { @ObjectID = txtObjectID.Text });
                    if (result != "COMPLETED")
                    {
                        MessageBox.Show("此流程还未完成不可发送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("请填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void txtObjectID_TextChanged(object sender, EventArgs e)
        {
            InitFormData();
        }
        private void rdoAuditType_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtObjectID.Text)) return;
            dynamic result = getInitInformation();
            InitMsgTemplate(result);
        }

        private void InitFormData()
        {
            if (string.IsNullOrWhiteSpace(txtObjectID.Text)) return;
            dynamic result = getInitInformation();
            if (result == null) return;

            if (result.ReviewType == "1") rdo7401.Checked = true;
            else if (result.ReviewType == "2") rdo7402.Checked = true;
            else rdo7400.Checked = true;

            txtSendUserID.Text = result.UserID.ToString();
            txtUserTaskID.Text = result.UserTaskID.ToString();

            InitMsgTemplate(result);
        }

        private int getMsgTemplateID()
        {
            if (rdo7400.Checked) return 7400;
            if (rdo7401.Checked) return 7401;
            if (rdo7402.Checked) return 7402;
            if (rdo7403.Checked) return 7403;
            return 0;
        }

        private dynamic getInitInformation()
        {
            using (var db = new SqlConnection(conn_str))
            {
                var sql = @"DECLARE @WorkflowInstanceID NVARCHAR(50)
                                DECLARE @CurrentStep NVARCHAR(50)
                                DECLARE @UserTaskID NVARCHAR(50)
                                DECLARE @ApplyDate DATETIME
                                DECLARE @ObjectType NVARCHAR(50)
                                DECLARE @ProposedProjectID NVARCHAR(50)
                                DECLARE @ReviewType NVARCHAR(10)

                                SELECT  @WorkflowInstanceID = WorkflowInstanceID ,
                                        @CurrentStep = CurrentStep ,
                                        @ApplyDate = CreatedDate
                                FROM    dbo.WorkflowInstances
                                WHERE   ObjectType = 'IRBApplicationAnswer'
                                        AND ObjectID =@ObjectID;

                                SELECT  @ObjectType = ObjectType ,
                                        @ProposedProjectID = ProposedProjectID,
		                                @ReviewType = ReviewType
                                FROM    dbo.IRBRequestAnswers
                                WHERE   IRBRequestAnswerID = @ObjectID

                                SELECT  UserID , UserTaskID , ModifiedDate AS DATE , @ApplyDate AS APPLYDATE ,@ReviewType AS ReviewType,
                                        ( SELECT    Name
                                          FROM      dbo.StatusCodes
                                          WHERE     Category = 'IRBRequestAnswers_ObjectType'
                                                    AND Code = @ObjectType
                                        ) AS OBJECTTYPE ,
                                        ( SELECT    ShortName
                                          FROM      dbo.ProposedProjects
                                          WHERE     ProposedProjectID = @ProposedProjectID
                                        ) AS PROJECTSHORTNAME
                                FROM    dbo.UserTasks
                                WHERE   WorkflowInstanceID = @WorkflowInstanceID
                                        AND Status = 'COMPLETED'
                                        AND StepIndex = @CurrentStep
                                        AND DeletedDate IS NULL ";
                return db.QueryFirstOrDefault<dynamic>(sql, new { ObjectID = txtObjectID.Text });
            }
        }

        private void InitMsgTemplate(dynamic result)
        {
            using (var db = new SqlConnection(conn_str))
            {
                var sql = @"SELECT Subject,Detail FROM dbo.MessageTemplates WHERE MsgTemplateID =@MsgTemplateID";
                dynamic temp = db.QueryFirstOrDefault<dynamic>(sql, new { MsgTemplateID = getMsgTemplateID() });
                string Subject = temp.Subject;
                string Detail = temp.Detail;

                txtMsgSubject.Text = Subject.Replace("{%PROJECTSHORTNAME%}", result.PROJECTSHORTNAME)
                    .Replace("{%OBJECTTYPE%}", result.OBJECTTYPE);
                rtxMsgText.Text = Detail.Replace("{%PROJECTSHORTNAME%}", result.PROJECTSHORTNAME)
                    .Replace("{%OBJECTTYPE%}", result.OBJECTTYPE)
                    .Replace("{%APPLYDATE%}", result.APPLYDATE.ToString())
                    .Replace("{%DATE%}", result.DATE.ToString());
            }
        }

        private bool confirm(string msg)
        {
            return MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
