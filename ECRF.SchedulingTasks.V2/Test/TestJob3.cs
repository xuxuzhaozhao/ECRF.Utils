using ECRF.Schedule.Common;
using Quartz;
using System;
using System.Windows.Forms;

namespace ECRF.SchedulingTasks.Test
{
    public class TestJob3 : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            var rxtBox = (RichTextBox)dataMap["currentJob"];
            var url = dataMap["currentJobUrl"];
            ECRFLog.Info($"{rxtBox.Tag}.log", $"耗时 {url}", rxtBox);
        }
    }
}
