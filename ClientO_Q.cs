using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class ClientO_Q : Form
    {
        DBHandling dbh = new DBHandling();
        private int coffee = 0;
        private int tea = 0;
        private int water= 0;
        private int beer= 0;
        private int soda= 0;
        private int pop_corn= 0;
        private string name;
        public ClientO_Q(User user)
        {
            InitializeComponent();
            this.name = user.Name;
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            order_button.Hide();
            textBox1.Hide();
            button4.Hide();
            label9.Hide();
            label17.Text = "Hello, "+this.name+".\r\nWhat would you like to do?";
        }
        private void init()
        {
            button1.Show();
            button2.Show();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            order_button.Hide();
            textBox1.Hide();
            button4.Hide();
            label9.Hide();
            label17.Show();
        }

        public int Coffee { get => coffee; set => coffee = value; }
        public int Tea { get => tea; set => tea = value; }
        public int Water { get => water; set => water = value; }
        public int Beer { get => beer; set => beer = value; }
        public int Soda { get => soda; set => soda = value; }
        public int Pop_corn { get => pop_corn; set => pop_corn = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            label17.Hide();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            label16.Show();
            order_button.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            label17.Hide();
            label9.Show();
            textBox1.Show();
            button4.Show();
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum =Coffee * 5 +Tea * 7 + Water * 2 + Beer * 8 + Soda * 4+ Pop_corn * 5;
            int[] food_ammount = {Coffee ,Tea,Water,Beer,Soda,Pop_corn};
            
            string[] food_kind= {"Coffee","Tea","Water","Beer","Soda","Pop Corn" };
            string order = "";
            for (int i=0;i<food_ammount.Length;i++)
            {
                if (food_ammount[i]>0)
                {
                    order += food_kind[i] + " x" + food_ammount[i].ToString()+", ";
                }
            }
            new PayScreen(order,sum).Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Coffee++;
            label11.Text =Coffee.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Tea++;
            label12.Text =tea.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Water++;
            label13.Text = Water.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Beer ++;
            label14.Text = Beer.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Soda++;
            label15.Text = Soda.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Pop_corn++;
            label16.Text = Pop_corn.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbh.AddQusetion(name, textBox1.Text);
            textBox1.Clear();
            init();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //see answers
        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";



            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT answer,question FROM Questions Where made_by= @name AND status='answered';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                string a_db = reader.GetString(reader.GetOrdinal("answer"));
                                string q_db = reader.GetString(reader.GetOrdinal("question"));
                                MessageBox.Show("Your Qusestion: " + q_db + Environment.NewLine + "Answer: " + a_db);
                                string updateSql = "UPDATE Questions SET  status = 'seen' Where answer= @answer AND status='answered' AND question=@question";

                                using (SQLiteCommand command2 = new SQLiteCommand(updateSql, connection))
                                {
                                    // Use parameters to avoid SQL injection and handle string values
                                    command2.Parameters.AddWithValue("@answer", a_db);
                                    command2.Parameters.AddWithValue("@question", q_db);

                                    int rowsAffected = command2.ExecuteNonQuery();

                                    if (!(rowsAffected > 0))
                                    {
                                        MessageBox.Show("Record not updated. No matching question found.");
                                    }
                                }
                            }
                        }
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }
            }
        }

        private void order_button_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void order_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void ClientO_Q_Load(object sender, EventArgs e)
        {

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

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().Show("Write your Question", textBox1);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP", button3);

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
