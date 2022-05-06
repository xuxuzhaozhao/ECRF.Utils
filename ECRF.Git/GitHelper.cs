using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace ECRF.Git
{
    public class GitHelper
    {
        public string GitLocalDirectory { get; set; }
        public string GitRemoteUrl { get; set; }
        public string GitUserName { get; set; }
        public string GitUserEmail { get; set; }
        public string GitPassword { get; set; }

        [Description("git clone <GIT_REMOTE_URL> <GIT_LOCAL_DIRECTORY>")]
        public void Clone()
        {
            checkUserSettings();

            var git = new CommandRunner("git", GitLocalDirectory);
            var url = $"http://{GitUserName}:{GitPassword}@{GitRemoteUrl}";
            git._($"clone {url} {GitLocalDirectory}");
        }

        [Description("git pull")]
        public void Pull()
        {
            checkUserSettings();

            var git = new CommandRunner("git", GitLocalDirectory);
            git._($"pull");
        }

        [Description("git add <filePath>")]
        public void Add(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", GitLocalDirectory);
            git._($"add {filePath}");
        }

        [Description("git rm <filePath>")]
        public void Remove(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", GitLocalDirectory);
            git._($"rm {filePath}");
        }

        [Description("git checkout -- <filePath>")]
        public void CheckoutPath(string filePath)
        {
            checkUserSettings();

            var git = new CommandRunner("git", GitLocalDirectory);
            git._($"checkout -- {filePath}");
        }

        [Description("git commit -m <commitMsg>")]
        public void Commit(string commitMsg)
        {
            checkUserSettings();
            if (string.IsNullOrEmpty(commitMsg)) throw new ArgumentException("提交信息不可为空");

            var git = new CommandRunner("git", GitLocalDirectory);
            git._($"commit -m \"{commitMsg}\"");
        }

        [Description("git push origin master")]
        public void Push()
        {
            checkUserSettings();

            // git remote set-url origin https://xuxuzhaozhao:password@github.com/xuxuzhaozhao/ECRF.Utils.git
            var git = new CommandRunner("git", GitLocalDirectory);
            var url = $"http://{GitUserName}:{GitPassword}@{GitRemoteUrl}";
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

        private void checkUserSettings()
        {
            if (string.IsNullOrEmpty(GitLocalDirectory))
                throw new Exception("请设置Git本地目录（GitLocalDirectory）");
            if (!Directory.Exists(GitLocalDirectory))
                Directory.CreateDirectory(GitLocalDirectory);
            if (string.IsNullOrEmpty(GitRemoteUrl))
                throw new Exception("请设置Git远程URL（GitRemoteUrl）");
            if (string.IsNullOrEmpty(GitUserName))
                throw new Exception("请设置用户登录名（GitUserName）");
            if (string.IsNullOrEmpty(GitUserEmail))
                throw new Exception("请设置用户邮箱（GitUserEmail）");
            if (string.IsNullOrEmpty(GitPassword))
                throw new Exception("请设置用户密钥（GitPassword）");
        }
    }
}
