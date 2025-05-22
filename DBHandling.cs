using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    class DBHandling
    {
        public DBHandling() { }

        public void UpdateRequest(string status, string name)
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateSql = "UPDATE Requests SET Status = @answer WHERE SongName = @name;";
                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@answer", status);
                        command.Parameters.AddWithValue("@name", name);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Record not updated. No matching rquest found.");
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


        public void SongRequest(Song s)
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"INSERT INTO Requests(SongName) VALUES (@song)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@song",  s.Title + ", by " + s.Artist);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Request sent successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Fail");
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

        public void AddQusetion(string name,string question)
        {
            //το question θα αποθηκευεται σε βαση
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO Questions(question,made_by) VALUES (@question,@name)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@question", question);
                        command.Parameters.AddWithValue("@name", name);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Question sent successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Record not inserted");
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

        public void AddOrder(string order)
        {

            //το question θα αποθηκευεται σε βαση
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO Orders(customer_order) VALUES (@order);";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@order", order);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order sent successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Record not inserted");
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




    }
   
}
