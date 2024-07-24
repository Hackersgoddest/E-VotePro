using eVoting.classes;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Student student = new Student();
        Admin admin = new Admin();

        private void linkToSignUp_MouseClick(object sender, MouseEventArgs e)
        {
            crendentialFormTab.SelectedTab = signUp;
        }

        private void linkToSignIn_MouseClick(object sender, MouseEventArgs e)
        {
            crendentialFormTab.SelectedTab = signIn;
        }

        // clearing all input fields
        private void ClearInputs()
        {
            txtID.Text = String.Empty;
            txtPass.Text = String.Empty;
            txtStdID.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtStdPass.Text = String.Empty;
            txtProgram.Text = String.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            student = student.GetStudent(txtID.Text, txtPass.Text);
            admin = admin.GetAdmin(txtID.Text, txtPass.Text);
            if (student.StudentId != null)
            {
                ClearInputs();
                VotingPage votingPage = new VotingPage();
                votingPage.CurrentStudent = student;
                votingPage.FormClosed += new FormClosedEventHandler(VotingPage_FormClosed);
                this.Hide();
                votingPage.Show();
            }
            else if (admin.AdminId != null) 
            {
                ClearInputs();
                // switch to admin dashboard
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.FormClosed += new FormClosedEventHandler(AdminDashboard_FormClosed);
                this.Hide();
                adminDashboard.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            student.StudentId = txtStdID.Text;
            student.FullName = txtFullName.Text;
            student.Password = txtStdPass.Text;
            student.Programme = txtProgram.Text;
            if (student.InsertStudent(student))
            {
                ClearInputs();
                MessageBox.Show("Sign Up Successful");
                crendentialFormTab.SelectedTab = signIn;
            }
            else
            {
                MessageBox.Show("Sign Up Failed");
            }
        }
        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void VotingPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
