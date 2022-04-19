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

namespace ECRF.Utils.GIT_EXTRACT.ToolForms
{
    public partial class FileForm : Form
    {
        public FileForm()
        {
            InitializeComponent();
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            txtInput.Text = Clipboard.GetText();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string str = Path.GetFileNameWithoutExtension(txtInput.Text.ToLower());
            Clipboard.SetText(str);
            txtOutput.Text = str;
            lblResult.Text = $"{str} 已复制到剪贴板。√";
        }
    }
}
