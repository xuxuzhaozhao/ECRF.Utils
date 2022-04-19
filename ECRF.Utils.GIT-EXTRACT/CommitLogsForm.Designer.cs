
namespace ECRF.Utils.GIT_EXTRACT
{
    partial class CommitLogsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommitLogsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chosedSHA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnChooseCommits = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChangeRecordNum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommitRecord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chosedSHA});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(674, 490);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // chosedSHA
            // 
            this.chosedSHA.HeaderText = "选择";
            this.chosedSHA.Name = "chosedSHA";
            // 
            // btnChooseCommits
            // 
            this.btnChooseCommits.Location = new System.Drawing.Point(535, 0);
            this.btnChooseCommits.Name = "btnChooseCommits";
            this.btnChooseCommits.Size = new System.Drawing.Size(143, 37);
            this.btnChooseCommits.TabIndex = 4;
            this.btnChooseCommits.Text = "确定选择";
            this.btnChooseCommits.UseVisualStyleBackColor = true;
            this.btnChooseCommits.Click += new System.EventHandler(this.btnChooseCommits_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 495);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnChooseCommits);
            this.panel2.Location = new System.Drawing.Point(13, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 40);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnChangeRecordNum);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtCommitRecord);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 35);
            this.panel3.TabIndex = 9;
            // 
            // btnChangeRecordNum
            // 
            this.btnChangeRecordNum.Location = new System.Drawing.Point(135, 6);
            this.btnChangeRecordNum.Name = "btnChangeRecordNum";
            this.btnChangeRecordNum.Size = new System.Drawing.Size(25, 23);
            this.btnChangeRecordNum.TabIndex = 8;
            this.btnChangeRecordNum.Text = "√";
            this.btnChangeRecordNum.UseVisualStyleBackColor = true;
            this.btnChangeRecordNum.Click += new System.EventHandler(this.btnChangeRecordNum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "展示前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "条记录";
            // 
            // txtCommitRecord
            // 
            this.txtCommitRecord.Location = new System.Drawing.Point(49, 6);
            this.txtCommitRecord.Name = "txtCommitRecord";
            this.txtCommitRecord.Size = new System.Drawing.Size(33, 23);
            this.txtCommitRecord.TabIndex = 6;
            this.txtCommitRecord.Text = "25";
            // 
            // CommitLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommitLogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交记录";
            this.Load += new System.EventHandler(this.CommitLogsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnChooseCommits;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chosedSHA;
        private System.Windows.Forms.Button btnChangeRecordNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCommitRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}