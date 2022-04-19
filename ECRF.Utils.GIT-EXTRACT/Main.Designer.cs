
namespace ECRF.Utils.GIT_EXTRACT
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我习惯自己输入CommitIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大小写转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件处理FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拾色器SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowCommitRecord = new System.Windows.Forms.Button();
            this.btnChooseCommit = new System.Windows.Forms.Button();
            this.txtChooseCommit = new System.Windows.Forms.TextBox();
            this.dataCommitFiles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseSavePath = new System.Windows.Forms.Button();
            this.cboBuildTemplate = new System.Windows.Forms.CheckBox();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExtract = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCommitFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置TToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1001, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置TToolStripMenuItem
            // 
            this.设置TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义CToolStripMenuItem,
            this.我习惯自己输入CommitIDToolStripMenuItem});
            this.设置TToolStripMenuItem.Name = "设置TToolStripMenuItem";
            this.设置TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置TToolStripMenuItem.Text = "设置(&S)";
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.自定义CToolStripMenuItem.Text = "仓库位置(&C)";
            this.自定义CToolStripMenuItem.Click += new System.EventHandler(this.自定义CToolStripMenuItem_Click);
            // 
            // 我习惯自己输入CommitIDToolStripMenuItem
            // 
            this.我习惯自己输入CommitIDToolStripMenuItem.Name = "我习惯自己输入CommitIDToolStripMenuItem";
            this.我习惯自己输入CommitIDToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.我习惯自己输入CommitIDToolStripMenuItem.Text = "切换输入模式(&W)";
            this.我习惯自己输入CommitIDToolStripMenuItem.Click += new System.EventHandler(this.我习惯自己输入CommitIDToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大小写转换ToolStripMenuItem,
            this.文件处理FToolStripMenuItem,
            this.拾色器SToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // 大小写转换ToolStripMenuItem
            // 
            this.大小写转换ToolStripMenuItem.Name = "大小写转换ToolStripMenuItem";
            this.大小写转换ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.大小写转换ToolStripMenuItem.Text = "大小写转换(&L)";
            this.大小写转换ToolStripMenuItem.Click += new System.EventHandler(this.大小写转换ToolStripMenuItem_Click);
            // 
            // 文件处理FToolStripMenuItem
            // 
            this.文件处理FToolStripMenuItem.Name = "文件处理FToolStripMenuItem";
            this.文件处理FToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.文件处理FToolStripMenuItem.Text = "文件处理(&F)";
            this.文件处理FToolStripMenuItem.Click += new System.EventHandler(this.文件处理FToolStripMenuItem_Click);
            // 
            // 拾色器SToolStripMenuItem
            // 
            this.拾色器SToolStripMenuItem.Name = "拾色器SToolStripMenuItem";
            this.拾色器SToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.拾色器SToolStripMenuItem.Text = "拾色器(&S)";
            this.拾色器SToolStripMenuItem.Click += new System.EventHandler(this.拾色器SToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowCommitRecord);
            this.panel1.Controls.Add(this.btnChooseCommit);
            this.panel1.Controls.Add(this.txtChooseCommit);
            this.panel1.Location = new System.Drawing.Point(13, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 40);
            this.panel1.TabIndex = 1;
            // 
            // btnShowCommitRecord
            // 
            this.btnShowCommitRecord.Location = new System.Drawing.Point(829, 2);
            this.btnShowCommitRecord.Name = "btnShowCommitRecord";
            this.btnShowCommitRecord.Size = new System.Drawing.Size(143, 32);
            this.btnShowCommitRecord.TabIndex = 2;
            this.btnShowCommitRecord.Text = "确定";
            this.btnShowCommitRecord.UseVisualStyleBackColor = true;
            this.btnShowCommitRecord.Click += new System.EventHandler(this.btnShowCommitRecord_Click);
            // 
            // btnChooseCommit
            // 
            this.btnChooseCommit.Location = new System.Drawing.Point(829, 2);
            this.btnChooseCommit.Name = "btnChooseCommit";
            this.btnChooseCommit.Size = new System.Drawing.Size(144, 32);
            this.btnChooseCommit.TabIndex = 1;
            this.btnChooseCommit.Text = "选择Commit记录";
            this.btnChooseCommit.UseVisualStyleBackColor = true;
            this.btnChooseCommit.Click += new System.EventHandler(this.btnChooseCommit_Click);
            // 
            // txtChooseCommit
            // 
            this.txtChooseCommit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChooseCommit.Location = new System.Drawing.Point(4, 4);
            this.txtChooseCommit.Multiline = true;
            this.txtChooseCommit.Name = "txtChooseCommit";
            this.txtChooseCommit.Size = new System.Drawing.Size(822, 29);
            this.txtChooseCommit.TabIndex = 0;
            // 
            // dataCommitFiles
            // 
            this.dataCommitFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCommitFiles.Location = new System.Drawing.Point(13, 71);
            this.dataCommitFiles.Name = "dataCommitFiles";
            this.dataCommitFiles.RowTemplate.Height = 23;
            this.dataCommitFiles.Size = new System.Drawing.Size(976, 559);
            this.dataCommitFiles.TabIndex = 2;
            this.dataCommitFiles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataCommitFiles_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 654);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "默认加载最新一次提交。";
            // 
            // chooseSavePath
            // 
            this.chooseSavePath.Location = new System.Drawing.Point(176, 11);
            this.chooseSavePath.Name = "chooseSavePath";
            this.chooseSavePath.Size = new System.Drawing.Size(292, 37);
            this.chooseSavePath.TabIndex = 5;
            this.chooseSavePath.Text = "选择文件夹 && 提取";
            this.chooseSavePath.UseVisualStyleBackColor = true;
            this.chooseSavePath.Click += new System.EventHandler(this.chooseSavePath_Click);
            // 
            // cboBuildTemplate
            // 
            this.cboBuildTemplate.AutoSize = true;
            this.cboBuildTemplate.Location = new System.Drawing.Point(1, 20);
            this.cboBuildTemplate.Name = "cboBuildTemplate";
            this.cboBuildTemplate.Size = new System.Drawing.Size(75, 21);
            this.cboBuildTemplate.TabIndex = 6;
            this.cboBuildTemplate.Text = "帮我建包";
            this.cboBuildTemplate.UseVisualStyleBackColor = true;
            this.cboBuildTemplate.CheckedChanged += new System.EventHandler(this.cboBuildTemplate_CheckedChanged);
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(2, 21);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(86, 23);
            this.txtPackageName.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPackageName);
            this.groupBox1.Location = new System.Drawing.Point(80, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 44);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入包名";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.chooseSavePath);
            this.panel2.Controls.Add(this.cboBuildTemplate);
            this.panel2.Location = new System.Drawing.Point(520, 633);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 53);
            this.panel2.TabIndex = 10;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(846, 638);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(143, 37);
            this.btnExtract.TabIndex = 3;
            this.btnExtract.Text = "提取";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Visible = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 695);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.dataCommitFiles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIT EXTRACT";
            this.AutoSizeChanged += new System.EventHandler(this.Main_AutoSizeChanged);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCommitFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChooseCommit;
        private System.Windows.Forms.TextBox txtChooseCommit;
        private System.Windows.Forms.DataGridView dataCommitFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 我习惯自己输入CommitIDToolStripMenuItem;
        private System.Windows.Forms.Button btnShowCommitRecord;
        private System.Windows.Forms.Button chooseSavePath;
        private System.Windows.Forms.CheckBox cboBuildTemplate;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大小写转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件处理FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拾色器SToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExtract;
    }
}

