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
    public partial class ConsertsForm : Form
    {
        // vazoume treis tessereis conserts me buttons pou se pane ste forms
        // sta forms:
        //list me panels poy einai reserved
        //list me panels pou einai free

        public ConsertsForm()
        {
            InitializeComponent();
        }
        ToolTip toolTip1 = new ToolTip();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuForm().Show();
        }

        private void ConsertsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // apo ta buttons 2 me 5 o xrhsths tha phgainei sta forms twn conserts 
            this.Hide();
            new BeatlesConsert().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RollingStonesConsert().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PinkFloydConsert().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QueenConsert().Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            toolTip1.Show("Click here to book your tickets for the Beatles consert", button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            toolTip1.Show("Click here to book your tickets for the Rolling Stones consert", button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            toolTip1.Show("Click here to book your tickets for the Pink Floyd consert", button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            toolTip1.Show("Click here to book your tickets for the Queen consert", button5);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP", button6);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
