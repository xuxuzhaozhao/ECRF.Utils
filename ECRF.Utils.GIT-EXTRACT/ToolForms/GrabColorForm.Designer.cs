
namespace ECRF.Utils.GIT_EXTRACT.ToolForms
{
    partial class GrabColorForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtHex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.TextBox();
            this.lu = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 76);
            this.button1.TabIndex = 1;
            this.button1.Text = "拾色";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 76);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.txtHex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtG);
            this.groupBox1.Controls.Add(this.lu);
            this.groupBox1.Controls.Add(this.txtR);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Location = new System.Drawing.Point(15, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "颜色值";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(247, 61);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(69, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtHex
            // 
            this.txtHex.Location = new System.Drawing.Point(83, 61);
            this.txtHex.Name = "txtHex";
            this.txtHex.Size = new System.Drawing.Size(157, 23);
            this.txtHex.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "16进制表示：";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(273, 25);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(36, 23);
            this.txtB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "蓝（B）:";
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(170, 25);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(36, 23);
            this.txtG.TabIndex = 3;
            // 
            // lu
            // 
            this.lu.AutoSize = true;
            this.lu.Location = new System.Drawing.Point(109, 28);
            this.lu.Name = "lu";
            this.lu.Size = new System.Drawing.Size(56, 17);
            this.lu.TabIndex = 2;
            this.lu.Text = "绿（G）:";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(67, 25);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(36, 23);
            this.txtR.TabIndex = 1;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(6, 28);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(55, 17);
            this.lblR.TabIndex = 0;
            this.lblR.Text = "红（R）:";
            // 
            // GrabColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrabColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拾色器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtHex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.Label lu;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.Label lblR;
    }
}