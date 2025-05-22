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
    public partial class MenuForm : Form
    {
        private string role;
        private User user;

        public string Role { get => role; set => role = value; }
        public User User { get => user; set => user = value; }

        public MenuForm()
        {
            InitializeComponent();
        }

        public MenuForm(string role)
        {
            InitializeComponent();
            this.Role = role;
            if (role.Equals("admin"))
            {
                button1.Hide();
                button2.Hide();
                button3.Hide();
            }
        }

        public MenuForm(User user)
        {
            InitializeComponent();
            this.User = user;
            this.Role = user.Role;
            if(this.Role.Equals("admin"))
            {
                button1.Hide();
                button2.Hide();
               // button3.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TourForm tourForm = new TourForm();
            tourForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsertsForm consertsForm = new ConsertsForm();
            consertsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (role.Equals("client"))
            {
                ViewsForm viewsForm = new ViewsForm(user);
                viewsForm.Show();
            }
            else
            {
                new ViewsAdmin(user).Show();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DigitalDJ digitalDJ = new DigitalDJ(User);
            digitalDJ.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CafeteriaForm cafeteriaForm = new CafeteriaForm(User);
            cafeteriaForm.Show();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP",button6);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
