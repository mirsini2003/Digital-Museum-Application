using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class PayScreen : Form
    {
        string order;
        DBHandling dbh = new DBHandling();
        public string Order { get => order; set => order = value; }

        public PayScreen(string order ,int sum)
        {
            InitializeComponent();

            //Initial hide
            hol_name_label.Hide();
            card_num_label.Hide();
            cvv_label.Hide();
            hol_name_textbox.Hide();
            card_num_textbox.Hide();
            cvv_textbox.Hide();

            //Intialize order
            this.order = order;
            label1.Text +=sum.ToString()+"$" ;
        }

        private void card_radio_CheckedChanged(object sender, EventArgs e)
        {
            clear_card_info();
            RadioButton clickedRadio = sender as RadioButton;

            if (clickedRadio.Tag == "unchecked")
            {
                clickedRadio.Tag = "checked";
                foreach (Control control in ((Control)sender).Parent.Controls)
                {
                    if (control is RadioButton radioButton && control != sender)
                    {
                        radioButton.Checked = false;
                        radioButton.Tag = "unchecked";
                    }
                }
                hol_name_label.Show();
                card_num_label.Show();
                cvv_label.Show();
                hol_name_textbox.Show();
                card_num_textbox.Show();
                cvv_textbox.Show();
                card_network_label.Show();

                //

            }
            else
            {
                clickedRadio.Tag = "unchecked";
                hol_name_label.Hide();
                card_num_label.Hide();
                cvv_label.Hide();
                hol_name_textbox.Hide();
                card_num_textbox.Hide();
                cvv_textbox.Hide();
                card_network_label.Hide();
            }
            

            
        }

        private void cash_radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton clickedRadio = sender as RadioButton;
            
            if (clickedRadio.Tag == "unchecked")
            {
                clickedRadio.Tag = "checked";
                foreach (Control control in ((Control)sender).Parent.Controls)
                {
                    if (control is RadioButton radioButton && control != sender)
                    {
                        radioButton.Checked = false;
                        radioButton.Tag = "unchecked";
                    }
                }
            }
            else
            {
                clickedRadio.Tag = "unchecked";
            }
        }



        private void order_button_Click(object sender, EventArgs e)
        {
            if (last_check() || cash_radio.Tag == "checked")
            {
                MessageBox.Show("Payment was successful");
                dbh.AddOrder(Order);
                this.Close();
            }
            else
            {
                MessageBox.Show("Some info that u inputed is wrong");
            }  
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


        private void card_num_textbox_TextChanged(object sender, EventArgs e)
        {

            check_card_num_format();

            if (!string.IsNullOrEmpty(card_num_textbox.Text))
            {
                check_card_network();
            }
            else
            {
                card_network_label.Text = "Other";
            }

            
        }

        private void hol_name_textbox_TextChanged(object sender, EventArgs e)
        {
            if (!ContainsNonAlphabetic(hol_name_textbox.Text))
            {
                hol_name_textbox.BackColor = Color.Green;
            }
            else
            {
                hol_name_textbox.BackColor = Color.Red;
            }
        }

        private void cvv_textbox_TextChanged(object sender, EventArgs e)
        {
            if (cvv_textbox.Text.Length == 3 && IsNumeric(cvv_textbox.Text))
            {
                cvv_textbox.BackColor = Color.Green;
            }
            else
            {
                cvv_textbox.BackColor = Color.Red;
            }

        }
        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private void check_card_network()
        {
            if (card_num_textbox.Text[0] == '2' || card_num_textbox.Text[0] == '5')
            {
                card_network_label.Text = "Mastercard";
            }
            else if (card_num_textbox.Text[0] == '4')
            {
                card_network_label.Text = "Visa";
            }
            else if (card_num_textbox.Text[0] == '3')
            {
                card_network_label.Text = "American Express";
            }
            else
            {
                card_network_label.Text = "Other";
            }
        }

        private void check_card_num_format()
        {

            if (card_num_textbox.Text.Length == 16 && IsNumeric(card_num_textbox.Text))
            {
                card_num_textbox.BackColor = Color.Green;
            }
            else
            {
                card_num_textbox.BackColor = Color.Red;
            }
        }

        
        private bool ContainsNonAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return true; // Found a non-alphabetic character, return true
                }
            }

            return false; // All characters are letters
        }

        private bool last_check()
        {
            if((cvv_textbox.BackColor == Color.Green) && card_num_textbox.BackColor == Color.Green && hol_name_textbox.BackColor == Color.Green)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        private void clear_card_info()
        {
            hol_name_textbox.Text = string.Empty;
            card_num_textbox.Text = string.Empty;
            cvv_textbox.Text = string.Empty;
            hol_name_textbox.BackColor = Color.White;
            card_num_textbox.BackColor = Color.White;
            cvv_textbox.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP", button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void order_button_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void order_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cancel_button_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cancel_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
