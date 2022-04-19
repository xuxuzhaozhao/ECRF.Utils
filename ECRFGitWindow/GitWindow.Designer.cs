namespace ECRFGitWindow
{
    partial class GitWindow
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtxCommitMsg = new System.Windows.Forms.RichTextBox();
            this.btnCommitAndPush = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeGitView = new System.Windows.Forms.TreeView();
            this.ctxTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.撤销更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxStageTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.取消暂存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ctxTreeMenu.SuspendLayout();
            this.ctxStageTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtxCommitMsg);
            this.panel1.Controls.Add(this.btnCommitAndPush);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 91);
            this.panel1.TabIndex = 0;
            // 
            // rtxCommitMsg
            // 
            this.rtxCommitMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxCommitMsg.Location = new System.Drawing.Point(0, 0);
            this.rtxCommitMsg.Name = "rtxCommitMsg";
            this.rtxCommitMsg.Size = new System.Drawing.Size(234, 54);
            this.rtxCommitMsg.TabIndex = 0;
            this.rtxCommitMsg.Text = "输入提交信息（必填）...";
            // 
            // btnCommitAndPush
            // 
            this.btnCommitAndPush.Location = new System.Drawing.Point(3, 60);
            this.btnCommitAndPush.Name = "btnCommitAndPush";
            this.btnCommitAndPush.Size = new System.Drawing.Size(118, 23);
            this.btnCommitAndPush.TabIndex = 1;
            this.btnCommitAndPush.Text = "全部提交并推送";
            this.btnCommitAndPush.UseVisualStyleBackColor = true;
            this.btnCommitAndPush.Click += new System.EventHandler(this.btnCommitAndPush_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeGitView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 209);
            this.panel2.TabIndex = 2;
            // 
            // treeGitView
            // 
            this.treeGitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGitView.Location = new System.Drawing.Point(0, 0);
            this.treeGitView.Name = "treeGitView";
            this.treeGitView.Size = new System.Drawing.Size(234, 209);
            this.treeGitView.TabIndex = 0;
            this.treeGitView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeGitView_NodeMouseClick);
            // 
            // ctxTreeMenu
            // 
            this.ctxTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂存ToolStripMenuItem,
            this.撤销更改ToolStripMenuItem});
            this.ctxTreeMenu.Name = "ctxTreeMenu";
            this.ctxTreeMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // 撤销更改ToolStripMenuItem
            // 
            this.撤销更改ToolStripMenuItem.Name = "撤销更改ToolStripMenuItem";
            this.撤销更改ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.撤销更改ToolStripMenuItem.Text = "<-- 撤销更改";
            this.撤销更改ToolStripMenuItem.Click += new System.EventHandler(this.撤销更改ToolStripMenuItem_Click);
            // 
            // 暂存ToolStripMenuItem
            // 
            this.暂存ToolStripMenuItem.Name = "暂存ToolStripMenuItem";
            this.暂存ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.暂存ToolStripMenuItem.Text = "+    暂存";
            this.暂存ToolStripMenuItem.Click += new System.EventHandler(this.暂存ToolStripMenuItem_Click);
            // 
            // ctxStageTreeMenu
            // 
            this.ctxStageTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消暂存ToolStripMenuItem});
            this.ctxStageTreeMenu.Name = "ctxStageTreeMenu";
            this.ctxStageTreeMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // 取消暂存ToolStripMenuItem
            // 
            this.取消暂存ToolStripMenuItem.Name = "取消暂存ToolStripMenuItem";
            this.取消暂存ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.取消暂存ToolStripMenuItem.Text = "<-- 取消暂存";
            this.取消暂存ToolStripMenuItem.Click += new System.EventHandler(this.取消暂存ToolStripMenuItem_Click);
            // 
            // GitWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GitWindow";
            this.Size = new System.Drawing.Size(234, 300);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ctxTreeMenu.ResumeLayout(false);
            this.ctxStageTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxCommitMsg;
        private System.Windows.Forms.Button btnCommitAndPush;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeGitView;
        private System.Windows.Forms.ContextMenuStrip ctxTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem 撤销更改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂存ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxStageTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem 取消暂存ToolStripMenuItem;
    }
}
