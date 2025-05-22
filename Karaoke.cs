using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class Karaoke : Form
    {
        public Karaoke()
        {
            InitializeComponent();
        }

        private void Karaoke_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Hide();
            button7.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button7.Show();
            label1.Text = "Sing!";
            axWindowsMediaPlayer1.Show();
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "karaoke", "Hound Dog - Elvis Presley _ Karaoke Version _ KaraFun.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button7.Show();
            label1.Text = "Sing!";
            axWindowsMediaPlayer1.Show();
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "karaoke", "I Saw Her Standing There - The Beatles _.mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button7.Show();
            label1.Text = "Sing!";
            axWindowsMediaPlayer1.Show();
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "karaoke", "Neil Diamond  - Sweet Caroline (Karaoke Version).mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button7.Show();
            label1.Text = "Sing!";
            axWindowsMediaPlayer1.Show();
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "karaoke", "The Doors -Break On Through (To The Other Side).mp4"));
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button7.Hide();
            axWindowsMediaPlayer1.Hide();
            label1.Text = "Pick a song:";
            new Rating().Show();
        }
    }
}
