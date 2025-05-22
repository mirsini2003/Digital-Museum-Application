using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_alilepidrasi
{
    public partial class DigitalDJ : Form
    {
        string role;
        DBHandling db = new DBHandling();
        private User user;
        private int queue = 0;


        Song dont_stop;
        Song no_satisfacion;
        Song hold_your_hand;
        Song last_christmas;
        Song another_brick;
        Song[] songs = new Song[5];

        int song_queue = 0;
        int tick_num = 0;
        private string colors ="Deafault";
        int[] ticks = { 212,234,145,263,229};
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public int Song_queue { get => song_queue; set => song_queue = value; }
        public int Tick_num { get => tick_num; set => tick_num = value; }
        public User User { get => user; set => user = value; }
        public int Queue { get => queue; set => queue = value; }

        public DigitalDJ(User user)
        {
            InitializeComponent();
            dont_stop = new Song("Dont stop me now", "Queen", "rock", 3.32f, 1979, 156, find_song_Directory("Queen - Don't Stop Me Now (Official Video).mp3"));
            no_satisfacion = new Song("I Cant Get No Satisfaction", "The Rolling Stones", "rock", 3.54f, 1965, 136, find_song_Directory("The Rolling Stones - (I Can't Get No) Satisfaction (Official Lyric Video).mp3"));
            hold_your_hand = new Song("I want to hold your hand", "the beatles", "rock", 2.25f, 1963, 131, find_song_Directory("I Want To Hold Your Hand (Remastered 2015).mp3"));
            last_christmas = new Song("Last Christmas", "Wham!", "Pop", 4.23f, 1984, 108, find_song_Directory("Wham! - Last Christmas (Lyrics)_From_ytmp3-ch.mp3"));
            another_brick = new Song("Another Brick in the wall", "Pink Floyd", "rock", 3.49f, 1979, 99, find_song_Directory("pink floyd - another brick in the wall.mp3"));
            
            //MessageBox.Show(Directory.GetCurrentDirectory());
            colors ="Deafault";
            lastChristmasByWhamToolStripMenuItem.Visible = false;
            sTOPPLAYINGToolStripMenuItem.Visible = false;
            this.role = user.Role;
            this.User = user;
            label6.Hide();
            sTOPSONGToolStripMenuItem.Visible = false;
            if (role.Equals("admin"))
            {
                menuStrip1.Hide();
            }
            else if (role.Equals("client"))
            {
                menuStrip2.Hide();
                groupBox1.Hide();
            }
            
            timer1.Enabled = false;
            songs[0] = dont_stop;
            songs[1] = no_satisfacion;
            songs[2] = hold_your_hand;
            songs[3] = last_christmas;
            songs[4] = another_brick;
            label1.Text = songs[0].Title;
            label2.Text = songs[1].Title;
            label3.Text = songs[2].Title;
            label4.Text = songs[3].Title;
            label5.Text = songs[4].Title;
           
        }

       

        private void DigitalDJ_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void gOBACKTOMENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuForm(User).Show();
            player.controls.stop();

        }

        private void gOTOMENUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuForm(role).Show();
            player.controls.stop();
        }

        private void DigitalDJ_Load(object sender, EventArgs e)
        {
            //kodikas gia ta requests
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";
            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT SongName FROM Requests WHERE Status ='pending';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                string song = reader.GetString(reader.GetOrdinal("SongName"));
                                rEQUESTSToolStripMenuItem.DropDownItems.Add("Please play "+ song );
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
          
            foreach (ToolStripMenuItem d in rEQUESTSToolStripMenuItem.DropDownItems) {
                d.DropDownItems.Add("Accept").Click+=(listsender, eventArgs) => 
                {
                   string[] s= d.Text.Split(',');
                    s[0] = s[0].Substring("Please play ".Length).Trim();
                    if (s[0].Equals(songs[0].Title, StringComparison.OrdinalIgnoreCase))
                    {
                        player.URL = songs[0].Url;
                        player.controls.play();
                        //accept request
                        db.UpdateRequest("accepted", d.Text.Substring("Please play ".Length).Trim());
                        d.Visible = false;
                        sTOPPLAYINGToolStripMenuItem.Visible = true;
                    }
                    else if (s[0].Equals(songs[1].Title, StringComparison.OrdinalIgnoreCase))
                    {
                        player.URL = songs[1].Url;
                        player.controls.play();
                        //accept request
                        db.UpdateRequest("accepted", d.Text.Substring("Please play ".Length).Trim());
                        d.Visible = false;
                        sTOPPLAYINGToolStripMenuItem.Visible = true;
                    }
                    else if (s[0].Equals(songs[2].Title, StringComparison.OrdinalIgnoreCase))
                    {
                        player.URL = songs[2].Url;
                        player.controls.play();
                        //accept request
                        db.UpdateRequest("accepted", d.Text.Substring("Please play ".Length).Trim());
                        d.Visible = false;
                        sTOPPLAYINGToolStripMenuItem.Visible = true;
                    }
                    else if (s[0].Equals(songs[3].Title, StringComparison.OrdinalIgnoreCase))
                    {
                        player.URL = songs[3].Url;
                        player.controls.play();
                        //accept request
                        db.UpdateRequest("accepted", d.Text.Substring("Please play ".Length).Trim());
                        d.Visible = false;
                        sTOPPLAYINGToolStripMenuItem.Visible = true;
                    }
                    else if (s[0].Equals(songs[4].Title, StringComparison.OrdinalIgnoreCase))
                    {
                        player.URL = songs[4].Url;
                        player.controls.play();
                        //accept request
                        db.UpdateRequest("accepted", d.Text.Substring("Please play ".Length).Trim());
                        d.Visible = false;
                        sTOPPLAYINGToolStripMenuItem.Visible = true;
                    }
                };
                d.DropDownItems.Add("Deny").Click+=(listsender,eventArgs)=> 
                {
                    //deny in db
                    db.UpdateRequest("denied", d.Text.Substring("Please play ".Length).Trim());
                    d.Visible = false;
                };
            }
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT BackColor FROM Backup WHERE Username = @name;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", User.Name);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Access data using column names or indices
                                string c = reader.GetString(reader.GetOrdinal("BackColor"));

                                switch (c)
                                {
                                    case "Red":
                                        this.BackColor = Color.FromArgb(174, 18, 18);
                                        break;
                                    case "Yellow":
                                        this.BackColor = Color.Yellow;
                                        break;
                                    case "Green":
                                        this.BackColor = Color.Lime;
                                        break;
                                    case "Blue":
                                        this.BackColor = Color.CornflowerBlue;
                                        break;
                                    case "Pink":
                                        this.BackColor = Color.FromArgb(255, 128, 255);
                                        break;
                                    case "Purple":
                                        this.BackColor = Color.DarkOrchid;
                                        break;
                                    case "White":
                                        this.BackColor = Color.White;
                                        break;
                                    default:
                                        break;
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

        private void sTOPSONGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            sTOPSONGToolStripMenuItem.Visible = false;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(174, 18, 18);
            colors ="Red";
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            colors ="Yellow";
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Lime;
            colors ="Green";
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
            colors ="Blue";
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 128, 255);
            colors ="Pink";
        }

        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrchid;
            colors = "Purple";
        }

        private void iWantToHoldYourHandTheBeatlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(hold_your_hand.Url);
            sTOPSONGToolStripMenuItem.Visible = true;      
            player.URL = hold_your_hand.Url;
            player.controls.play();
        }

        private void anotherBrickInTheWallPinkFloydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sTOPSONGToolStripMenuItem.Visible = true;
            player.URL = another_brick.Url;
            player.controls.play();
        }

        private void dontStopMeNowQueenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sTOPSONGToolStripMenuItem.Visible = true;
            player.URL =dont_stop.Url;
            player.controls.play();
        }
        private void stisfactionTheRollingStonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sTOPSONGToolStripMenuItem.Visible=true;
            player.URL = no_satisfacion.Url;
            player.controls.play();
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void eidos1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastChristmasByWhamToolStripMenuItem.Visible = false;
            iWantToHoldYourHandTheBeatlesToolStripMenuItem.Visible = true;
            anotherBrickInTheWallPinkFloydToolStripMenuItem.Visible = true;
            dontStopMeNowQueenToolStripMenuItem.Visible = true;
            satisfactionTheRollingStonesToolStripMenuItem.Visible = true;
        }

        private void eido2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastChristmasByWhamToolStripMenuItem.Visible = true;
            iWantToHoldYourHandTheBeatlesToolStripMenuItem.Visible = false;
            anotherBrickInTheWallPinkFloydToolStripMenuItem.Visible = false;
            dontStopMeNowQueenToolStripMenuItem.Visible = false;
            satisfactionTheRollingStonesToolStripMenuItem.Visible = false;
        }

        private void lastChristmasByWhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sTOPSONGToolStripMenuItem.Visible = true;
            player.URL =last_christmas.Url;
            player.controls.play();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuForm(User).Show();
            player.controls.stop();
        }

        private void fasterSongsFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = songs[0].Title;
            label2.Text = songs[1].Title;
            label3.Text = songs[2].Title;
            label4.Text = songs[3].Title;
            label5.Text = songs[4].Title;
            Queue = 0;
            player.controls.stop();
        }

        private void slowerSongsFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = songs[4].Title;
            label2.Text = songs[3].Title;
            label3.Text = songs[2].Title;
            label4.Text = songs[1].Title;
            label5.Text = songs[0].Title;
            Queue = 1;
            player.controls.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tick_num ++;
            if (Queue == 0)
            {
                if (Tick_num == ticks[Song_queue])
                {
                    Tick_num = 0;
                    if (Song_queue == 3) { Song_queue = 0; }
                    else { Song_queue++; }
                    player.URL = songs[Song_queue].Url;
                    player.controls.play();
                    label6.Text ="Now Playing: "+songs[Song_queue].Title+" by: "+ songs[Song_queue].Artist;
                }
            }
            else if (Queue == 1)
            {
                if (Tick_num == ticks[Song_queue])
                {
                    Tick_num = 0;
                    if (Song_queue == 0) { Song_queue = 4; }
                    else { Song_queue--; }
                    player.URL = songs[Song_queue].Url;
                    player.controls.play();
                    label6.Text = "Now Playing: " + songs[Song_queue].Title + " by: " + songs[Song_queue].Artist;
                }
            }
        }

        private void playSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Queue == 0) { Song_queue = 0; }
            else if (Queue == 1) { Song_queue = 4; }
            player.URL = songs[Song_queue].Url;
            player.controls.play();
            timer1.Enabled=true;
            Tick_num = 0;
            sTOPPLAYINGToolStripMenuItem.Visible = true;
            label6.Show();
            label6.Text = "Now Playing: " + songs[Song_queue].Title + " by: " + songs[Song_queue].Artist;
        }

        private void eidos3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastChristmasByWhamToolStripMenuItem.Visible = true;
            iWantToHoldYourHandTheBeatlesToolStripMenuItem.Visible = true;
            anotherBrickInTheWallPinkFloydToolStripMenuItem.Visible = true;
            dontStopMeNowQueenToolStripMenuItem.Visible = true;
            satisfactionTheRollingStonesToolStripMenuItem.Visible = true;
        }

        private void sTOPPLAYINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            timer1.Enabled = false;
            Song_queue = 0;
            Tick_num = 0;
            sTOPPLAYINGToolStripMenuItem.Visible = false;
        }

        private void lastChristmasFromWhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SongRequest(last_christmas);
        }

        private void satisfactionByTheRollingStonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SongRequest(no_satisfacion);
        }

        private void anotherBrickInTheWallByPinkFloydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SongRequest(another_brick);
        }

        private void dontStopMeNowByQueenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SongRequest(dont_stop);
        }

        private void iWantToHoldYourHandByTheBeatlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SongRequest(hold_your_hand);
        }

        private void sECURITYCOPYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string updateSql = "UPDATE Backup SET BackColor = @color WHERE Username = @name;";

                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        // Use parameters to avoid SQL injection and handle string values
                        command.Parameters.AddWithValue("@color", colors);
                        command.Parameters.AddWithValue("@name", User.Name);

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

        private void sECURITYCOPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=..\\..\\db\\Erg_AYY.v1.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string updateSql = "UPDATE Backup SET BackColor = @color WHERE Username = @name;";

                    using (SQLiteCommand command = new SQLiteCommand(updateSql, connection))
                    {
                        // Use parameters to avoid SQL injection and handle string values
                        command.Parameters.AddWithValue("@color", colors);
                        command.Parameters.AddWithValue("@name", User.Name);

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

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor =Color.White;
            colors = "White";
        }

        public string find_song_Directory(string filename)
        {
            return Path.Combine(Directory.GetCurrentDirectory(),"resources_bin","music", filename);
            //return Path.Combine(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), ".."),".."),"Resources",filename);
            

        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));
        }

        private void sHOWHELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, Path.Combine("resources_bin", "help", "ergasia_allilepidrasis_help.html")));

        }

        private void kARAOKEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Karaoke().Show();
        }
    }
}
