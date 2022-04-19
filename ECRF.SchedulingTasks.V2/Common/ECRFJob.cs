using ECRF.Schedule.Common;
using ECRF.SchedulingTasks.Common;
using Quartz;
using System;
using System.Windows.Forms;

namespace ECRF.SchedulingTasks.V2.Common
{
    public class ECRFJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            var rxtBox = (RichTextBox)dataMap["currentJob"];
            var url = dataMap["currentJobUrl"] as string;
            try
            {
                var result = ECRFCommon.HandleScheduleTask(url, rxtBox);
                var data = result?.Item1;
                if (result == null || string.IsNullOrEmpty(data) || data == "no") return;
                ECRFLog.Info($"{rxtBox.Tag}.log", $"[{data}] 耗时 {result?.Item2}", rxtBox);
            }
            catch (Exception ex)
            {
                ECRFLog.Warn($"{rxtBox.Tag}.warn", ex.Message, rxtBox);
            }
        }
    }
}
