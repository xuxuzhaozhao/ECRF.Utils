using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace ECRFGitWindow
{
    public partial class GitWindow : UserControl
    {
        static Dictionary<FileStatus, string> fileDic = new Dictionary<FileStatus, string>() {
            { FileStatus.ModifiedInWorkdir,"        M" },
            { FileStatus.NewInWorkdir,"     A" },
            { FileStatus.DeletedFromWorkdir,"       D" },
        };
        static string _gitPath => ConfigurationManager.AppSettings["GIT_WORK_DIRECTORY"];
        static string _girRemoteUrl => ConfigurationManager.AppSettings["GIT_REMOTE_URL"];
        static string _gitUserName => ConfigurationManager.AppSettings["GIT_USERNAME"];
        static string _gitPassword => ConfigurationManager.AppSettings["GIT_PASSWORD"];
        public GitWindow()
        {
            InitializeComponent();
            InitializeCustomFunc();
        }

        private void InitializeCustomFunc()
        {
            rtxCommitMsg.GotFocus += (sender, e) =>
            {
                if (rtxCommitMsg.Text == "输入提交信息（必填）...")
                    rtxCommitMsg.Text = "";
            };
            rtxCommitMsg.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(rtxCommitMsg.Text))
                    rtxCommitMsg.Text = "输入提交信息（必填）...";
            };
        }

        public void UpdateGitStatus()
        {
            if (string.IsNullOrEmpty(_gitPath))
            {
                MessageBox.Show("Git文件夹为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            int modifiedCount = 0;
            treeGitView.Nodes.Clear();
            using (var repo = new Repository(_gitPath))
            {
                var modifiedFile = repo.RetrieveStatus(new StatusOptions());
                if (modifiedFile.Staged.Count() > 0)
                {
                    TreeNode StageNode = treeGitView.Nodes.Add("ALLSTAGE", ""); // 暂存更改数
                    StageNode.Tag = "stage";
                    foreach (var item in modifiedFile.Staged)
                    {
                        AddFilePathNode(StageNode, item, "stage");
                    }
                    treeGitView.Nodes.Find("ALLSTAGE", false).First().Text = $"暂存更改数（{modifiedFile.Staged.Count() }）";
                }

                TreeNode noStageNode = treeGitView.Nodes.Add("ALLNOSTAGE", ""); // 更改数
                noStageNode.Tag = "nostage";
                foreach (var item in modifiedFile)
                {
                    if (!fileDic.ContainsKey(item.State)) continue;
                    AddFilePathNode(noStageNode, item, "nostage");
                    modifiedCount++;
                }
                treeGitView.Nodes.Find("ALLNOSTAGE", false).First().Text = $"更改数（{modifiedCount}）";
            }
            treeGitView.ExpandAll();
        }

        private static void AddFilePathNode(TreeNode StageNode, StatusEntry item, string tag)
        {
            var dicName = Path.GetDirectoryName(item.FilePath);
            var dicNodeLength = StageNode.Nodes.Find(dicName, false);

            var dicNode = dicNodeLength.Length > 0 ? dicNodeLength.First()
                : StageNode.Nodes.Add(dicName, Path.GetFileName(dicName));
            dicNode.Tag = tag;

            TreeNode fileNode = dicNode.Nodes.Add(item.FilePath, Path.GetFileName(item.FilePath));
            fileNode.Tag = tag;
        }

        private void treeGitView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            treeGitView.SelectedNode = e.Node;
            if (treeGitView.SelectedNode.Tag.ToString() == "nostage")
            {
                ctxTreeMenu.Show((Control)sender, e.X, e.Y);
            }
            else
            {
                ctxStageTreeMenu.Show((Control)sender, e.X, e.Y);
            }
        }

        private void btnCommitAndPush_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtxCommitMsg.Text)
                || rtxCommitMsg.Text == "输入提交信息（必填）...")
            {
                MessageBox.Show("提交信息必须填写。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            try
            {
                using (var repo = new Repository(_gitPath))
                {
                    Signature author = new Signature("徐程意", "xucy@ecrfplus.com", DateTime.Now);
                    Signature committer = author;

                    Commit commit = repo.Commit(rtxCommitMsg.Text, author, committer);
                }
                var git = new CommandRunner("git", _gitPath);
                git.Run("remote set-url origin http://xucy:a1234567@122.224.205.146:9090/fdzl/gei.git");
                git.Run("push origin master");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 撤销更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string treeKey = treeGitView.SelectedNode.Name;
            using (var repo = new Repository(_gitPath))
            {
                var options = new CheckoutOptions { CheckoutModifiers = CheckoutModifiers.Force };
                if (treeKey == "ALLNOSTAGE") treeKey = "";
                repo.CheckoutPaths(repo.Head.FriendlyName, new[] { Path.Combine(_gitPath, treeKey) }, options);
            }
            UpdateGitStatus();
        }

        private void 暂存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string treeKey = treeGitView.SelectedNode.Name;
            using (var repo = new Repository(_gitPath))
            {
                if (treeKey == "ALLNOSTAGE") Commands.Stage(repo, "*");
                else
                {
                    if (treeGitView.SelectedNode.Nodes.Count > 0)
                    {
                        foreach (TreeNode fileNode in treeGitView.SelectedNode.Nodes)
                        {
                            repo.Index.Add(fileNode.Name);
                        }
                    }
                    else
                    {
                        repo.Index.Add(treeKey);
                    }
                    repo.Index.Write();
                }
            }
            UpdateGitStatus();
        }

        private void 取消暂存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string treeKey = treeGitView.SelectedNode.Name;

            var git = new CommandRunner("git", _gitPath);
            if (treeKey == "ALLSTAGE") treeKey = "";
            var reset = git.Run($"reset {Path.Combine(_gitPath, treeKey)}");
            UpdateGitStatus();
        }
    }

    public class CommandRunner
    {
        public string ExecutablePath { get; }
        public string WorkingDirectory { get; }

        public CommandRunner(string executablePath, string workingDirectory = null)
        {
            ExecutablePath = executablePath ?? throw new ArgumentNullException(nameof(executablePath));
            WorkingDirectory = workingDirectory ?? Path.GetDirectoryName(executablePath);
        }

        public string Run(string arguments)
        {
            var info = new ProcessStartInfo(ExecutablePath, arguments)
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = WorkingDirectory,
            };
            var process = new Process
            {
                StartInfo = info,
            };
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }
    }
}
