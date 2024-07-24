using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace eVoting.classes
{
    internal class Admin
    {
        public string AdminId { get; set; }
        public string Password { get; set; }

        private readonly string connectionString = "server=localhost;user id=root;password=;database=e_voting";

        // Get admin from admins table
        // No use of hashpassword
        public Admin GetAdmin(string adminId, string password)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            Admin admin = new Admin();
            try
            {
                con.Open();
                string query = "SELECT * FROM admins WHERE adminId = @adminId AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@adminId", adminId);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    admin.AdminId = reader["adminId"].ToString();
                    admin.Password = reader["password"].ToString();
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
            return admin;
        }

    }
}
