using Dapper;
using ECRF.FixData.Inspection;
using ECRF.Git;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECRF.FixData
{
    class Program
    {
        const string connectionStrTest = "server=192.168.200.123;database=GEI;user id=sa;password=1qaz@wsx;";
        static void Main(string[] args)
        {
            GitHelper git = new GitHelper();
            git.GitLocalDirectory = "";
            git.Clone();
            return;

            using (var con = new SqlConnection(connectionStrTest))
            {
                var sql = $@"
SELECT  MIN(InspectionTime) AS InspectionTime,
        SUBSTRING(InspectionID, 4, LEN(InspectionID)) AS InspectionID
FROM    dbo.FundsInspectionRequest_HIS
WHERE   InspectionID NOT LIKE 'MZF%'
        AND InspectionID NOT LIKE 'ZYF%'
        AND DeletedDate IS NULL
        AND SubjectName NOT LIKE '%测试%'
        AND SubjectName NOT LIKE '%大肠外科%'
        AND InspectionTime BETWEEN '2022-3-1' AND '2022-4-1'
GROUP BY InspectionID ORDER BY InspectionTime";
                var hises = con.Query<InspecitonModel>(sql);

                int i = 1;
                foreach (var his in hises)
                {
                    sql = $@"
IF EXISTS ( SELECT  *
            FROM    dbo.FundsInspectionRequest_HIS
            WHERE   InspectionID = 'MZF{his.InspectionID}' AND Status IN ( 'FINISHED', 'NEW' ))
    UPDATE  FundsInspectionRequest_HIS
    SET     InspectionTime = '{his.InspectionTime}'
    WHERE   InspectionID = 'MZF{his.InspectionID}';
ELSE
    UPDATE  FundsInspectionRequest_HIS
    SET     show = 0
    WHERE   InspectionID = 'MZD{his.InspectionID}';";
                    con.Execute(sql);

                    Console.WriteLine($"{i} ：MZD{his.InspectionID}  ======  MZF{his.InspectionID}");
                    i++;
                }
            }
        }
    }
}
