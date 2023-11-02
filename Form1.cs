using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int KEYDOWN = 0x0000;
        private const int KEYUP = 0x0002;
        private const int LWIN = 0x5B;
        private const int KEY_K = 0x4b;

        //マウスのクリック位置を記憶
        private Point mousePoint;

        public Form1()
        {
            InitializeComponent();

            TopMost = true;

            TransparencyKey = Color.Transparent;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(LWIN, 0, KEYDOWN, UIntPtr.Zero);
                keybd_event(KEY_K, 0, KEYDOWN, UIntPtr.Zero);
                keybd_event(LWIN, 0, KEYUP, UIntPtr.Zero);
                keybd_event(KEY_K, 0, KEYUP, UIntPtr.Zero);
            }
            else
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }
    }
}