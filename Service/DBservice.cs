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

namespace University.Service
{
    public class DBservice
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        public bool isConnected=false;
        public DBservice() 
        {
            try
            {
                _connection.ConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
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
                if (_connection.State==System.Data.ConnectionState.Open) 
                {
                
                _connection.Close();
                
                }
            }
        

        
        }
            public List<Student> GetStudents()
            {
             List<Student> students = [];
             Student student = new();

            try
            {
                _command = new SqlCommand($"SELECT * FROM Students");
                SqlDataReader dataReader = _command.ExecuteReader();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read()) 
                {
                    student.Name = dataReader["student_name"].ToString();
                    student.SureName = dataReader["student_surname"].ToString();
                    student.Gender = dataReader["student_gender"].ToString();
                    student.Age = int.Parse(dataReader["student_age"].ToString());
                    student.Matricola = dataReader["student_mat"].ToString();
                    student.AnnoDiIscrizione = int.Parse(dataReader["student_date_of_enviorment"].ToString());
                    student.Department = dataReader["student_faculty_id"].ToString();

                    students.Add(student);
                }
                students.ForEach(s=>Console.WriteLine(s.Name));
                
                return students;
            }
            catch
            {
                return students;
            }

            }
    }
        

}
