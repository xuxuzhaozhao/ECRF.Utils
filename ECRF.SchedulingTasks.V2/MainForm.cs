using ECRF.SchedulingTasks.Test;
using ECRF.SchedulingTasks.V2.Common;
using ECRF.SchedulingTasks.V2.Model;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ECRF.SchedulingTasks.V2
{
    public partial class MainForm : Form
    {
        IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
        List<TaskModel> taskList = TaskModel.GetTaskModels();
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitializeDynamicJobTabControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            scheduler.Start();
            var jobAndTriggerMapping = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();

            foreach (var task in taskList)
            {
                IJobDetail currentJob = JobBuilder.Create<ECRFJob>()
                .WithIdentity(task.TaskName, $"group_{task.TaskName}")
                .Build();
                currentJob.JobDataMap.Put("currentJob", GetRichTextBoxControl(task.TaskName));
                currentJob.JobDataMap.Put("currentJobUrl", task.TaskUrl);
                var currentTriggers = new Quartz.Collection.HashSet<ITrigger>(
                 new List<ITrigger>()
                 {
                     TriggerBuilder.Create()
                         .WithIdentity($"trigger_{task.TaskName}")
                         .WithCronSchedule(task.TaskCron)
                         .Build()
                 });
                jobAndTriggerMapping[currentJob] = currentTriggers;
            }

            var readOnlyjobAndTriggerMapping =
                new ReadOnlyDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>(jobAndTriggerMapping);
            scheduler.ScheduleJobs(readOnlyjobAndTriggerMapping, true);
        }

        private void InitializeDynamicJobTabControls()
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                tabControl1.TabPages.Add(taskList[i].TaskName);
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Name = $"richTextBox{taskList[i].TaskName}";
                richTextBox.Tag = taskList[i].TaskName;
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.ReadOnly = true;
                richTextBox.Text += $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {taskList[i].TaskName}定时任务已开启\r\n";
                richTextBox.TextChanged += RichTextBox_TextChanged;
                tabControl1.TabPages[i].Controls.Add(richTextBox);
            }
        }

        private object GetRichTextBoxControl(string key)
        {
            foreach (Control item in tabControl1.TabPages)
            {
                var richTextBoxtask1 = item.Controls.Find($"richTextBox{key}", true);
                if (richTextBoxtask1.Length > 0) return richTextBoxtask1[0];
            }
            return null;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            var currentRxtBox = sender as RichTextBox;
            currentRxtBox.SelectionStart = currentRxtBox.Text.Length;
            currentRxtBox.ScrollToCaret();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("确定关闭调度任务？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                scheduler.Shutdown();
            }
            e.Cancel = result != DialogResult.OK;
        }

        private void 版权信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2002-2022 ECRFPlus. All rights reserved.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 开机自启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("\\") + 1);
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Rkey == null)
            {
                Rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
            Rkey.SetValue(keyName, path + @"\ECRF.SchedulingTasks.V2.exe");

            MessageBox.Show("开机自启设置成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
