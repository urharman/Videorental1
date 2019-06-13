using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videorental
{
    public partial class Rented1 : Form
    {
        public Rented1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Rented1_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear(); //clear out old data in the listbox, we will need this later
                                     //load the connection string and pass it to the command
            string connectionString = @"Data Source=DESKTOP-U551NOV\SQLEXPRESS;Initial Catalog=Movie;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM RentedMovies ORDER by CustIDFK";
                //read in the data with a datareader open the data connection
                SqlCommand Command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    //add each row to the listbox
                    ListViewItem item = new ListViewItem(new[] {
reader["RMID"].ToString(), reader["MovieIDFK"].ToString(),
reader["CustIDFK"].ToString(), reader["DateRented"].ToString(),
reader["DateReturned"].ToString()
 });
                    listView1.Items.Add(item);
                }
                reader.Close();

            }
        }
    }
    }
