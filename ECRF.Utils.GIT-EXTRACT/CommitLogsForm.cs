﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ECRF.Utils.GIT_EXTRACT
{
    public partial class CommitLogsForm : Form
    {
        public event EventHandler sendMsgEvent;
        List<CommitLogModel> logList = new List<CommitLogModel>();

        public CommitLogsForm()
        {
            InitializeComponent();

            sendMsgEvent += Program.main.CommitFormChanged;
        }

        private void CommitLogsForm_Load(object sender, EventArgs e)
        {
            int count = AppSettings.COMMIT_RECORD_NUM;
            var modifier = AppSettings.COMMIT_MODIFIER;
            this.txtCommitRecord.Text = count.ToString();
            cboModifier.Text = modifier;
            LoadData(count, modifier);
        }

        private void LoadData(int count, string modifier)
        {
            logList.Clear();
            //加载数据源
            using (var repo = new Repository(AppSettings.REPO_PATH))
            {
                if (repo.Commits.Count() - 1 <= count)
                {
                    count = repo.Commits.Count() - 1;
                }
                var allModifers = repo.Commits.Select(t => t.Author.Name).Distinct().ToList();
                allModifers.Insert(0, "全部");
                cboModifier.DataSource = allModifers;
                cboModifier.Text = modifier;

                var commits = repo.Commits.Where(t => !t.Message.Contains("Merge branch")).ToList();
                if (string.IsNullOrWhiteSpace(modifier) || modifier == "全部")
                {
                    commits = commits.Take(count).ToList();
                }
                else
                {
                    commits = commits.Where(t => t.Author.Name.Contains(modifier)).Take(count).ToList();
                }

                foreach (var commit in commits)
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

            var modifier = cboModifier.Text;

            bool isInt = int.TryParse(recordNum, out int num);
            if (!isInt || num <= 0)
            {
                MessageBox.Show("请输入正确的正整数");
                return;
            }

            Tools.SaveAppSetting(nameof(AppSettings.COMMIT_RECORD_NUM), num.ToString());
            Tools.SaveAppSetting(nameof(AppSettings.COMMIT_MODIFIER), modifier);
            LoadData(num, modifier);
        }

        //右键复制
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.DataGridView_CellMouseClick(sender, e, MousePosition);
        }

        private void btnGetMessageToMonth_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var MonthDay1 = $"{DateTime.Now.Year}-{DateTime.Now.Month}-01";
            logList.Where(t => DateTime.Parse(t.CommitDate) > DateTime.Parse(MonthDay1)).OrderBy(t => t.CommitDate)
                .Select(t => sb.Append(t.Message)).ToList();
            Clipboard.SetData(DataFormats.Text, sb.ToString());
            MessageBox.Show("Done");
        }
    }
}
