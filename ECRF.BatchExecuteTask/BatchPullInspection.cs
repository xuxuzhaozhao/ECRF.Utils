using ECRF.BatchExecuteTask.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.BatchExecuteTask
{
    public class BatchPullInspection
    {
        private static string path = Environment.CurrentDirectory + "\\inspection.txt";
        private static string host = ConfigurationManager.AppSettings["HOST"];

        public static void Execute()
        {
            List<string> stringList = new List<string>();
            using (StreamReader streamReader = new StreamReader(BatchPullInspection.path))
            {
                string empty = string.Empty;
                string str;
                while ((str = streamReader.ReadLine()) != null)
                    stringList.Add(str);
            }
            Stopwatch watch = new Stopwatch();
            string tmpurl = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromDays(7.0);
                stringList.ForEach((Action<string>)(inspectionTime =>
                {
                    watch.Restart();
                    tmpurl = $"{host}/WebService/server/GetInspectionInfoFromHis.ashx?op=getinfofromhis&date=" + inspectionTime;
                    string result = httpClient.GetAsync(new Uri(tmpurl)).Result.Content.ReadAsStringAsync().Result;
                    watch.Stop();
                    TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)watch.ElapsedMilliseconds);
                    string str = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms", (object)timeSpan.Minutes, (object)timeSpan.Seconds, (object)timeSpan.Milliseconds);
                    if (result.Contains("共获取") && result.Contains("条数据") && !result.Contains("共获取0条数据"))
                        XLogger.Info(DateTime.Parse(inspectionTime), "[" + inspectionTime + "]: [" + result + "] 耗时 " + str);
                    else
                        XLogger.Error(DateTime.Parse(inspectionTime), "[" + inspectionTime + "]: [未获取成功]，当前日期需重新获取。");
                }));
            }
        }
    }
}
