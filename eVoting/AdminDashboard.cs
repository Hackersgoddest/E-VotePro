using eVoting.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace eVoting
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        Title title = new Title();
        Aspirant aspirant = new Aspirant();
        AspirantResult aspirantResult = new AspirantResult();
        AspirantResultLayoutAdaptor aspirantResultLayoutAdaptor = new AspirantResultLayoutAdaptor();
        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            title.Name = txtPosition.Text;
            if (String.IsNullOrEmpty(title.Name))
            {
                MessageBox.Show("Position cannot be empty");
            }
            else
            {
                if (title.InsertTitle(title))
                {
                    MessageBox.Show("Position added successfully");
                    // want to update the cmbPosition to show the newly added position
                    LoadPositions();
                    txtPosition.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add position");
                }
            }
        }

        // load cmbPosition
        private void LoadPositions()
        {
            cmbPosition.DataSource = title.GetTitles();
            cmbPosition.ValueMember = "titleId";
            cmbPosition.DisplayMember = "name";
            cmbPosition.SelectedIndex = -1;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadPositions();
            LoadCandidates();
            LoadResults();
        }


        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            // Initialize and configure the OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*",
                FilterIndex = 1, // Default to the first filter
                Title = "Select an Image File"
            };

            try
            {
                // Show the OpenFileDialog
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Check if the file size is less than or equal to 50MB
                    if (fileInfo.Length <= 50 * 1024 * 1024) // 50MB in bytes
                    {
                        // Validate the file extension
                        string[] validExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
                        string fileExtension = Path.GetExtension(filePath).ToLower();

                        if (validExtensions.Contains(fileExtension))
                        {
                            try
                            {
                                // Set PictureBox size mode to stretch the image
                                candidatePic.SizeMode = PictureBoxSizeMode.StretchImage;
                                // Load and display the image
                                candidatePic.Image = Image.FromFile(filePath);
                                btnUploadImg.Text = "Change Image";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error loading image: " + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid image file.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("File size exceeds the 50MB limit.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        private void btnDashClear_Click(object sender, EventArgs e)
        {
            // clear all input fields
            btnUploadImg.Text = "Upload Image";
            candidatePic.Image = null;
            txtCandidateId.Clear();
            txtFullName.Clear();
            txtProgramme.Clear();
            cmbPosition.SelectedIndex = -1;
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all candidate inputs and save them in the aspirants table
                aspirant.FullName = txtFullName.Text;
                aspirant.Programme = txtProgramme.Text;

                // Ensure the selected value is correctly cast to an integer
                if (cmbPosition.SelectedValue != null && int.TryParse(cmbPosition.SelectedValue.ToString(), out int titleId))
                {
                    aspirant.TitleId = titleId;
                }
                else
                {
                    MessageBox.Show("Please select a valid position.");
                    return;
                }

                aspirant.CandidateId = txtCandidateId.Text;

                // Convert image to byte array
                if (candidatePic.Image != null)
                {
                    aspirant.ImageUri = aspirant.ImageToByteArray(candidatePic.Image);
                }
                else
                {
                    MessageBox.Show("Please select a valid image.");
                    return;
                }

                // Insert the aspirant and load candidates
                if (aspirant.InsertAspirant(aspirant))
                {
                    btnDashClear.PerformClick();
                    LoadCandidates();
                    LoadResults();
                }
                else
                {
                    MessageBox.Show("Failed to add candidate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        // load dgvCandidates
        private void LoadCandidates()
        {
            try
            {
                dgvCandidates.DataSource = aspirant.GetAspirants();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading candidates: " + ex.Message);
            }
        }

        private void LoadResults()
        {
            try
            {
                // Clear existing controls
                resultsPanel.Controls.Clear();

                // Retrieve aspirants grouped by TitleId
                var groupedAspirants = aspirantResult.GetAspirantResultsGroupByTitle();

                foreach (var group in groupedAspirants)
                {
                    string title = group.Key;
                    List<AspirantResult> aspirants = group.Value;

                    // Create a new GroupBox for each title group
                    GroupBox groupBox = new GroupBox
                    {
                        Text = title, // Customize title as needed
                        Dock = DockStyle.Top,
                        AutoSize = true,
                        Width = 500,
                        Padding = new Padding(10),
                        Margin = new Padding(5, 10, 5, 10),
                        Name = $"groupBox_{title}"
                    };

                    // Use the layout adapter to arrange aspirants within the GroupBox
                    aspirantResultLayoutAdaptor.ArrangeAspirants(groupBox, aspirants);

                    // Add GroupBox to resultsPanel (which is a FlowLayoutPanel)
                    resultsPanel.Controls.Add(groupBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message);
            }
        }



    }
}
