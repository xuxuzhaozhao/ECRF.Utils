using ECRF.Utils.GIT_EXTRACT.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECRF.Utils.GIT_EXTRACT
{
    public partial class RepoSettingForm : Form
    {
        public RepoSettingForm()
        {
            InitializeComponent();
        }

        private void RepoSettingForm_Load(object sender, EventArgs e)
        {
            this.txtRepoPosition.Text = AppSettings.REPO_PATH;
            rbtnAsp.Checked = AppSettings.ASP_PATH == "Asp";
            rbtnWEB.Checked = AppSettings.ASP_PATH == "WEB";
            rbtnWebSite.Checked = AppSettings.ASP_PATH == "WebSite";
            cbxNeedBin.Checked = AppSettings.NEED_EXPORT_BIN;
            cbxNeedLib.Checked = AppSettings.NEED_EXPORT_LIB;
        }

        private void btnSetRepoPosition_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                this.txtRepoPosition.Text = dialog.SelectedPath;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string repoPath = this.txtRepoPosition.Text;
            if (string.IsNullOrEmpty(repoPath))
            {
                MessageBox.Show(this, "仓库路径不能为空", "提示"); return;
            }
            if (!File.Exists($@"{repoPath}\.gitignore"))
            {
                MessageBox.Show(this, "仓库路径必须包含文件【.gitignore】", "提示"); return;
            }
            Tools.SaveAppSetting(nameof(AppSettings.REPO_PATH), repoPath);

            string aspPath = string.Empty;

            if (rbtnAsp.Checked)
            {
                aspPath = "Asp";
            }
            if (rbtnWEB.Checked)
            {
                aspPath = "WEB";
            }
            if (rbtnWebSite.Checked)
            {
                aspPath = "WebSite";
            }
            if (!string.IsNullOrWhiteSpace(txtSelfDefine.Text))
            {
                aspPath = txtSelfDefine.Text;
                rbtnAsp.Checked = false;
                rbtnWEB.Checked = false;
                rbtnWebSite.Checked = false;
            }
            Tools.SaveAppSetting(nameof(AppSettings.ASP_PATH), aspPath);

            string needBin = cbxNeedBin.Checked ? "true" : "false";
            string needLib = cbxNeedLib.Checked ? "true" : "false";
            Tools.SaveAppSetting(nameof(AppSettings.NEED_EXPORT_BIN), needBin);
            Tools.SaveAppSetting(nameof(AppSettings.NEED_EXPORT_LIB), needLib);

            MessageBox.Show(this, "保存成功", "提示");
            Application.Restart();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
