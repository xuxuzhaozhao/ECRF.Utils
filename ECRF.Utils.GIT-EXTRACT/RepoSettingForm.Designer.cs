
namespace ECRF.Utils.GIT_EXTRACT
{
    partial class RepoSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepoSettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepoPosition = new System.Windows.Forms.TextBox();
            this.btnSetRepoPosition = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnAsp = new System.Windows.Forms.RadioButton();
            this.rbtnWebSite = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rbtnWEB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库位置(包含 .gitignore文件)：";
            // 
            // txtRepoPosition
            // 
            this.txtRepoPosition.Location = new System.Drawing.Point(193, 16);
            this.txtRepoPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtRepoPosition.Name = "txtRepoPosition";
            this.txtRepoPosition.Size = new System.Drawing.Size(172, 23);
            this.txtRepoPosition.TabIndex = 1;
            // 
            // btnSetRepoPosition
            // 
            this.btnSetRepoPosition.Location = new System.Drawing.Point(372, 15);
            this.btnSetRepoPosition.Name = "btnSetRepoPosition";
            this.btnSetRepoPosition.Size = new System.Drawing.Size(102, 25);
            this.btnSetRepoPosition.TabIndex = 2;
            this.btnSetRepoPosition.Text = "设置仓库位置";
            this.btnSetRepoPosition.UseVisualStyleBackColor = true;
            this.btnSetRepoPosition.Click += new System.EventHandler(this.btnSetRepoPosition_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asp文件夹名称：";
            // 
            // rbtnAsp
            // 
            this.rbtnAsp.AutoSize = true;
            this.rbtnAsp.Location = new System.Drawing.Point(192, 46);
            this.rbtnAsp.Name = "rbtnAsp";
            this.rbtnAsp.Size = new System.Drawing.Size(48, 21);
            this.rbtnAsp.TabIndex = 4;
            this.rbtnAsp.TabStop = true;
            this.rbtnAsp.Text = "Asp";
            this.rbtnAsp.UseVisualStyleBackColor = true;
            // 
            // rbtnWebSite
            // 
            this.rbtnWebSite.AutoSize = true;
            this.rbtnWebSite.Location = new System.Drawing.Point(399, 46);
            this.rbtnWebSite.Name = "rbtnWebSite";
            this.rbtnWebSite.Size = new System.Drawing.Size(74, 21);
            this.rbtnWebSite.TabIndex = 5;
            this.rbtnWebSite.TabStop = true;
            this.rbtnWebSite.Text = "WebSite";
            this.rbtnWebSite.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(21, 78);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(452, 25);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rbtnWEB
            // 
            this.rbtnWEB.AutoSize = true;
            this.rbtnWEB.Location = new System.Drawing.Point(297, 46);
            this.rbtnWEB.Name = "rbtnWEB";
            this.rbtnWEB.Size = new System.Drawing.Size(53, 21);
            this.rbtnWEB.TabIndex = 8;
            this.rbtnWEB.TabStop = true;
            this.rbtnWEB.Text = "WEB";
            this.rbtnWEB.UseVisualStyleBackColor = true;
            // 
            // RepoSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 113);
            this.Controls.Add(this.rbtnWEB);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnWebSite);
            this.Controls.Add(this.rbtnAsp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSetRepoPosition);
            this.Controls.Add(this.txtRepoPosition);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepoSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库设置";
            this.Load += new System.EventHandler(this.RepoSettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepoPosition;
        private System.Windows.Forms.Button btnSetRepoPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnAsp;
        private System.Windows.Forms.RadioButton rbtnWebSite;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RadioButton rbtnWEB;
    }
}