﻿using LibGit2Sharp;
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
        const string Day = "日一二三四五六";
        static void Main(string[] args)
        {
            string saveFileName = $@"D:\work\log\{DateTime.Now:yyyy-MM}.js";
            startDate = string.IsNullOrEmpty(startDate) ? DateTime.Now.ToString("yyyy-MM-01") : startDate;
            DateTime start = DateTime.Parse(startDate);
            DateTime end = string.IsNullOrEmpty(endDate) ? start.AddMonths(1) : DateTime.Parse(endDate);
            //string[] lines = GetCommitData(start);
            string[] lines = GetCommitString();
            TimeSpan ts = end - start;

            using (var writer = new StreamWriter(saveFileName))
            {
                for (int i = 0, j = 0; i < ts.Days && j < lines.Length; i++)
                {
                    var curDate = start.AddDays(i);
                    if (IsHolidayByDate(curDate).Result) continue;

                    //                    writer.WriteLine($@"
                    ////{curDate:yyyy年MM月dd日} 星期{Day[Convert.ToInt16(curDate.DayOfWeek)]}
                    //$(""#time_entry_issue_id"").val('2358');
                    //$(""#time_entry_spent_on"").val('{curDate:yyyy-MM-dd}');
                    //$(""#time_entry_hours"").val('8');
                    //$(""#time_entry_activity_id"").val('9934');
                    //$(""#time_entry_comments"").val('{lines[j]}');
                    //$(""input[name='continue']"").click();");

                    writer.WriteLine($@"
                    //{curDate:yyyy年MM月dd日} 星期{Day[Convert.ToInt16(curDate.DayOfWeek)]}
                    $(""#time_entry_issue_id"").val('812');
                    $(""#time_entry_spent_on"").val('{curDate:yyyy-MM-dd}');
                    $(""#time_entry_hours"").val('8');
                    $(""#time_entry_activity_id"").val('9934');
                    $(""#time_entry_comments"").val('{lines[j]}');
                    $(""input[name='continue']"").click();");
                    j++;
                }
            }

            OpenVsCode(saveFileName);
        }

        private static string[] GetCommitData(DateTime start)
        {
            var dataList = new Stack<string>();
            using (var repo = new Repository(@"D:\work\sichuan\2032"))
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

        private static string[] GetCommitString()
        {
            var str = @"
优化复旦伦理年度进展报告报表，将30秒的加载速度减少到2秒左右
优化复旦伦理其他审查报表，将30秒的加载速度减少到2秒左右
优化复旦伦理暂停/终止研究审查报表，将30秒的加载速度减少到2秒左右
优化复旦伦理院内个例SUSAR审查、院外个例SUSAR审查报表，将30秒的加载速度减少到2秒左右
优化复旦伦理严重不良事件报告、院外月度SUSAR审查报表，将30秒的加载速度减少到2秒左右
优化复旦伦理安全性信息不定期更新/IB（备案）审查报表，将30秒的加载速度减少到2秒左右";
           return str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
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
