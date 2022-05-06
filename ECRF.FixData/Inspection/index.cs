using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECRF.FixData.Inspection
{
    public class Index
    {
        const string connectionStrTest = "server=192.168.200.123;database=GEI;user id=sa;password=1qaz@wsx;";
        public static void Execute()
        {
            using (var reader = new StreamReader(@"D:\xuxuzhaozhao\remote\ECRF.Utils\ECRF.FixData\Inspection\inspection.txt"))
            {
                string txt = string.Empty;
                int i = 1;
                while ((txt = reader.ReadLine()) != null)
                {
                    try
                    {
                        SendHttpRequest(i, txt);
                        i++;
                    }
                    catch (Exception ex)
                    {
                        using (var con = new SqlConnection(connectionStrTest))
                        {
                            con.Execute($"INSERT INTO InspectionExcel(免费单编号,HIS免费单状态,StatusText)VALUES('{txt}','异常','{ex.Message}')");
                        }
                    }
                }
            }
        }

        private static void SendHttpRequest(int i, string inspctionId)
        {
            using (var http = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("ajaxaction", "ChangeInspection"),
                    new KeyValuePair<string, string>("info", $"<inspection><inspectionid>{inspctionId}</inspectionid><type>133</type></inspection>")
                });
                var response = http.PostAsync("http://fdzlgcp.com/WebService/server/Inspection.ashx", formContent);
                var res = response.Result.Content.ReadAsStringAsync().Result;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(res);
                var code = doc.SelectSingleNode("/model/code").InnerText;

                if (code == "1")
                {
                    using (var con = new SqlConnection(connectionStrTest))
                    {
                        con.Execute($"INSERT INTO InspectionExcel(免费单编号,HIS免费单状态,StatusText)VALUES('{inspctionId}','小免费单扣费成功','{res}')");
                    }
                    Console.ResetColor();
                    Console.WriteLine(i + "：" + inspctionId + "==========>" + res);
                }
                else
                {
                    using (var con = new SqlConnection(connectionStrTest))
                    {
                        con.Execute($"INSERT INTO InspectionExcel(免费单编号,HIS免费单状态,StatusText)VALUES('{inspctionId}','操作失败','{res}')");
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(i + "：" + inspctionId + ":" + res);
                }
            }
        }
    }
}
