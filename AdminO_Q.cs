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
    public partial class AdminO_Q : Form
    {
        List<string> questions = new List<string>();
        List<string> orders = new List<string>();
        List<Label> l = new List<Label>();
        List<TextBox> t = new List<TextBox>();
        List<Button> b = new List<Button>();

        public AdminO_Q()
        {
            InitializeComponent();/*
            questions.Add("hi");
            questions.Add("hello");
            questions.Add("my name is panos");
            questions.Add("i have a question");
            questions.Add("nevermind");*/
            get_initial_data_db();
            get_orders_db();
          //  questions.Add("hey");
          /*  orders.Add("2 x Coffee");
            orders.Add("1 x Coffee , 2 x Soda");*/
            // tha pairnei me desirialization tis erwthseis kai tis paraggelies
            button1.Text = "Orders\r\n(" + orders.Count.ToString() + ")";
            button2.Text = "Answer Questions\r\n(" + questions.Count.ToString() + ")";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void get_initial_data_db()
        {
            // Connection string
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";



            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT question FROM Questions WHERE status ='pending';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                string q_db = reader.GetString(reader.GetOrdinal("question"));
                                questions.Add(q_db);
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
            //orders
           
        }
        private void get_orders_db()
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";
            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT customer_order FROM Orders WHERE status ='pending';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                string o_db = reader.GetString(reader.GetOrdinal("customer_order"));
                                orders.Add(o_db);
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
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text ="Deliver the orders";
            button1.Hide();
            button2.Hide();
            int i = 0;
            foreach (string o in orders)
            {
                int currentIndex = i; // Capture the current value of i
                l.Add(new Label());
                b.Add(new Button());
                l[i].Text = "Order " + (i + 1).ToString() + ": " + o;
                l[i].Font = new Font("Arial", 9, FontStyle.Bold); // Adjust the font size as needed
                l[i].Show();
                l[i].AutoSize = true;
                b[i].Show();
                if (i != 0)
                {
                    l[i].Location = new Point(0, l[i - 1].Bottom + 45);

                }
                else if (i == 0)
                {
                    l[i].Location = new Point(0, 30);
                }
                b[i].Location = new Point(10, l[i].Bottom + 5);
                b[i].Text = "Deliver";
                b[i].Click += (buttonSender, eventArgs) =>
                {
                    update_order_db(orders[currentIndex]);
                    l[currentIndex].Hide();
                    b[currentIndex].Hide();
                    MessageBox.Show("Order: "+ orders[currentIndex]+" Delivered");
                };

                panel1.Controls.Add(l[i]);
                panel1.Controls.Add(b[i]);

                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text ="Answer the questions";
            int i = 0;
            button1.Hide();
            button2.Hide();
            foreach (string q in questions)
            {
                int currentIndex = i; // Capture the current value of i
                l.Add(new Label());
                t.Add(new TextBox());
                b.Add(new Button());
                l[i].Text = "Question " + (i + 1).ToString() + ": " + q;
                l[i].Font = new Font("Arial", 12, FontStyle.Bold); // Adjust the font size as needed
                l[i].Show();
                l[i].AutoSize = true;
                t[i].Show();
                b[i].Show();
                if (i != 0)
                {
                    l[i].Location = new Point(0, l[i - 1].Bottom + 45);

                }
                else if (i == 0)
                {
                    l[i].Location = new Point(0, 0);
                }
                t[i].Location = new Point(0, l[i].Bottom + 5); // Adjust the vertical spacing as needed
                t[i].Width = 224;
                t[i].Text="Type your answer here";
                t[i].Click += (buttonSender, eventArgs) =>
                {
                    if (t[currentIndex].Text.Equals("Type your answer here"))
                    {
                        t[currentIndex].Clear();
                    }
                };
                b[i].Location = new Point(t[i].Right + 10, l[i].Bottom + 5);
                b[i].Text = "Submit";
                b[i].Click += (buttonSender, eventArgs) =>
                {
                    update_question_db(t[currentIndex].Text,questions[currentIndex]);
                    l[currentIndex].Hide();
                    t[currentIndex].Hide();
                    b[currentIndex].Hide();
                };

                panel1.Controls.Add(l[i]);
                panel1.Controls.Add(t[i]);
                panel1.Controls.Add(b[i]);

                i++;
            }

        }

        public void update_question_db(string answer, string question)
        {
            // Connection string
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string updateSql = "UPDATE Questions SET answer = @answer, status = 'answered' WHERE question = @question;";

                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        // Use parameters to avoid SQL injection and handle string values
                        command.Parameters.AddWithValue("@answer", answer);
                        command.Parameters.AddWithValue("@question", question);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Record not updated. No matching question found.");
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: {ex.Message}");
                }
            }
        }



        public void update_order_db(string order)
        {
            // Connection string
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string updateSql = "UPDATE Orders SET status = 'delivered' WHERE customer_order = @order;";

                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        // Use parameters to avoid SQL injection and handle string values
                        command.Parameters.AddWithValue("@order", order);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Record not updated. No matching question found.");
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: {ex.Message}");
                }
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP", button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
