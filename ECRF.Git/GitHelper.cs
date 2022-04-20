using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace ECRF.Git
{
    public class GitHelper
    {
        static string _gitLocalDirectory => ConfigurationManager.AppSettings["GIT_LOCAL_DIRECTORY"];
        static string _gitRemoteUrl => ConfigurationManager.AppSettings["GIT_REMOTE_URL"];
        static string _gitUserName => ConfigurationManager.AppSettings["GIT_USERNAME"];
        static string _gitUserEmail => ConfigurationManager.AppSettings["GIT_USEREMAIL"];
        static string _gitPassword => ConfigurationManager.AppSettings["GIT_PASSWORD"];

        [Description("git clone <GIT_REMOTE_URL> <GIT_LOCAL_DIRECTORY>")]
        public static void Clone()
        {
            checkUserSettings();

            var git = new CommandRunner("git", _gitLocalDirectory);
            var url = $"http://{_gitUserName}:{_gitPassword}@{_gitRemoteUrl}";
            git._($"clone {url} {_gitLocalDirectory}");
        }

        [Description("git pull")]
        public static void Pull()
        {
            checkUserSettings();

            var git = new CommandRunner("git", _gitLocalDirectory);
            git._($"pull");
        }

        [Description("git add <filePath>")]
        public static void Add(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", _gitLocalDirectory);
            git._($"add {filePath}");
        }

        [Description("git rm <filePath>")]
        public static void Remove(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", _gitLocalDirectory);
            git._($"rm {filePath}");
        }

        [Description("git checkout -- <filePath>")]
        public static void CheckoutPath(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", _gitLocalDirectory);
            git._($"checkout -- {filePath}");
        }

        [Description("git commit -m <commitMsg>")]
        public static void Commit(string commitMsg)
        {
            checkUserSettings();
            if (string.IsNullOrEmpty(commitMsg)) throw new ArgumentException("提交信息不可为空");

            var git = new CommandRunner("git", _gitLocalDirectory);
            git._($"commit -m \"{commitMsg}\"");
        }

        [Description("git push origin master")]
        public static void Push()
        {
            checkUserSettings();

            // git remote set-url origin https://xuxuzhaozhao:password@github.com/xuxuzhaozhao/ECRF.Utils.git
            var git = new CommandRunner("git", _gitLocalDirectory);
            var url = $"http://{_gitUserName}:{_gitPassword}@{_gitRemoteUrl}";
            git._($"remote set-url origin {url}");
            git._("push origin master");
        }

        private class CommandRunner
        {
            public string ExecutablePath { get; }
            public string WorkingDirectory { get; }

            public CommandRunner(string executablePath, string workingDirectory = null)
            {
                ExecutablePath = executablePath ?? throw new ArgumentNullException(nameof(executablePath));
                WorkingDirectory = workingDirectory ?? Path.GetDirectoryName(executablePath);
            }

            public string _(string arguments)
            {
                var info = new ProcessStartInfo(ExecutablePath, arguments)
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    WorkingDirectory = WorkingDirectory,
                };
                var process = new Process
                {
                    StartInfo = info,
                };
                process.Start();
                var msg = process.StandardOutput.ReadToEnd();
                return msg;
            }
        }

        private static void checkUserSettings()
        {
            if (string.IsNullOrEmpty(_gitLocalDirectory))
                throw new Exception("请设置Git本地目录（GIT_LOCAL_DIRECTORY）");
            if (!Directory.Exists(_gitLocalDirectory))
                Directory.CreateDirectory(_gitLocalDirectory);
            if (string.IsNullOrEmpty(_gitRemoteUrl))
                throw new Exception("请设置Git远程URL（GIT_REMOTE_URL）");
            if (string.IsNullOrEmpty(_gitUserName))
                throw new Exception("请设置用户登录名（GIT_USERNAME）");
            if (string.IsNullOrEmpty(_gitUserEmail))
                throw new Exception("请设置用户邮箱（GIT_USEREMAIL）");
            if (string.IsNullOrEmpty(_gitPassword))
                throw new Exception("请设置用户密钥（GIT_PASSWORD）");
        }
    }
}
