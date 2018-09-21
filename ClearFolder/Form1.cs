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
using System.Windows.Forms.VisualStyles;

namespace ClearFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = _shouldClose;
                this.Hide();
            }

            base.OnClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.GetEnvironmentVariable("tmp");
            NotifyIcon nof = new NotifyIcon();


            MenuItem config = new MenuItem("Configuration", OnClick_Configuration);
            MenuItem clearNow = new MenuItem("Clear now", OnClick_ClearNow);
            MenuItem close = new MenuItem("Close", OnClick_Close);

            nof.Icon = new Icon("logo.ico");
            nof.ContextMenu = new ContextMenu(new [] {config, clearNow, close});
            nof.Visible = true;
        }

        private void OnClick_Configuration(object sender, EventArgs e)
        {
            this.Show();
        }

        private bool _shouldClose = true;

        private void OnClick_Close(object sender, EventArgs e)
        {
            _shouldClose = false;
            Application.Exit();
        }

        private void OnClick_ClearNow(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(textBox1.Text);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
