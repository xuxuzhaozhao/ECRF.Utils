using System;
using System.IO;
using System.Text;

namespace ECRF.Schedule.Common
{
    public class ECRFLog
    {
        private const string HIS_URL = "http://localhost:8080/WebService/server/GetInspectionInfoFromHis.ashx?op=getinfofromhis";
        private static readonly string logPath = AppDomain.CurrentDomain.BaseDirectory + "\\log";

        public static void Info(string msg, System.Windows.Forms.RichTextBox richTextBoxInstance)
        {
            string logfile = "info.log";
            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            using (StreamWriter writer = new StreamWriter(logPath + "\\" + logfile, true, Encoding.UTF8))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {msg}");
                richTextBoxInstance.Text += $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {msg}\r\n";
            }
        }

        public static void Info(string logfile, string msg, System.Windows.Forms.RichTextBox richTextBoxInstance)
        {
            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            using (StreamWriter writer = new StreamWriter(logPath + "\\" + logfile, true, Encoding.UTF8))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {msg}");
                richTextBoxInstance.Text += $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {msg}\r\n";
            }
        }

        public static void Warn(string logfile, string msg, System.Windows.Forms.RichTextBox richTextBoxInstance)
        {
            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            using (StreamWriter writer = new StreamWriter(logPath + "\\" + logfile, true, Encoding.UTF8))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd}]: {msg}");
                richTextBoxInstance.Text += $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {msg}\r\n";
            }
        }

        public static void Fail(Exception ex, System.Windows.Forms.RichTextBox richTextBoxInstance)
        {
            string logfile = "exception.log";
            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            using (StreamWriter writer = new StreamWriter(logPath + "\\" + logfile, true, Encoding.UTF8))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {HIS_URL}&date={DateTime.Now:yyyy-MM-dd}");
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {ex.Message}");
                writer.WriteLine(ex.StackTrace);

                richTextBoxInstance.Text += $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]: {ex.Message}\r\n";
            }
        }

    }
}
