using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace eVoting.classes
{
    internal class Aspirant
    {
        public int Id { get; set; }
        public string CandidateId { get; set; }
        public string FullName { get; set; }
        public string Programme { get; set; }
        public int TitleId { get; set; }
        public byte[] ImageUri { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Today;

        private readonly string connectionString = "server=localhost;port=3306;username=root;password=;database=e_voting";

        // Get all aspirants group by titleID
        public Dictionary<int, List<Aspirant>> GetAspirantsGroupedByTitleId()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            List<Aspirant> aspirants = new List<Aspirant>();
            try
            {
                con.Open();
                string query = "SELECT * FROM aspirants WHERE DATE(createdAt) = CURDATE() ORDER BY titleId ASC";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Aspirant aspirant = new Aspirant
                        {
                            Id = reader.GetInt32("id"),
                            CandidateId = reader.GetString("candidateId"),
                            FullName = reader.GetString("fullName"),
                            Programme = reader.GetString("programme"),
                            TitleId = reader.GetInt32("titleId"),
                            ImageUri = (byte[])reader["imageUri"],
                            CreatedAt = reader.GetDateTime("createdAt")
                        };
                        aspirants.Add(aspirant);
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

            // Group the aspirants by titleId using LINQ
            var groupedAspirants = aspirants
                .GroupBy(a => a.TitleId)
                .ToDictionary(g => g.Key, g => g.ToList());

            return groupedAspirants;
        }

        // Get title name from titleId
        public string GetTitleName(int titleId)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            string titleName = "";
            try
            {
                con.Open();
                string query = "SELECT name FROM titles WHERE titleId = @titleId";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@titleId", titleId);
                titleName = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return titleName;
        }


        // insert aspirant details into the aspirants table in the database
        public bool InsertAspirant(Aspirant aspirant)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            bool isInserted = false;
            try
            {
                con.Open();
                string query = "INSERT INTO aspirants (candidateId, fullName, programme, titleId, imageUri) VALUES (@candidateId, @fullName, @programme, @titleId, @imageUri)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@candidateId", aspirant.CandidateId);
                cmd.Parameters.AddWithValue("@fullName", aspirant.FullName);
                cmd.Parameters.AddWithValue("@programme", aspirant.Programme);
                cmd.Parameters.AddWithValue("@titleId", aspirant.TitleId);
                cmd.Parameters.AddWithValue("@imageUri", aspirant.ImageUri);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) isInserted = true;
                MessageBox.Show("Aspirant inserted successfully");
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

        // Get aspirants in a dataTable and before i save it in the datatable i want to use the titleId to retrieve the corresponding name in the titles table
        public DataTable GetAspirants()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            DataTable aspirants = new DataTable();
            try
            {
                con.Open();
                // SQL query to join aspirants with titles and select relevant columns
                string query = @"
            SELECT 
                a.id,
                a.candidateId,
                a.fullName,
                a.programme,
                t.name AS title,
                a.imageUri,
                a.createdAt
            FROM aspirants a
            JOIN titles t ON a.titleId = t.titleId
            WHERE DATE(a.createdAt) = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(aspirants);

                // Add a new column to the DataTable to store the images
                aspirants.Columns.Add("Image", typeof(Image));


                // Convert the imageUri byte array to Image and add it to the DataTable
                foreach (DataRow row in aspirants.Rows)
                {
                    byte[] imageBytes = (byte[])row["imageUri"];
                    Image image = ByteArrayToImage(imageBytes);
                    Image resizedImage = ResizeImage(image, 30, 30); // Resize the image to 50x50 pixels
                    row["Image"] = resizedImage;
                }

                // Remove the original imageUri column if it's not needed anymore
                aspirants.Columns.Remove("imageUri");

                // Rename the columns manually
                aspirants.Columns["id"].ColumnName = "ID";
                aspirants.Columns["candidateId"].ColumnName = "Candidate ID";
                aspirants.Columns["fullName"].ColumnName = "Full Name";
                aspirants.Columns["programme"].ColumnName = "Programme";
                aspirants.Columns["title"].ColumnName = "Title";
                aspirants.Columns["createdAt"].ColumnName = "Created At";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return aspirants;
        }

        // Update aspirant details in the aspirants table in the database
        public bool UpdateAspirant(Aspirant aspirant, Image imageUri)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            bool isUpdated = false;
            try
            {
                con.Open();
                aspirant.ImageUri = ImageToByteArray(imageUri);
                string query = "UPDATE aspirants SET candidateId = @candidateId, fullName = @fullName, programme = @programme, titleId = @titleId, imageUri = @imageUri WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@candidateId", aspirant.CandidateId);
                cmd.Parameters.AddWithValue("@fullName", aspirant.FullName);
                cmd.Parameters.AddWithValue("@programme", aspirant.Programme);
                cmd.Parameters.AddWithValue("@titleId", aspirant.TitleId);
                cmd.Parameters.AddWithValue("@imageUri", aspirant.ImageUri);
                cmd.Parameters.AddWithValue("@id", aspirant.Id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) isUpdated = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);
                isUpdated = false;
            }
            finally
            {
                con.Close();
            }
            return isUpdated;
        }

        // Convert image to byte array
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        // Convert byte array to image
        public Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // Method to resize the image
        public Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }
    }
}
