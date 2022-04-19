using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECRF.Utils.GIT_EXTRACT.ToolForms
{
    public partial class GrabColorForm : Form
    {
        private IntPtr _hdc = IntPtr.Zero;
        private readonly IntPtr _hWnd = IntPtr.Zero;
        public GrabColorForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = MousePosition;
            label1.Text = $"x:{p.X},y:{p.Y}";
            uint color = Win32Helper.GetPixel(_hdc, p.X, p.Y);
            byte r = Win32Helper.GetRValue(color);
            byte g = Win32Helper.GetGValue(color);
            byte b = Win32Helper.GetBValue(color);

            txtR.Text = Convert.ToString(r);
            txtG.Text = Convert.ToString(g);
            txtB.Text = Convert.ToString(b);

            richTextBox1.BackColor = Color.FromArgb(r, g, b);
            txtHex.Text = $"#{r.ToString("X").PadLeft(2, '0')}{g.ToString("X").PadLeft(2, '0')}{b.ToString("X").PadLeft(2, '0')}";
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            _hdc = Win32Helper.GetDC(_hWnd);
            Cursor = Cursors.Cross;
            timer1.Enabled = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Win32Helper.ReleaseDC(_hWnd, _hdc);
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtHex.Text);
            label1.Text = $"已复制颜色 {txtHex.Text}";
        }
    }

    public class Win32Helper
    {
        /// <summary>
        /// 该函数检索指定坐标点的像素的RGB颜色值。
        /// </summary>
        /// <param name="hDC">设备环境句柄。</param>
        /// <param name="nXPos">指定要检查的像素点的逻辑X轴坐标。</param>
        /// <param name="nYPos">指定要检查的像素点的逻辑Y轴坐标。</param>
        /// <returns>返回值是该象像点的RGB值。如果指定的像素点在当前剪辑区之外；那么返回值是CLR_INVALID。</returns>
        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int nXPos, int nYPos);

        /// <summary>
        /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，
        /// 以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。
        /// </summary>
        /// <param name="hWnd">设备上下文环境被检索的窗口的句柄，如果该值为NULL，GetDC则检索整个屏幕的设备上下文环境。</param>
        /// <returns>如果成功，返回指定窗口客户区的设备上下文环境；如果失败，返回值为Null。</returns>
        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// 该函数释放设备上下文环境（DC）供其他应用程序使用。函数的效果与设备上下文环境类型有关。
        /// 它只释放公用的和设备上下文环境，对于类或私有的则无效。
        /// </summary>
        /// <param name="hWnd">指向要释放的设备上下文环境所在的窗口的句柄。</param>
        /// <param name="hDC">指向要释放的设备上下文环境的句柄。</param>
        /// <returns>如果释放成功，则返回值为1；如果没有释放成功，则返回值为0。</returns>
        [DllImport("user32")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public static byte GetRValue(uint rgb)
        {
            return (byte)rgb;
        }
        public static byte GetGValue(uint rgb)
        {
            return (byte)(((ushort)(rgb)) >> 8);
        }
        public static byte GetBValue(uint rgb)
        {
            return (byte)(rgb >> 16);
        }
    }
}
