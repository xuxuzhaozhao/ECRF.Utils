using ECRF.Utils.GIT_EXTRACT.Common;
using ECRF.Utils.GIT_EXTRACT.Models;
using ECRF.Utils.GIT_EXTRACT.ToolForms;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ECRF.Utils.GIT_EXTRACT
{
    public partial class Main : Form
    {
        private static string tips = $"1、第一次使用请 设置->仓库位置 (.gitignore上一级目录)；\r\n2、首页会默认加载最新一次Commit；\r\n3、如果不想选择记录，也可以设置自己输入；\r\n 4、提包时只会复制【{AppSettings.ASP_PATH}】下的文件，其他的选了也不会复制。 \r\n \t\tby xuchengyi";
        public Main()
        {
            if (AppSettings.SHOW_ONCE_AGAIN)
            {
                DialogResult result = MessageBox.Show("首次使用请 设置->仓库位置 (.gitignore上一级目录)。" + "\r\n是否不再显示此信息？",
                    "欢迎使用伊柯夫GIT提包工具😀", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Tools.SaveAppSetting(nameof(AppSettings.SHOW_ONCE_AGAIN), "false");
                }
            }

            InitializeComponent();
            ChangeInputType(AppSettings.INPUT_TYPE);
            if (AppSettings.INPUT_TYPE == "CHOOSE")
            {
                this.我习惯自己输入CommitIDToolStripMenuItem.Text = "Commit输入模式";
            }
            if (AppSettings.INPUT_TYPE == "INPUT")
            {
                this.我习惯自己输入CommitIDToolStripMenuItem.Text = "Commit选择模式";
            }

            cboBuildTemplate.Location = new Point(100, 20);
            groupBox1.Visible = false;
        }

        private void btnChooseCommit_Click(object sender, EventArgs e)
        {
            CommitLogsForm commitLogsForm = new CommitLogsForm();
            commitLogsForm.Show();
        }

        internal void CommitFormChanged(object sender, EventArgs e)
        {
            var args = e as ECRFEventArgs;
            this.txtChooseCommit.Text = args.Message;
            if (string.IsNullOrEmpty(this.txtChooseCommit.Text))
            {
                this.dataCommitFiles.DataSource = null;
                return;
            }

            LoadRecordData(args.Message);
        }

        private void LoadRecordData(string records)
        {
            List<CommitFile> fileList = new List<CommitFile>();
            List<string> commitList = records.Split(',').Where(t => !string.IsNullOrEmpty(t)).ToList();
            using (var repo = new Repository(AppSettings.REPO_PATH))
            {
                foreach (var item in commitList)
                {
                    var commit = repo.Lookup<Commit>(item);
                    Tree currentTree = repo.Lookup<Commit>(commit.Sha).Tree;
                    Tree currentParentTree = repo.Lookup<Commit>(commit.Parents.FirstOrDefault()?.Sha)?.Tree;
                    if (currentParentTree == null)
                    {
                        continue;
                    }
                    var patch = repo.Diff.Compare<Patch>(currentParentTree, currentTree);

                    foreach (var ptc in patch)
                    {
                        fileList.Add(new CommitFile()
                        {
                            Sha = item,
                            Author = commit.Author.Name,
                            Message = commit.Message,
                            //Status = ptc.Status.ToString(),
                            CommitDate = commit.Committer.When.ToString("yyyy-MM-dd HH:mm:ss"),
                            FilePath = ptc.Path
                        });
                    }
                }
            }
            this.dataCommitFiles.DataSource = fileList;
            Tools.AutoDataGridViewSize(dataCommitFiles, true, true);

            dataCommitFiles.ClearSelection();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            List<string> pathList = new List<string>();
            for (int i = 0; i < dataCommitFiles.Rows.Count; i++)
            {
                if (dataCommitFiles.Rows[i].Cells[0].Value != null &&
                    dataCommitFiles.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    pathList.Add(dataCommitFiles.Rows[i].Cells[5].Value.ToString());
                }
            }

            //C:\Users\xuxuzhaozhao\Desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //C:\Users\xuxuzhaozhao\Desktop\Asp
            string destPath = $"{desktop}\\Asp";

            if (Directory.Exists(destPath))
            {
                MessageBox.Show("先把桌面的Asp文件移除,在提交.");
                return;
            }
            Directory.CreateDirectory(destPath);

            // path: GEI\Asp\admin\query.aspx
            foreach (var path in pathList)
            {
                // D:work\gei\  GEI\Asp\admin\query.aspx
                var sourceFullFilePath = $"{AppSettings.REPO_PATH}\\{path}";

                //count=4 切除'GEI\'这四个字符
                int count = path.IndexOf(@"Asp\");
                //C:\Users\xuxuzhaozhao\Desktop\  Asp\admin\
                var destFullPath = $"{desktop}\\{ Path.GetDirectoryName(path.Substring(count, path.Length - (count + 1)))}";

                if (!Directory.Exists(destFullPath))
                {
                    Directory.CreateDirectory(destFullPath);
                }

                //C:\Users\xuxuzhaozhao\Desktop\Asp\admin\  query.aspx
                var destFullFilePath = $"{destFullPath}\\{Path.GetFileName(path)}";

                File.Copy(sourceFullFilePath, destFullFilePath, true);
            }
            MessageBox.Show("已拷贝");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<CommitFile> fileList = new List<CommitFile>();
            using (var repo = new Repository(AppSettings.REPO_PATH))
            {
                var commit = repo.Head.Tip;
                Tree currentTree = repo.Lookup<Commit>(commit.Sha).Tree;
                Tree currentParentTree = repo.Lookup<Commit>(commit.Parents.FirstOrDefault()?.Sha)?.Tree;
                if (currentParentTree == null)
                {
                    return;
                }
                var patch = repo.Diff.Compare<Patch>(currentParentTree, currentTree);

                foreach (var ptc in patch)
                {
                    fileList.Add(new CommitFile()
                    {
                        Sha = commit.Sha.Substring(0, 7),
                        Author = commit.Author.Name,
                        Message = commit.Message,
                        //Status = ptc.Status.ToString(),
                        CommitDate = commit.Committer.When.ToString("yyyy-MM-dd HH:mm:ss"),
                        FilePath = ptc.Path
                    });
                }
            }
            this.dataCommitFiles.DataSource = fileList;
            Tools.AutoDataGridViewSize(dataCommitFiles, true, true);

            if (dataCommitFiles.Controls.Find("checkboxHeader", true).Length > 0)
            {
                ((CheckBox)dataCommitFiles.Controls.Find("checkboxHeader", true)[0]).Checked = true;
                foreach (DataGridViewRow dr in dataCommitFiles.Rows)
                {
                    if (!dr.Cells[5].Value.ToString().Contains(AppSettings.ASP_PATH))
                    {
                        ((CheckBox)dataCommitFiles.Controls.Find("checkboxHeader", true)[0]).Checked = false;
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.ForeColor = Color.Gray;
                        dr.DefaultCellStyle = style;
                        continue;
                    }
                    dr.Cells[0].Value = true;
                }
                return;
            }
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tips,
                "欢迎使用伊柯夫GIT提包工具😀", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 自定义CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string promptValue = Prompt.ShowDialog(@"仓库位置：", "设置仓库位置", AppSettings.REPO_PATH);
            //if (string.IsNullOrEmpty(promptValue))
            //{
            //    return;
            //}

            //Tools.SaveAppSetting(nameof(AppSettings.REPO_PATH), promptValue);

            //Application.Restart();

            RepoSettingForm repoForm = new RepoSettingForm();
            repoForm.Show();
        }

        private void 我习惯自己输入CommitIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (AppSettings.INPUT_TYPE == "CHOOSE")
            {
                value = "INPUT";
                this.我习惯自己输入CommitIDToolStripMenuItem.Text = "Commit选择模式";
            }
            if (AppSettings.INPUT_TYPE == "INPUT")
            {
                value = "CHOOSE";
                this.我习惯自己输入CommitIDToolStripMenuItem.Text = "Commit输入模式";
            }
            Tools.SaveAppSetting(nameof(AppSettings.INPUT_TYPE), value);

            ChangeInputType(value);
        }

        private void ChangeInputType(string value)
        {
            bool isChooseType = value == "CHOOSE";
            this.btnShowCommitRecord.Visible = !isChooseType;
            this.btnChooseCommit.Visible = isChooseType;
            this.txtChooseCommit.ReadOnly = isChooseType;
        }

        private void btnShowCommitRecord_Click(object sender, EventArgs e)
        {
            string records = this.txtChooseCommit.Text;
            if (string.IsNullOrEmpty(records))
            {
                MessageBox.Show("请输入正确的 Commit ID.");
                return;
            }
            LoadRecordData(records);
        }

        private void dataCommitFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.DataGridView_CellMouseClick(sender, e, MousePosition);
        }

        private void chooseSavePath_Click(object sender, EventArgs e)
        {
            string packageName = string.Empty;
            if (cboBuildTemplate.Checked)
            {
                if (string.IsNullOrEmpty(txtPackageName.Text))
                {
                    MessageBox.Show(this, "包名不可为空", "提示"); return;
                }
                else
                {
                    packageName = txtPackageName.Text;
                }
            }

            string aspPath = AppSettings.ASP_PATH;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            dialog.SelectedPath = AppSettings.LAST_SELECTED_PATH;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示"); return;
                }

                Tools.SaveAppSetting("LAST_SELECTED_PATH", dialog.SelectedPath);

                label1.Text = dialog.SelectedPath + $"\\{packageName}";
                //如果包名不为空，则将模板类信息拷贝到所选文件夹内
                if (!string.IsNullOrEmpty(packageName))
                {
                    if (!Directory.Exists(label1.Text))
                    {
                        Directory.CreateDirectory(label1.Text);
                    }
                    string template = $"{AppDomain.CurrentDomain.BaseDirectory}Template";
                    if (!Directory.Exists(template))
                    {
                        MessageBox.Show(this, "执行程序所在文件夹无模板，请确认", "提示"); return;
                    }
                    CopyDirectory(template, label1.Text);
                }

                string extramsg = string.Empty;
                List<string> pathList = new List<string>();
                List<string> commentList = new List<string>();
                for (int i = 0; i < dataCommitFiles.Rows.Count; i++)
                {
                    string comments = dataCommitFiles.Rows[i].Cells[3].Value.ToString();

                    string tmpFilePath = dataCommitFiles.Rows[i].Cells[5].Value.ToString();
                    // 如果文件地址不包含 asp 或者 website 直接就跳过
                    if (!tmpFilePath.ToUpper().Contains(aspPath.ToUpper()))
                    {
                        extramsg = $"(非{aspPath}下的文件不会被复制，请知悉)"; continue;
                    }

                    if (dataCommitFiles.Rows[i].Cells[0].Value != null &&
                        dataCommitFiles.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        pathList.Add(tmpFilePath);
                        commentList.Add(comments);
                    }
                }

                if (File.Exists($"{label1.Text}\\readme.txt"))
                {
                    File.WriteAllLines($"{label1.Text}\\readme.txt", commentList.Distinct(), Encoding.UTF8);
                }

                if (pathList.Count == 0)
                {
                    MessageBox.Show(this, "没有符合要求的文件提取", "提示");
                    return;
                }

                //C:\Users\xuxuzhaozhao\Desktop
                //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string desktop = this.label1.Text;

                //C:\Users\xuxuzhaozhao\Desktop\Asp
                string destPath = $"{desktop}\\{aspPath}";

                if (Directory.Exists(destPath))
                {
                    DialogResult result = MessageBox.Show($"已存在{aspPath}文件夹,是否直接覆盖.", "保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result != DialogResult.OK) return;
                }
                else
                {
                    Directory.CreateDirectory(destPath);
                }

                // path: GEI\Asp\admin\query.aspx
                foreach (var path in pathList)
                {
                    // D:work\gei\  GEI\Asp\admin\query.aspx
                    var sourceFullFilePath = $"{AppSettings.REPO_PATH}\\{path}";

                    if (!File.Exists(sourceFullFilePath)) continue;

                    //count=4 切除'GEI\'这四个字符
                    int count = path.ToUpper().IndexOf($@"{aspPath.ToUpper()}\");
                    //C:\Users\xuxuzhaozhao\Desktop\  Asp\admin\
                    var destFullPath = $"{desktop}\\{ Path.GetDirectoryName(path.Substring(count, path.Length - (count + 1)))}";

                    if (!Directory.Exists(destFullPath))
                    {
                        Directory.CreateDirectory(destFullPath);
                    }

                    //C:\Users\xuxuzhaozhao\Desktop\Asp\admin\  query.aspx
                    var destFullFilePath = $"{destFullPath}\\{Path.GetFileName(path)}";

                    File.Copy(sourceFullFilePath, destFullFilePath, true);
                }
                this.label1.Text = $"√，已复制到指定位置。{extramsg}";
                this.label1.Font = new Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.label1.ForeColor = Color.Green; ;
            }
        }

        public static void CopyDirectory(string srcPath, string destPath)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)     //判断是否文件夹
                {
                    if (!Directory.Exists(destPath + "\\" + i.Name))
                    {
                        Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                    }
                    CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                }
                else
                {
                    File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                }
            }
        }

        private void cboBuildTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (cboBuildTemplate.Checked)
            {
                cboBuildTemplate.Location = new Point(1, 20);
                groupBox1.Visible = true;

                // 获取第一个文件中的包名
                string tmp = dataCommitFiles.Rows[0].Cells[3].Value.ToString();
                tmp = Regex.Replace(tmp, @"(.*\()(.*)(\).*)", "$2");
                txtPackageName.Text = $"{tmp}-".Replace("\n", "");
            }
            else
            {
                cboBuildTemplate.Location = new Point(100, 20);
                groupBox1.Visible = false;
            }
        }

        private void 大小写转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpperAndLowerForm form = new UpperAndLowerForm();
            form.Show();
        }

        private void 文件处理FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileForm form = new FileForm();
            form.Show();
        }

        private void 拾色器SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrabColorForm form = new GrabColorForm();
            form.Show();
        }

        private void Main_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            panel1.Size = new Size(Width - 20, panel1.Height);
            panel2.Location = new Point(Width - 497, Height - 95);
            label1.Location = new Point((int)(0.0117 * Width), Height - 80);
            dataCommitFiles.Size = new Size(Width - 40, Height - 180);
            dataCommitFiles.Columns[5].Width = Width - 710;
        }
    }
}
