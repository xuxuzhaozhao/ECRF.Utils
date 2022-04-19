using ECRF.Schedule.Common;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;

namespace ECRF.SchedulingTasks.Common
{
    public class ECRFCommon
    {
        public static string HOST = ConfigurationManager.AppSettings["HOST"];
        public static Tuple<string, string> HandleScheduleTask(string url, RichTextBox richTextBoxInstance)
        {
            url = $"{HOST}/{url}";
            using (var httpClient = new HttpClient())
            {
                Stopwatch watch = new Stopwatch();
                watch.Restart();
                httpClient.Timeout = TimeSpan.FromMinutes(60);
                var uri = new Uri(url);
                var response = httpClient.GetAsync(uri).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                watch.Stop();
                TimeSpan t = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);
                string timespan = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                    t.Minutes,
                    t.Seconds,
                    t.Milliseconds);
                return new Tuple<string, string>(data, timespan);
            }
        }
    }
}
