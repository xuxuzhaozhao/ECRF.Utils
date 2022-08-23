using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.BatchExecuteTask.Common
{
    public class XLogger
    {
        private static string log_path = Environment.CurrentDirectory + "\\batchinspection_log\\";
        public static void Info(DateTime initTime, string msg)
        {
            Console.WriteLine(msg);
            string str = "success.log";
            if (!Directory.Exists(log_path))
                Directory.CreateDirectory(log_path);
            using (StreamWriter streamWriter = new StreamWriter(log_path + str, true, Encoding.UTF8))
                streamWriter.WriteLine(msg);
        }

        public static void Info(DateTime initTime, Exception ex)
        {
            Console.WriteLine(string.Format("[{0:yyyy-MM-dd}]:{1}", (object)initTime, (object)ex.Message));
            string str = "exception.log";
            if (!Directory.Exists(log_path))
                Directory.CreateDirectory(log_path);
            using (StreamWriter streamWriter = new StreamWriter(log_path + str, true, Encoding.UTF8))
                streamWriter.WriteLine(string.Format("{0:yyyy-MM-dd}", (object)initTime));
        }

        public static void Error(DateTime initTime, string msg)
        {
            Console.WriteLine(msg);
            string str = "repull.log";
            if (!Directory.Exists(log_path))
                Directory.CreateDirectory(log_path);
            using (StreamWriter streamWriter = new StreamWriter(log_path + str, true, Encoding.UTF8))
                streamWriter.WriteLine(initTime.ToString("yyyy-MM-dd"));
        }
    }
}
