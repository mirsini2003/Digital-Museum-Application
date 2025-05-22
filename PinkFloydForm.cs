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
    public partial class PinkFloydForm : Form
    {
        ToolTip toolTip = new ToolTip();
        public PinkFloydForm()
        {
            InitializeComponent();
        }
        ToolTip toolTip1 = new ToolTip();
        SpeechSynthesizer engine = new SpeechSynthesizer();
        private void PinkFloydForm_FormClosing(object sender, FormClosingEventArgs e)
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
            toolTip1.Show("Pink Foyd Live", pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Album: The Dark side of the Moon" , pictureBox2);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Band's Members", pictureBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                engine.SpeakAsync("Pink Floyd, the progressive rock giants " +
    "formed in London in 1965, crafted " +
    "a sonic and visual landscape that " +
    "transcended conventional musical " +
    "boundaries. Comprising visionary " +
    "members such as Syd Barrett, " +
    "Roger Waters, Richard Wright, " +
    "Nick Mason, and David Gilmour, " +
    "the band experimented with psychedelic, " +
    "space rock, and conceptual elements, " +
    "delivering groundbreaking albums like " +
    "\"The Dark Side of the Moon,\" \"Wish You Were Here,\" " +
    "and \"The Wall.\" Known for their elaborate " +
    "live performances and avant-garde " +
    "approach to music production, " +
    "Pink Floyd created immersive, " +
    "otherworldly experiences that " +
    "explored themes of existentialism, " +
    "politics, and the human condition. " +
    "With their innovative soundscapes, " +
    "iconic album covers, and a commitment " +
    "to pushing artistic boundaries, Pink Floyd " +
    "has left an indelible legacy, influencing generations " +
    "of musicians and earning a place as one of the " +
    "most significant and enduring rock bands in history.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            engine.SpeakAsyncCancelAll();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Start the recording!", button2);
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
    }
}
