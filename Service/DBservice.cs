using OPP.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using University.Entity;

namespace University.Service
{
    public class DBservice
    {
        private SqlConnection _connection=new();
        private SqlCommand _command;
        public bool isConnected=false;
        public DBservice() 
        {
            try
            {
                _connection.ConnectionString = ConfigurationManager.AppSettings.Get("SqlConnectionString");
                _connection.Open();
                isConnected = true;

            }
            catch (Exception ex) 
            {
            
               Console.WriteLine(ex.Message);
                throw;

            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

           
        
        }

        public List<Faculty> GetFaculty()
        {
            List<Faculty> faculties = new List<Faculty>();
            string query = "SELECT * FROM Faculty";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        faculties.Add(new Faculty(reader["faculty_name"].ToString(), reader["faculty_location"].ToString()));
                       
                    }
                }
            }

            return faculties;
        }
        public List<Matter> GetMatter()
        {
            List<Matter> matters = new List<Matter>();
            string query = "SELECT * FROM Matter";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matters.Add(new Matter(reader["matter_code"].ToString(), reader["matter_name"].ToString(), reader["matter_faculty_name"].ToString()));
                        
                    }
                }
            }

            return matters;
        }


        public List<Student> GetStudent()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM Student";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student(reader["student_name"].ToString(), reader["student_surname"].ToString(), int.Parse(reader["student_age"].ToString()), reader["student_gender"].ToString(), reader["student_mat"].ToString(), reader["student_faculty_name"].ToString(), int.Parse(reader["student_year_of_registration"].ToString())));
                      
                    }
                }
            }

            return students;
        }

        public List<Teacher> GetTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();
            string query = "SELECT * FROM Teacher";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Matter matter=this.GetMatter().Find(m=>m.Name == reader["teacher_matter_name"].ToString());
                        TeacherRoleEnum role = reader["teacher_role"].ToString().StartsWith("A") ? TeacherRoleEnum.Assistant : TeacherRoleEnum.Teacher;
                        teachers.Add(new Teacher(reader["teacher_name"].ToString(), reader["teacher_surname"].ToString(), int.Parse(reader["teacher_age"].ToString()), reader["teacher_gender"].ToString(), reader["teacher_code"].ToString(), reader["teacher_faculty_name"].ToString(),matter,role));
                    }
                }
            }

            return teachers;
        }

        public List<Exam> GetExam()
        {
            List<Exam> exams = new List<Exam>();
            string query = "SELECT * FROM Exam";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Matter matter = this.GetMatter().Find(m => m.Name == reader["exame_matter_name"].ToString());

                        exams.Add(new Exam(reader["exame_code"].ToString(), matter, reader["exame_teacher_code"].ToString(), reader["exame_student_mat"].ToString(),DateTime.Parse(reader["exame_date"].ToString()), int.Parse(reader["exame_result"].ToString())));
                        
                    }
                }
            }

            return exams;
        }

        public List<Log> GetLog()
        {
            List<Log> logs = new List<Log>();
            string query = "SELECT * FROM Log";

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new Log(reader["log_message"].ToString(),DateTime.Parse(reader["log_date"].ToString()), reader["log_error_place"].ToString()));
                        
                    }
                }
            }

            return logs;
        }
    }
        

}
