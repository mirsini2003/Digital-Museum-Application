using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class Rating : Form
    {
        private int aris = 0;
        private int you = 0;
        private int num= 0;
        private Random rnd = new Random();
        private int panos = 0;
        public Rating()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            aris = listBox1.SelectedIndex + 1;
            num = rnd.Next(1, 10);
            aris += num;
            panos = listBox2.SelectedIndex + 1;
            num = rnd.Next(1, 10);
            panos += num;
            num = rnd.Next(1, 10);
            you += num;
            num = rnd.Next(1, 10);
            you += num;
            label2.Hide();
            label3.Hide();
            listBox1.Hide();
            listBox2.Hide();
            label1.Text = "Results:";
            if (aris > panos) {
                if (you > aris) { MessageBox.Show("You win! Points: "+you.ToString()); }
                else { MessageBox.Show("Aris wins! Points: "+aris.ToString());}
            }
            else if (panos>aris) {
                if (you > panos) { MessageBox.Show("You win! Points: "+you.ToString()); }
                else { MessageBox.Show("Panos wins! Points: "+panos.ToString()); }
            }
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
