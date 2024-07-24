using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVoting.classes
{
    internal class AspirantResult : Aspirant
    {
        public int NumberOfVotes { get; set; }
        public string Title { get; set; }

        private readonly string connectionString = "server=localhost;port=3306;username=root;password=;database=e_voting";


        public Dictionary<string, List<AspirantResult>> GetAspirantResultsGroupByTitle()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            List<AspirantResult> aspirants = new List<AspirantResult>();
            try
            {
                con.Open();
                // want to use the name from the titles table to group so i need to join the aspirants table with the titles table and also count the number of votes for each aspirant
                string query = @"
                    SELECT
                        a.id,
                        t.name AS title,
                        a.candidateId,
                        a.fullName,
                        a.programme,
                        a.titleId,
                        a.imageUri,
                        a.createdAt,
                        COUNT(v.aspirantId) AS numberOfVotes
                    FROM aspirants a
                    JOIN titles t ON a.titleId = t.titleId
                    LEFT JOIN votings v ON a.id = v.aspirantId
                    WHERE DATE(a.createdAt) = CURDATE()
                    GROUP BY a.id
                    ORDER BY a.titleId DESC
                ";
                
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AspirantResult aspirant = new AspirantResult
                        {
                            Id = reader.GetInt32("id"),
                            Title = reader.GetString("title"),
                            CandidateId = reader.GetString("candidateId"),
                            FullName = reader.GetString("fullName"),
                            Programme = reader.GetString("programme"),
                            TitleId = reader.GetInt32("titleId"),
                            ImageUri = (byte[])reader["imageUri"],
                            CreatedAt = reader.GetDateTime("createdAt"),
                            NumberOfVotes = reader.GetInt32("numberOfVotes"),
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
                .GroupBy(a => a.Title)
                .ToDictionary(g => g.Key, g => g.ToList());

            return groupedAspirants;
        }
    }
}
