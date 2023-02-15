using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.Utils.GIT_EXTRACT.Common
{
    public static class AppSettings
    {
        public static string REPO_PATH => ConfigurationManager.AppSettings[nameof(REPO_PATH)];
        public static int COMMIT_RECORD_NUM => int.Parse(ConfigurationManager.AppSettings[nameof(COMMIT_RECORD_NUM)]); 
        public static string COMMIT_MODIFIER => ConfigurationManager.AppSettings[nameof(COMMIT_MODIFIER)];
        public static string INPUT_TYPE => ConfigurationManager.AppSettings[nameof(INPUT_TYPE)];
        public static bool SHOW_ONCE_AGAIN => bool.Parse(ConfigurationManager.AppSettings[nameof(SHOW_ONCE_AGAIN)]);
        public static string ASP_PATH => ConfigurationManager.AppSettings[nameof(ASP_PATH)];
        public static string LAST_SELECTED_PATH => ConfigurationManager.AppSettings[nameof(LAST_SELECTED_PATH)];
        public static bool NEED_EXPORT_BIN => bool.Parse(ConfigurationManager.AppSettings[nameof(NEED_EXPORT_BIN)]);
        public static bool NEED_EXPORT_LIB => bool.Parse(ConfigurationManager.AppSettings[nameof(NEED_EXPORT_LIB)]);
    }
}
