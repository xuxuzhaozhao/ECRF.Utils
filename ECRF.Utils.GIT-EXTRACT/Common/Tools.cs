using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECRF.Utils.GIT_EXTRACT.Common
{
    public class Tools
    {
        /// <summary>
        /// datagridview 样式控制
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="needAllChooseCheckBox">是否需要全选</param>
        /// <param name="needStyle">是否根据表单内容控制行内样式</param>
        public static void AutoDataGridViewSize(DataGridView dataGridView, bool needAllChooseCheckBox = false, bool needStyle = false)
        {
            for (int i = 0; i < dataGridView.Columns.Count - 1; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView.Columns[dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                int colw = dataGridView.Columns[i].Width;
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                if (i != dataGridView.Columns.Count - 1 && colw > 300)
                {
                    colw = 300;
                }
                dataGridView.Columns[i].Width = colw;
            }

            if (!needAllChooseCheckBox) return;

            if (dataGridView.Controls.Find("checkboxHeader", true).Length > 0)
            {
                ((CheckBox)dataGridView.Controls.Find("checkboxHeader", true)[0]).Checked = true;
                foreach (DataGridViewRow dr in dataGridView.Rows)
                {
                    if (needStyle && !dr.Cells[5].Value.ToString().Contains(AppSettings.ASP_PATH))
                    {
                        ((CheckBox)dataGridView.Controls.Find("checkboxHeader", true)[0]).Checked = false;
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        //style.BackColor = Color.Red;
                        style.ForeColor = Color.Gray;
                        dr.DefaultCellStyle = style;
                        continue;
                    }
                    dr.Cells[0].Value = true;
                }
                return;
            }

            DataGridViewCheckBoxColumn cbCol = new DataGridViewCheckBoxColumn();
            cbCol.Width = 70;
            cbCol.HeaderText = "　  全选";
            cbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Insert(0, cbCol);

            Rectangle rect = dataGridView.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + rect.Width / 4 - 9;
            rect.Y = rect.Location.Y + (rect.Height / 2 - 9);

            CheckBox cbHeader = new CheckBox();
            cbHeader.Name = "checkboxHeader";
            cbHeader.Size = new Size(18, 18);
            cbHeader.Location = rect.Location;
            cbHeader.BackColor = Color.White;

            //cbHeader.CheckedChanged += new EventHandler(cbHeader_CheckedChanged);
            cbHeader.CheckedChanged += (sender, e) =>
            {
                foreach (DataGridViewRow dr in dataGridView.Rows)
                {
                    if (needStyle && !dr.Cells[5].Value.ToString().Contains(AppSettings.ASP_PATH))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        //style.BackColor = Color.Red;
                        style.ForeColor = Color.Gray;
                        dr.DefaultCellStyle = style;
                        dr.Cells[0].Value = false;
                        continue;
                    }
                    dr.Cells[0].Value = ((CheckBox)dataGridView.Controls.Find("checkboxHeader", true)[0]).Checked;
                };
            };

            //將 CheckBox 加入到 dataGridView
            dataGridView.Controls.Add(cbHeader);
            dataGridView.Columns[dataGridView.Columns.Count - 1].Width = dataGridView.Columns[dataGridView.Columns.Count - 1].Width - cbCol.Width;
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        internal static void SaveAppSetting(string k, string v)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[k].Value = v;
            //config.AppSettings.Settings.Add(k, v);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// DataGridView右键复制选项
        /// </summary>
        /// <param name="sender1"></param>
        /// <param name="e1"></param>
        public static void DataGridView_CellMouseClick(object sender1, DataGridViewCellMouseEventArgs e1, Point MousePosition)
        {
            if (e1.Button == MouseButtons.Right)
            {
                DataGridView dgv = sender1 as DataGridView;
                dgv.CurrentCell = dgv.Rows[e1.RowIndex].Cells[e1.ColumnIndex];
                //dgv.Rows[e1.RowIndex].Cells[e1.ColumnIndex].Selected = true;   
                ContextMenuStrip context = new ContextMenuStrip();
                //context.SuspendLayout();   
                //context.Tag = (dgv.Rows[e1.RowIndex].Cells[e1.ColumnIndex].Value ?? "").ToString();   
                context.Size = new System.Drawing.Size(153, 22);

                ToolStripMenuItem contextItem = new ToolStripMenuItem();
                contextItem.Tag = (dgv.Rows[e1.RowIndex].Cells[e1.ColumnIndex].Value ?? "").ToString();
                contextItem.Size = new System.Drawing.Size(152, 22);
                contextItem.Text = "复制";
                contextItem.Click += new System.EventHandler(
                    (sender2, e2) =>
                    {
                        ToolStripMenuItem tsmi = sender2 as ToolStripMenuItem;
                        Clipboard.Clear();
                        Clipboard.SetData(DataFormats.Text, tsmi.Tag);
                    }
                );
                context.Items.Add(contextItem);
                context.Show(MousePosition.X, MousePosition.Y);
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string value = "")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            Label textLabel = new Label() { Left = 50, Top = 10, Text = text, Width = 100 };
            TextBox textBox = new TextBox() { Left = 50, Top = 35, Width = 400, Text = value };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 65, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
