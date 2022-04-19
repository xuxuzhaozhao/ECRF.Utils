using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECRF.Utils.GIT_EXTRACT.ToolForms
{
    public partial class UpperAndLowerForm : Form
    {
        public UpperAndLowerForm()
        {
            InitializeComponent();
        }

        private void UpperAndLowerForm_Load(object sender, EventArgs e)
        {
            txtInput.Text = Clipboard.GetText();
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            string str = txtInput.Text.ToLower();
            Clipboard.SetText(str);
            txtOutput.Text = str;
            lblResult.Text = $"{str} 已复制到剪贴板。√";
            this.Hide();
        }

        private void btnUpper_Click(object sender, EventArgs e)
        {
            string str = txtInput.Text.ToUpper();
            Clipboard.SetText(str);
            txtOutput.Text = str;
            lblResult.Text = $"{str} 已复制到剪贴板。√";
            this.Hide();
        }
    }
}
