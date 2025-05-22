using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class BeatlesForm : Form
    {
        ToolTip toolTip = new ToolTip();
        public BeatlesForm()
        {
            InitializeComponent();
        }
        ToolTip toolTip1 = new ToolTip();
        SpeechSynthesizer engine = new SpeechSynthesizer();
        private void BeatlesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {//koumpi back
            engine.SpeakAsyncCancelAll();
            this.Hide();
            new TourForm().Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("The Beatles on Abbey Road!", pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Sgt.Pepper's Lonely Hearts Club Band Album!", pictureBox2);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("The band's members!", pictureBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {//den leitoyrgei to pause oso leitoyrgei to play
            engine.SpeakAsync("The Beatles, an iconic rock band from Liverpool, England, emerged in the early 1960s and forever changed the landscape of popular music. "
    + "John Lennon, Paul McCartney, "
    + "George Harrison, and Ringo Starr, "
    + "the Fab Four showcased unparalleled "
    + "songwriting talent, harmonious vocals, and a "
    + "groundbreaking approach to studio production. "
    + "Their revolutionary sound, blending "
    + "rock and roll, pop, and elements of Indian music, "
    + "resonated globally, earning them unparalleled fame. "
    + "With timeless classics like \"Hey Jude,\" \"Let It Be,\" "
    + "and \"Yesterday,\" The Beatles became cultural "
    + "pioneers and influencers, leaving an indelible "
    + "mark on the history of music. The band's artistic "
    + "evolution from the energetic Beatlemania "
    + "days to the experimental phase of albums like "
    + "\"Sgt. Pepper's Lonely Hearts Club Band\" "
    + "reflects their enduring legacy as one of "
    + "the greatest and most influential bands "
    + "in the history of popular music.");

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

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Stop the recording!", button3);
            this.Cursor = Cursors.Hand;
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

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP",button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
