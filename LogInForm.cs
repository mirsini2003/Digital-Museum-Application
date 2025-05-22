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
    public partial class LogInForm : Form
    {   //vasi h whatever gia stoixeia xrhstwn
        User admin = new User("panos", "123", "admin");
        User client = new User("mirsini", "456", "client");
        public LogInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass= textBox2.Text;
            if (name.Equals(admin.Name) && pass.Equals(admin.Password))
            {
                MessageBox.Show("Admin Login");
                new MenuForm(admin).Show();
                this.Hide();
            }
            else if (name.Equals(client.Name) && pass.Equals(client.Password))
            {
                MessageBox.Show("Client Login");
                new MenuForm(client).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username and/or Password");
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP", button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
