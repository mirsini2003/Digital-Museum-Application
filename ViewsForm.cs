using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class ViewsForm : Form
    {
        private User user;
        public ViewsForm(User u)
        {
            InitializeComponent();
            this.user = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void ViewsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void beatles_btn_click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "interviews", "beatles_interview.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "interviews", "pinkfloyd_interview.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "interviews", "queen_interview.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "interviews", "rollingstones_interview.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new MenuForm(user).Show();
        }
    }
}
