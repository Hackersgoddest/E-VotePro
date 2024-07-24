using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace eVoting.classes
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Programme { get; set; }
        // database connection string
        private readonly string connectionString = "server=localhost;database=e_voting;uid=root;pwd=;";

        // Hashing password
        public string HashPassword(string password)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }




        // Get student from the students table using his studentId and password
        public Student GetStudent(string studentId, string password)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            Student student = new Student();
            try
            {
                con.Open();
                password = HashPassword(password);
                string query = "SELECT * FROM students WHERE studentId = @studentId AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    student.StudentId = reader["studentId"].ToString();
                    student.FullName = reader["fullName"].ToString();
                    student.Password = reader["password"].ToString();
                    student.Programme = reader["programme"].ToString();
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
            return student;
        }

        // insert student details into the students table in the database
        public bool InsertStudent(Student student)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            bool isInserted = false;
            try
            {
                con.Open();
                student.Password = HashPassword(student.Password);
                string query = "INSERT INTO students (studentId, password, fullName, programme) VALUES (@studentId, @password, @fullName, @programme)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentId", student.StudentId);
                cmd.Parameters.AddWithValue("@password", student.Password);
                cmd.Parameters.AddWithValue("@fullName", student.FullName);
                cmd.Parameters.AddWithValue("@programme", student.Programme);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)  isInserted = true;
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
