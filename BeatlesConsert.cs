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
    public partial class BeatlesConsert : Form
    {

        private Panel[] seats = new Panel[30];
        char[] seat_status = new char[30];
       
        public BeatlesConsert()
        {

            InitializeComponent();
            seats[0]=panel1;
            seats[1]=panel2;
            seats[2]=panel3;
            seats[3]=panel4;
            seats[4]=panel5;
            seats[5]=panel6;
            seats[6]=panel7;
            seats[7]=panel8;
            seats[8]=panel9;
            seats[9]=panel10;
            seats[10] = panel11;
            seats[11] = panel12;
            seats[12] = panel13;
            seats[13] = panel14;
            seats[14] = panel15;
            seats[15] = panel16;
            seats[16] = panel17;
            seats[17] = panel18;
            seats[18] = panel19;
            seats[19] = panel20;
            seats[20] = panel21;
            seats[21] = panel22;
            seats[22] = panel23;
            seats[23] = panel24;
            seats[24] = panel25;
            seats[25] = panel26;
            seats[26] = panel27;
            seats[27] = panel28;
            seats[28] = panel29;
            seats[29] = panel30;


          
            get_initial_data_db();

            for (int i = 0; i < 30; i++)
            {
                if (seat_status[i] == 's')
                {
                    seats[i].BackColor = Color.Red;
                }
                else
                {
                    seats[i].BackColor = Color.Green;
                }
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            // Handle the panel click event
            Panel clickedPanel = sender as Panel;
            for(int i = 0;i < seats.Length;i++) 
            {
                if ((seats[i] == clickedPanel) && (seat_status[i]=='f'))
                {
                    seat_status[i] ='p';
                    seats[i].BackColor = Color.Yellow;
                }
                else if ((seats[i] == clickedPanel) && (seat_status[i] == 'p'))
                {
                    seat_status[i] = 'f';
                    seats[i].BackColor = Color.Green;
                }
                else if ((seats[i] == clickedPanel) && (seat_status[i] == 's'))
                {
                    MessageBox.Show("This Seat is Taken");
                }
            }
        }

        private void r_button_Click(object sender, EventArgs e)
        {
            int quantity =0 ;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seat_status[i] == 'p')
                {
                    quantity++;
                }
            }
            int cost = quantity * 5;

            DialogResult result = MessageBox.Show($"Do you want to proceed?\nPrice:{cost}$", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < seats.Length; i++)
                {
                    if (seat_status[i] == 'p')
                    {
                        seat_status[i] = 's';
                        update_db('s', i);
                        seats[i].BackColor = Color.Red;
                    }
                }
           
            }
        }

        private void b_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ConsertsForm().Show();
        }

        public void update_db(char new_seat_status,int seat_id)
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

                    string updateSql = $"UPDATE Beatles_concert SET seat_status = '{new_seat_status}' WHERE seat_id = {seat_id};";

                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }
            }
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

                    string query = $"SELECT seat_id, seat_status FROM Beatles_concert;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                int seat_id_db = reader.GetInt32(reader.GetOrdinal("seat_id"));
                                char seat_status_db = char.Parse(reader.GetString(reader.GetOrdinal("seat_status")));
                                seat_status[seat_id_db] = seat_status_db;
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

        private void BeatlesConsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void r_button_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void r_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void b_button_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void b_button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            new ToolTip().Show("ONLINE HELP",button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
