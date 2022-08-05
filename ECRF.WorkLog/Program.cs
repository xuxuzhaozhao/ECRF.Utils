using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.WorkLog
{
    class Program
    {
        static string startDate = ConfigurationManager.AppSettings["start"];
        static string endDate = ConfigurationManager.AppSettings["end"];
        static void Main(string[] args)
        {
            string saveFileName = $@"D:\work\log\{DateTime.Now:yyyy-MM}.js";
            startDate = string.IsNullOrEmpty(startDate) ? DateTime.Now.ToString("yyyy-MM-01") : startDate;
            DateTime start = DateTime.Parse(startDate);
            DateTime end = string.IsNullOrEmpty(endDate) ? start.AddMonths(1) : DateTime.Parse(endDate);
            string[] lines = GetCommitData(start);

            const string Day = "日一二三四五六";
            using (var writer = new StreamWriter(saveFileName))
            {
                int i = 0;
                while (start < end)
                {
                    if (IsHolidayByDate(start).Result)
                    {
                        Console.WriteLine($"{start:yyyy年MM月dd日} 星期{Day[Convert.ToInt16(start.DayOfWeek)]} 是休息日");
                    }
                    else
                    {
                        if (lines.Length > i)
                        {
                            writer.WriteLine($@"
//{start:yyyy年MM月dd日} 星期{Day[Convert.ToInt16(start.DayOfWeek)]}
$(""#time_entry_issue_id"").val('2358');
$(""#time_entry_spent_on"").val('{start:yyyy-MM-dd}');
$(""#time_entry_hours"").val('8');
$(""#time_entry_activity_id"").val('9934');
$(""#time_entry_comments"").val('{lines[i]}');
$(""input[name='continue']"").click();");
                            i++;
                        }
                    }
                    start = start.AddDays(1);
                }
            }

            OpenVsCode(saveFileName);
        }

        private static string[] GetCommitData(DateTime start)
        {
            var dataList = new Stack<string>();
            using (var repo = new Repository(@"D:\work\gei"))
            {
                foreach (var commit in repo.Commits.Take(100))
                {
                    var Author = commit.Author.Name;
                    var Message = commit.Message;
                    var CommitDate = DateTime.Parse(commit.Committer.When.ToString("yyyy-MM-dd"));
                    if (Author == "徐程意" && CommitDate > start && !Message.Contains("Merge branch"))
                    {
                        dataList.Push(Message.Replace("\r\n", "").Replace("\n", ""));
                    }
                }
            }
            return dataList.ToArray();
        }

        public static void OpenVsCode(string saveFileName)
        {
            var info = new ProcessStartInfo(@"C:\Users\xuxuzhaozhao\AppData\Local\Programs\Microsoft VS Code\Code.exe", saveFileName)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var process = new Process
            {
                StartInfo = info,
            };
            process.Start();
        }

        /// <summary>
        /// 判断是不是周末/节假日
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>周末和节假日返回true，工作日返回false</returns>
        public static async Task<bool> IsHolidayByDate(DateTime date)
        {
            var isHoliday = false;
            var webClient = new System.Net.WebClient();
            var PostVars = new System.Collections.Specialized.NameValueCollection { { "d", date.ToString("yyyyMMdd") } };
            try
            {
                var day = date.DayOfWeek;
                //判断是否为周末
                if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
                    return true;
                //0为工作日，1为周末，2为法定节假日
                var byteResult = await webClient.UploadValuesTaskAsync("http://tool.bitefu.net/jiari/", "POST", PostVars);//请求地址,传参方式,参数集合
                var result = Encoding.UTF8.GetString(byteResult);//获取返回值
                if (result == "1" || result == "2")
                    isHoliday = true;
            }
            catch
            {
                isHoliday = false;
            }
            return isHoliday;
        }
    }
}
