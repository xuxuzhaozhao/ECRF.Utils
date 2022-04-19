using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECRF.Utils.GIT_EXTRACT.Models;
using LibGit2Sharp;
using ECRF.Utils.GIT_EXTRACT.Common;

namespace ECRF.Utils.GIT_EXTRACT
{
    public partial class CommitLogsForm : Form
    {
        public event EventHandler sendMsgEvent;

        public CommitLogsForm()
        {
            InitializeComponent();

            sendMsgEvent += Program.main.CommitFormChanged;
        }

        private void CommitLogsForm_Load(object sender, EventArgs e)
        {
            int count = AppSettings.COMMIT_RECORD_NUM;
            this.txtCommitRecord.Text = count.ToString();
            LoadData(count);
        }

        private void LoadData(int count)
        {
            var logList = new List<CommitLogModel>();
            //加载数据源
            using (var repo = new Repository(AppSettings.REPO_PATH))
            {
                if (repo.Commits.Count() - 1 <= count)
                {
                    count = repo.Commits.Count() - 1;
                }
                foreach (var commit in repo.Commits.Take(count))
                {
                    logList.Add(new CommitLogModel()
                    {
                        Sha = commit.Sha.Substring(0, 7),
                        Author = commit.Author.Name,
                        Message = commit.Message,
                        CommitDate = commit.Committer.When.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }
            this.dataGridView1.DataSource = logList;

            Tools.AutoDataGridViewSize(dataGridView1);
        }

        private void btnChooseCommits_Click(object sender, EventArgs e)
        {
            string chosed = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null &&
                    dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    chosed += dataGridView1.Rows[i].Cells[1].Value.ToString() + ",";
                }
            }

            sendMsgEvent(this, new ECRFEventArgs() { Message = chosed });
            this.Close();
        }

        private void btnChangeRecordNum_Click(object sender, EventArgs e)
        {
            string recordNum = this.txtCommitRecord.Text;

            bool isInt = int.TryParse(recordNum, out int num);
            if (!isInt || num <= 0)
            {
                MessageBox.Show("哎呀，请输入正确的正整数嘛。");
                return;
            }

            Tools.SaveAppSetting(nameof(AppSettings.COMMIT_RECORD_NUM), num.ToString());
            LoadData(num);
        }

        //右键复制
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.DataGridView_CellMouseClick(sender, e, MousePosition);
        }
    }
}
