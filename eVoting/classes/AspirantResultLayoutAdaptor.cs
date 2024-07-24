using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace eVoting.classes
{
    internal class AspirantResultLayoutAdaptor
    {
        public Student CurrentStudent { get; set; }

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void ArrangeAspirants(GroupBox groupBox, List<AspirantResult> aspirants)
        {
            // Clear existing controls
            groupBox.Controls.Clear();

            int padding = 10;
            int panelHeight = 100;
            int yOffset = padding;

            foreach (var aspirant in aspirants)
            {
                // Create a Panel for each aspirant
                Panel aspirantPanel = new Panel
                {
                    Size = new Size(groupBox.Width - 20, panelHeight), // Full width of GroupBox minus padding
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(padding),
                    Location = new Point(padding, 20 + yOffset)
                };

                // PictureBox for aspirant's image
                PictureBox pictureBox = new PictureBox
                {
                    Image = aspirant.ResizeImage(aspirant.ByteArrayToImage(aspirant.ImageUri), 80, 80),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(80, 80), 
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(padding, padding)
                };

                // Labels for aspirant details
                Label lblId = new Label { Text = $"Candidate ID: {aspirant.CandidateId}", AutoSize = true, Location = new Point(100, padding) };
                Label lblName = new Label { Text = $"Name: {aspirant.FullName}", AutoSize = true, Location = new Point(100, padding + 20) };
                Label lblProgramme = new Label { Text = $"Programme: {aspirant.Programme}", AutoSize = true, Location = new Point(100, padding + 40) };
                Label lblVotes = new Label { Text = $"Votes: {aspirant.NumberOfVotes}", AutoSize = true, Location = new Point(100, padding + 60) };

                // Add controls to the aspirantPanel
                aspirantPanel.Controls.Add(pictureBox);
                aspirantPanel.Controls.Add(lblId);
                aspirantPanel.Controls.Add(lblName);
                aspirantPanel.Controls.Add(lblProgramme);
                aspirantPanel.Controls.Add(lblVotes);

                // Add aspirantPanel to GroupBox
                groupBox.Controls.Add(aspirantPanel);

                // Update yOffset for the next panel
                yOffset += panelHeight + padding;
            }
        }

        private void CenterTextBox(Panel panel, TextBox textBox)
        {
            // Ensure textBox and panel dimensions are valid
            if (textBox == null || panel == null) return;

            // Calculate new position for the TextBox
            int newX = (panel.ClientSize.Width - textBox.Width) / 2;
            int newY = (panel.ClientSize.Height - textBox.Height) / 2;

            // Set the location of the TextBox
            textBox.Location = new Point(newX, newY);
        }

        public void DisplayAspirants(Panel votingPanel, Dictionary<int, List<Aspirant>> groupedAspirants, int currentIndex)
        {
            // Clear existing controls
            votingPanel.Controls.Clear();

            int padding = 10;
            int panelHeight = 100;
            int yOffset = padding;

            // Ensure currentIndex is valid
            if (currentIndex >= groupedAspirants.Count)
            {
                // Create a TextBox for messages
                TextBox textBox = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.None,
                    Font = new Font("Casteller", 12, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    Width = votingPanel.Width - 200,
                    Height = 100,
                    BorderStyle = BorderStyle.None,
                };

                // Display no ongoing voting if current index is 0 else thank the user for taking the time to vote
                if (currentIndex == 0)
                {
                    textBox.Text = "No Voting is going on at the moment.";
                }
                else
                {
                    textBox.Text = "Thank you for taking the time to vote.";
                }

                // Add TextBox to the votingPanel
                votingPanel.Controls.Add(textBox);

                // Center the TextBox within the votingPanel
                CenterTextBox(votingPanel, textBox);
                return;
            }

            // Get the current group of aspirants
            var group = groupedAspirants.ElementAt(currentIndex);
            int titleId = group.Key;
            List<Aspirant> aspirants = group.Value;

            // Create a new GroupBox for each title group
            GroupBox groupBox = new GroupBox
            {
                Text = aspirants.First().GetTitleName(titleId), // Customize title as needed
                Dock = DockStyle.Top,
                AutoSize = true,
                Width = votingPanel.Width - 20, // Adjust width based on the panel
                Padding = new Padding(10),
                Margin = new Padding(5, 10, 5, 10),
                Name = $"groupBox_{titleId}"
            };

            foreach (var aspirant in aspirants)
            {
                // Create a Panel for each aspirant
                Panel aspirantPanel = new Panel
                {
                    Size = new Size(groupBox.Width - 20, panelHeight),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(padding),
                    Location = new Point(padding, yOffset + 10)
                };

                // PictureBox for aspirant's image
                PictureBox pictureBox = new PictureBox
                {
                    Image = aspirant.ResizeImage(aspirant.ByteArrayToImage(aspirant.ImageUri), 80, 80),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(80, 80),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(padding, padding)
                };

                // Labels for aspirant details
                Label lblId = new Label { Text = $"Candidate ID: {aspirant.CandidateId}", AutoSize = true, Location = new Point(100, padding) };
                Label lblName = new Label { Text = $"Name: {aspirant.FullName}", AutoSize = true, Location = new Point(100, padding + 20) };
                Label lblProgramme = new Label { Text = $"Programme: {aspirant.Programme}", AutoSize = true, Location = new Point(100, padding + 40) };

                // Add controls to the aspirantPanel
                aspirantPanel.Controls.Add(pictureBox);
                aspirantPanel.Controls.Add(lblId);
                aspirantPanel.Controls.Add(lblName);
                aspirantPanel.Controls.Add(lblProgramme);

                // Add aspirantPanel to GroupBox
                groupBox.Controls.Add(aspirantPanel);

                // Update yOffset for the next panel
                yOffset += panelHeight + padding;
            }

            // Create a FlowLayoutPanel to hold the RadioButtons
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown, // Change to LeftToRight for horizontal layout
                AutoSize = true,
                Location = new Point(20, 20),
                Padding = new Padding(10)
            };

            // Add RadioButtons for each aspirant
            foreach (var aspirant in aspirants)
            {
                RadioButton aspirantRadioButton = new RadioButton
                {
                    Text = aspirant.FullName,
                    AutoSize = true,
                    Tag = aspirant // Use the Tag property to store additional data if needed
                };

                // Add the RadioButton to the FlowLayoutPanel
                flowLayoutPanel.Controls.Add(aspirantRadioButton);
            }

            // Create a GroupBox for the RadioButtons
            GroupBox aspirantGroupBox = new GroupBox
            {
                Text = "Aspirants",
                AutoSize = true, // AutoSize the GroupBox based on its contents
                AutoSizeMode = AutoSizeMode.GrowAndShrink, // Allow the GroupBox to grow or shrink
                Location = new Point(20, yOffset + 20),
                Size = new Size(groupBox.Width - 40, 50) // Initial size, will adjust automatically
            };

            // Add the FlowLayoutPanel to the GroupBox
            aspirantGroupBox.Controls.Add(flowLayoutPanel);

            // Add the GroupBox to the main GroupBox
            groupBox.Controls.Add(aspirantGroupBox);

            // Add Submit and Skip buttons
            Button btnSubmit = new Button
            {
                Text = "Submit",
                ForeColor = Color.White,
                BackColor = Color.RoyalBlue,
                FlatStyle = FlatStyle.Flat,
                AutoSize = true,
                Location = new Point(20, aspirantGroupBox.Bottom + 20)
            };
            btnSubmit.Click += (sender, e) => SubmitVote(votingPanel, flowLayoutPanel, aspirants, currentIndex, groupedAspirants);

            Button btnSkip = new Button
            {
                Text = "Skip",
                ForeColor = Color.White,
                BackColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                AutoSize = true,
                Location = new Point(btnSubmit.Right + 20, aspirantGroupBox.Bottom + 20)
            };
            btnSkip.Click += (sender, e) => SkipGroup(votingPanel, currentIndex, groupedAspirants);

            groupBox.Controls.Add(btnSubmit);
            groupBox.Controls.Add(btnSkip);

            // Add GroupBox to resultsPanel (which is a FlowLayoutPanel)
            votingPanel.Controls.Add(groupBox);
        }

        private void SubmitVote(Panel votingPanel, FlowLayoutPanel flowLayoutPanel, List<Aspirant> aspirants, int currentIndex, Dictionary<int, List<Aspirant>> groupedAspirants)
        {
            // Ensure a radio button is selected
            var selectedRadioButton = flowLayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton != null)
            {
                var selectedAspirant = (Aspirant)selectedRadioButton.Tag;

                // Insert vote into the votings table
                if (!CheckIfAlreadyVoted(selectedAspirant)) InsertVote(selectedAspirant);
                else MessageBox.Show("You have already voted.");

                // Load the next group of aspirants
                LoadNextGroup(votingPanel, currentIndex + 1, groupedAspirants);
            }
            else
            {
                MessageBox.Show("Please select an aspirant.");
            }
        }

        private void SkipGroup(Panel votingPanel, int currentIndex, Dictionary<int, List<Aspirant>> groupedAspirants)
        {
            // Load the next group of aspirants
            LoadNextGroup(votingPanel, currentIndex + 1, groupedAspirants);
        }

        private void LoadNextGroup(Panel votingPanel, int nextIndex, Dictionary<int, List<Aspirant>> groupedAspirants)
        {
            DisplayAspirants(votingPanel, groupedAspirants, nextIndex);
        }

        private void InsertVote(Aspirant aspirant)
        {
           // insert vote into the votings table using simple try and catch

            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO votings (studentId, aspirantId, titleId) VALUES (@studentId, @aspirantId, @titleId)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentId", CurrentStudent.StudentId);
                cmd.Parameters.AddWithValue("@aspirantId", aspirant.Id);
                cmd.Parameters.AddWithValue("@titleId", aspirant.TitleId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Want to check if the user has cast vote already by checking the studentId, and the titleId in the votings table if it exist and the createdAt is the same, then we prompt the user that He or She has already cast vote.
        private bool CheckIfAlreadyVoted(Aspirant aspirant)
        {
            bool hasVoted = false;
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "SELECT * FROM votings WHERE studentId = @studentId AND titleId = @titleId AND DATE(createdAt) = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentId", CurrentStudent.StudentId);
                cmd.Parameters.AddWithValue("@titleId", aspirant.TitleId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    hasVoted = true;
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
            return hasVoted;
        }


    }
}
