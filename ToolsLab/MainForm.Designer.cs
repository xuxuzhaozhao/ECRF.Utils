
namespace ToolsLab
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtUserTaskID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObjectID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSendUserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdo7403 = new System.Windows.Forms.RadioButton();
            this.rdo7402 = new System.Windows.Forms.RadioButton();
            this.rdo7400 = new System.Windows.Forms.RadioButton();
            this.rdo7401 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxMsgText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMsgSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Controls.Add(this.txtUserTaskID);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtObjectID);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtSendUserID);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.rdo7403);
            this.tabPage1.Controls.Add(this.rdo7402);
            this.tabPage1.Controls.Add(this.rdo7400);
            this.tabPage1.Controls.Add(this.rdo7401);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.rtxMsgText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMsgSubject);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(774, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "伦理消息发送";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(544, 480);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 30);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(652, 480);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUserTaskID
            // 
            this.txtUserTaskID.Location = new System.Drawing.Point(352, 154);
            this.txtUserTaskID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTaskID.Name = "txtUserTaskID";
            this.txtUserTaskID.Size = new System.Drawing.Size(402, 26);
            this.txtUserTaskID.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "本次申请流程伦理秘书审核后的UserTaskID：";
            // 
            // txtObjectID
            // 
            this.txtObjectID.Location = new System.Drawing.Point(190, 18);
            this.txtObjectID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObjectID.Name = "txtObjectID";
            this.txtObjectID.Size = new System.Drawing.Size(562, 26);
            this.txtObjectID.TabIndex = 12;
            this.txtObjectID.TextChanged += new System.EventHandler(this.txtObjectID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "IRBRequestAnswerID：";
            // 
            // txtSendUserID
            // 
            this.txtSendUserID.Location = new System.Drawing.Point(160, 107);
            this.txtSendUserID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSendUserID.Name = "txtSendUserID";
            this.txtSendUserID.Size = new System.Drawing.Size(594, 26);
            this.txtSendUserID.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "伦理秘书UserID：";
            // 
            // rdo7403
            // 
            this.rdo7403.AutoSize = true;
            this.rdo7403.Location = new System.Drawing.Point(676, 65);
            this.rdo7403.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo7403.Name = "rdo7403";
            this.rdo7403.Size = new System.Drawing.Size(74, 20);
            this.rdo7403.TabIndex = 8;
            this.rdo7403.TabStop = true;
            this.rdo7403.Text = "不同意";
            this.rdo7403.UseVisualStyleBackColor = true;
            this.rdo7403.CheckedChanged += new System.EventHandler(this.rdoAuditType_CheckedChanged);
            // 
            // rdo7402
            // 
            this.rdo7402.AutoSize = true;
            this.rdo7402.Location = new System.Drawing.Point(326, 65);
            this.rdo7402.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo7402.Name = "rdo7402";
            this.rdo7402.Size = new System.Drawing.Size(90, 20);
            this.rdo7402.TabIndex = 7;
            this.rdo7402.TabStop = true;
            this.rdo7402.Text = "快速审查";
            this.rdo7402.UseVisualStyleBackColor = true;
            this.rdo7402.CheckedChanged += new System.EventHandler(this.rdoAuditType_CheckedChanged);
            // 
            // rdo7400
            // 
            this.rdo7400.AutoSize = true;
            this.rdo7400.Location = new System.Drawing.Point(510, 65);
            this.rdo7400.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo7400.Name = "rdo7400";
            this.rdo7400.Size = new System.Drawing.Size(58, 20);
            this.rdo7400.TabIndex = 6;
            this.rdo7400.TabStop = true;
            this.rdo7400.Text = "备案";
            this.rdo7400.UseVisualStyleBackColor = true;
            this.rdo7400.CheckedChanged += new System.EventHandler(this.rdoAuditType_CheckedChanged);
            // 
            // rdo7401
            // 
            this.rdo7401.AutoSize = true;
            this.rdo7401.Location = new System.Drawing.Point(160, 65);
            this.rdo7401.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo7401.Name = "rdo7401";
            this.rdo7401.Size = new System.Drawing.Size(90, 20);
            this.rdo7401.TabIndex = 5;
            this.rdo7401.TabStop = true;
            this.rdo7401.Text = "会议审查";
            this.rdo7401.UseVisualStyleBackColor = true;
            this.rdo7401.CheckedChanged += new System.EventHandler(this.rdoAuditType_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "审查类型：";
            // 
            // rtxMsgText
            // 
            this.rtxMsgText.Location = new System.Drawing.Point(102, 254);
            this.rtxMsgText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxMsgText.Name = "rtxMsgText";
            this.rtxMsgText.Size = new System.Drawing.Size(648, 212);
            this.rtxMsgText.TabIndex = 3;
            this.rtxMsgText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "消息内容：";
            // 
            // txtMsgSubject
            // 
            this.txtMsgSubject.Location = new System.Drawing.Point(106, 203);
            this.txtMsgSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMsgSubject.Name = "txtMsgSubject";
            this.txtMsgSubject.Size = new System.Drawing.Size(648, 26);
            this.txtMsgSubject.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息主题：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 587);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伊柯夫-复旦肿瘤运维工具库";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton rdo7402;
        private System.Windows.Forms.RadioButton rdo7400;
        private System.Windows.Forms.RadioButton rdo7401;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxMsgText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMsgSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo7403;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtUserTaskID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObjectID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSendUserID;
        private System.Windows.Forms.Label label4;
    }
}

