using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class QueenForm : Form
    {
        ToolTip toolTip = new ToolTip();
        public QueenForm()
        {
            InitializeComponent();
        }
        ToolTip tooltip1 = new ToolTip();
        SpeechSynthesizer engine = new SpeechSynthesizer();
        private void QueenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            engine.SpeakAsyncCancelAll();
            this.Hide();
            new TourForm().Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            tooltip1.Show("Band's members",pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            tooltip1.Show("Queen's logo", pictureBox2);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            tooltip1.Show("Freddie Mercury", pictureBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.SpeakAsync("Queen, the British rock band formed " +
    "in 1970, stands as one of the most iconic " +
    "and influential groups in the history of music. " +
    "Comprising the extraordinary talents of " +
    "Freddie Mercury, Brian May, Roger Taylor, " +
    "and John Deacon, Queen's innovative " +
    "approach to rock music defied conventions. " +
    "With Freddie Mercury's unparalleled vocal " +
    "range, Brian May's distinctive guitar sound, " +
    "and the band's ability to seamlessly blend " +
    "various genres, Queen produced timeless " +
    "classics such as \"Bohemian Rhapsody,\" " +
    "\"We Will Rock You,\" and \"Somebody to " +
    "Love.\" Their eclectic discography " +
    "showcases a dynamic range, from " +
    "operatic anthems to arena-rock " +
    "powerhouses. Queen's live performances " +
    "were legendary, and their impact on " +
    "popular culture was solidified by " +
    "Mercury's charismatic stage presence. " +
    "Inducted into the Rock and Roll Hall " +
    "of Fame, Queen's music continues to captivate " +
    "audiences globally, ensuring their legacy " +
    "as one of rock's greatest and most enduring acts.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.SpeakAsyncCancelAll();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Play the recording!", button2);
            this.Cursor = Cursors.Hand;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Stop the recording!", button3);
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }
    }
}
