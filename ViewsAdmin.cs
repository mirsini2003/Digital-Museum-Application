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

namespace ergasia_alilepidrasi
{
    public partial class ViewsAdmin : Form
    {
        private User u;
        private int temperature = 21;
        private bool lights = true;
        public ViewsAdmin(User user)
        {
            InitializeComponent();
            this.u = user;
        }

        private void ViewsAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lights)
            {
                BackColor = Color.Black;
            }
            else
            {
                BackColor = Color.White;
            }
            lights = !lights;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MenuForm(u).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temperature++;
            label1.Text = temperature.ToString()+"°C";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temperature--;
            label1.Text = temperature.ToString() + "°C";
        }
    }
}
