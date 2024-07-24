using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace eVoting.classes
{
    internal class Title
    {
        public string TitleId { get; set; }
        public string Name { get; set; }
        // connection string
        private readonly string connectionString = "server=localhost;user=root;database=e_voting;port=3306;password=";

        // Get all titles from the titles table
        public List<Title> GetTitles()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            List<Title> titles = new List<Title>();
            try
            {
                con.Open();
                string query = "SELECT * FROM titles";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Title title = new Title();
                        title.TitleId = reader["titleId"].ToString();
                        title.Name = reader["name"].ToString();
                        titles.Add(title);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return titles;
        }

        // insert title into titles table in the database
        public bool InsertTitle(Title title)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            bool isInserted = false;
            try
            {
                con.Open();
                string query = "INSERT INTO titles (name) VALUES (@name)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", title.Name);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) isInserted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isInserted = false;
            }
            finally
            {
                con.Close();
            }
            return isInserted;
        }
    }
}
