using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class CafeteriaForm : Form
    {
        private string role;
        private User user;
        ToolTip toolTip1 = new ToolTip();
        public CafeteriaForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.role = user.Role;
            if (role.Equals("admin")){
                pictureBox1.Hide();
                pictureBox1.Enabled = false;
                label1.Hide();
            }
            else if (role.Equals("client")) {
                button2.Hide();
                button2.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
        }

        private void CafeteriaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminO_Q().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void CafeteriaForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            //==========================================================
            this.Cursor = Cursors.Hand;
            toolTip1.Show("Click here to see the questrions or the orders", button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor=Cursors.Default;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            toolTip1.Show("ONLINE HELP", button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new ClientO_Q(user).Show();
        }
    }
}
