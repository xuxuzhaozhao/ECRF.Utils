using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECRF.SchedulingTasks.V2.Model
{
    public class TaskModel
    {
        private static readonly string constr = ConfigurationManager.AppSettings["CONSTR"];
        public string TaskName { get; set; }
        public string TaskUrl { get; set; }
        public string TaskCron { get; set; }


        public static List<TaskModel> GetTaskModels()
        {
            try
            {
                using (var con = new SqlConnection(constr))
                {
                    string sql =
                        @"SELECT  *
                      FROM dbo.SchedulingTasks
                      WHERE   Status = 'ACT'
                              AND DeletedDate IS NULL
                      ORDER BY SortNumber;";
                    var taskModelList = con.Query<TaskModel>(sql);
                    return taskModelList.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
