using eVoting.classes;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVoting
{
    public partial class VotingPage : Form
    {
        public VotingPage()
        {
            InitializeComponent();
        }
        public Student CurrentStudent { get; set; }
        Aspirant aspirant = new Aspirant();
        AspirantResultLayoutAdaptor aspirantResultLayoutAdaptor = new AspirantResultLayoutAdaptor();

        private void VotingPage_Load(object sender, EventArgs e)
        {
            LoadCandidates();
        }
        private void LoadCandidates()
        {
            try
            {
                // Clear existing controls
                votingPanel.Controls.Clear();

                // Retrieve aspirants grouped by TitleId
                var groupedAspirants = aspirant.GetAspirantsGroupedByTitleId();

                // Use the layout adapter to arrange aspirants within the GroupBox
                aspirantResultLayoutAdaptor.CurrentStudent = CurrentStudent;
                aspirantResultLayoutAdaptor.DisplayAspirants(votingPanel, groupedAspirants, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message);
            }
        }
    }
}
