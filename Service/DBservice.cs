
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
using UniversityManagerWithDB.Entity;

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

        public List<Faculties> GetFaculties()
        {
            List<Faculties> faculties = new List<Faculties>();
            string query = "SELECT * FROM Faculties";
            
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        faculties.Add(new Faculties(reader["faculty_name"].ToString(), reader["faculty_location"].ToString()));
                       
                    }
                }
            }
            _connection.Close();
            return faculties;
        }


        public List<Matters> GetMatters()
        {
            List<Matters> matters = new List<Matters>();
            string query = "SELECT * FROM Matters";

            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matters.Add(new Matters(reader["matter_code"].ToString(), reader["matter_name"].ToString(), int.Parse(reader["matter_faculty_id"].ToString())));

                    }
                }
            }
            _connection.Close();
            return matters;
        }


        public List<Students> GetStudents()
        {
            List<Students> students = new List<Students>();
            string query = "SELECT * FROM Students";

            _connection.Open();

            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Students(reader["student_mat"].ToString(),reader["student_name"].ToString(), reader["student_surname"].ToString(), int.Parse(reader["student_age"].ToString()), reader["student_gender"].ToString(), DateTime.Parse(reader["student_date_of_enrollment"].ToString()), int.Parse(reader["student_faculty_id"].ToString())));

                    }
                }
            }
            _connection.Close();    
            return students;
        }

        public List<Teachers> GetTeachers()
        {
            List<Teachers> teachers = new List<Teachers>();
            string query = "SELECT * FROM Teachers";

            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        teachers.Add(new Teachers(reader["teacher_code"].ToString(), int.Parse(reader["teacher_faculty_id"].ToString()), int.Parse(reader["teacher_matter_id"].ToString()), reader["teacher_role"].ToString(),reader["teacher_name"].ToString(), reader["teacher_surname"].ToString(), int.Parse(reader["teacher_age"].ToString()), reader["teacher_gender"].ToString()));
                    }
                }
            }
            _connection.Close();
            return teachers;
        }

        public List<Exames> GetExames()
        {
            List<Exames> exams = new List<Exames>();
            string query = "SELECT * FROM Exames";

            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        exams.Add(new Exames(reader["exame_code"].ToString(), int.Parse(reader["exame_teacher_id"].ToString()), int.Parse(reader["exame_student_id"].ToString()), DateTime.Parse(reader["exame_date"].ToString()), int.Parse(reader["exame_result"].ToString()), int.Parse(reader["exame_matter_id"].ToString())));

                    }
                }
            }
            _connection.Close();    
            return exams;
        }

        public List<Logs> GetLog()
        {
            List<Logs> logs = new List<Logs>();
            string query = "SELECT * FROM Logs";
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new Logs(reader["log_message"].ToString(), DateTime.Parse(reader["log_date"].ToString()), reader["log_error_place"].ToString()));

                    }
                }
            }
            _connection.Close();
            return logs;
        }
    }
        

}
