
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using University.Entity;
using University.Interface;
using UniversityManagerWithDB.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace University.Service
{
    public class DBservice
    {
        private SqlConnection _connection = new();
        private SqlCommand _command;
        public bool isConnected = false;


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
        public Faculties GetFacultiesById(long id)
        {

            string query = "SELECT * FROM Faculties WHERE faculty_id=@id";
            Faculties faculty = new();
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@id", id));
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        faculty = new Faculties(reader["faculty_name"].ToString(), reader["faculty_location"].ToString());

                    }
                }
            }
            _connection.Close();
            return faculty;

        }
        public bool AddFaculties(string faculty_name, string faculty_location)
        {
            try
            {


                string query = "INSERT INTO Faculties (faculty_name,faculty_location) VALUES (@f_name,@f_location)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@f_name", faculty_name.ToUpper()));
                    _command.Parameters.Add(new SqlParameter("@f_location", faculty_location));

                    _command.ExecuteNonQuery();

                }
                
                return true;


            }
            catch (Exception ex) 
            {

                
                ILog.AddNewLog(ex.Message,"AddFaculties");
                return false;
            
            }
            finally
            {
               
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public bool UpdateFaculties(long faculty_id,string faculty_name,string faculty_location)
        {

            try
            {


                string query = "UPDATE Faculties SET faculty_name = @f_name, faculty_location = @f_location WHERE faculty_id=@f_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@f_id", faculty_id));
                    _command.Parameters.Add(new SqlParameter("@f_name", faculty_name));
                    _command.Parameters.Add(new SqlParameter("@f_location", faculty_location));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "UpdateFaculties");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool DeleteFaculties(long faculty_id)
        {

            try
            {


                string query = "DELETE FROM Faculties WHERE faculty_id = @f_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@f_id", faculty_id));
                  
                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "DeleteFaculties");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

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
        public Matters GetMattersByCode(string code)
        {
            Matters matter = new();
            try
            {

                string query = "SELECT * FROM Matters WHERE matter_code=@code";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@code", code.ToUpper()));
                    int rowCount = (int)_command.ExecuteScalar();


                    using (var reader = _command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matter = new Matters(reader["matter_code"].ToString(), reader["matter_name"].ToString(), int.Parse(reader["matter_faculty_id"].ToString()));
                           
                        }
                    }

                    return matter;

                }
            }
            catch (Exception ex)
            {

                ILog.AddNewLog(ex.Message, "GetMatterBycode");
                return matter;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public Matters GetMattersById(long id)
        {
            string query = "SELECT * FROM Matters WHERE matter_id=@id";
            Matters matter = new();
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@id", id));
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matter = new Matters(reader["matter_code"].ToString(), reader["matter_name"].ToString(), int.Parse(reader["matter_faculty_id"].ToString()));

                    }
                }
            }
            _connection.Close();
            return matter;

        }
        public bool AddMatters(string matter_code,string matter_name,long matter_faculty_id)
        {
            try
            {


                string query = "INSERT INTO Matters (matter_code,matter_name,matter_faculty_id) VALUES (@m_code,@m_name,@m_faculty_id)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@m_code", matter_code.ToUpper()));
                    _command.Parameters.Add(new SqlParameter("@m_name", matter_name));
                    _command.Parameters.Add(new SqlParameter("@m_faculty_id", matter_faculty_id));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "AddMatters");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool UpdateMatters(long matter_id, string matter_name, long matter_faculty_id) 
        {
            try
            {


                string query = "UPDATE Matters SET matter_name = @m_name,matter_faculty_id = @m_faculty_id WHERE matter_id=@m_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@m_id", matter_id));
                    _command.Parameters.Add(new SqlParameter("@m_name", matter_name));
                    _command.Parameters.Add(new SqlParameter("@m_faculty_id", matter_faculty_id));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "UpdateMatters");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }


        }
        public bool DeleteMatters(long matter_id) 
        {
            try
            {


                string query = "DELETE FROM Matters WHERE matter_id = @m_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@m_id", matter_id));
                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "DeleteMatters");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

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
                        students.Add(new Students(reader["student_mat"].ToString(), reader["student_name"].ToString(), reader["student_surname"].ToString(), int.Parse(reader["student_age"].ToString()), reader["student_gender"].ToString(), DateTime.Parse(reader["student_date_of_enrollment"].ToString()), int.Parse(reader["student_faculty_id"].ToString())));

                    }
                }
            }
            _connection.Close();
            return students;
        }
        public Students GetStudentByMat(string mat)
        {

            Students student = new();

            try
            {

                string query = "SELECT * FROM Students WHERE student_mat=@mat";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@mat", mat.ToUpper()));
                    int rowCount = (int)_command.ExecuteScalar();




                    using (var reader = _command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student = new Students(reader["student_mat"].ToString(), reader["student_name"].ToString(), reader["student_surname"].ToString(), int.Parse(reader["student_age"].ToString()), reader["student_gender"].ToString(), DateTime.Parse(reader["student_date_of_enrollment"].ToString()), int.Parse(reader["student_faculty_id"].ToString()));

                        }
                    }
                 
                    return student;

                }



            }
            catch (Exception ex)
            {
                ILog.AddNewLog("Matricola non trovata", "GetStudentByMat");
                return student;
            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public Students GetStudentById(long id)
        {
            string query = "SELECT * FROM Students WHERE student_id=@id";
            Students student = new();
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@id", id));
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        student = new Students(reader["student_mat"].ToString(), reader["student_name"].ToString(), reader["student_surname"].ToString(), int.Parse(reader["student_age"].ToString()), reader["student_gender"].ToString(), DateTime.Parse(reader["student_date_of_enrollment"].ToString()), int.Parse(reader["student_faculty_id"].ToString()));


                    }
                }
            }
            _connection.Close();
            return student;

        }
        public bool AddStudents(string mat,string name,string surname,int age,string gender,DateTime date,long s_faculty_id)
        {

            try
            {

                string query = "INSERT INTO Students (student_mat,student_name,student_surname,student_age,student_gender,student_date_of_enrollment,student_faculty_id) VALUES (@s_mat, @s_name, @s_surname, @s_age, @s_gender, @s_date, @s_faculty_id)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@s_mat", mat.ToUpper()));
                    _command.Parameters.Add(new SqlParameter("@s_name",name));
                    _command.Parameters.Add(new SqlParameter("@s_surname", surname));
                    _command.Parameters.Add(new SqlParameter("@s_age", age));
                    _command.Parameters.Add(new SqlParameter("@s_gender", gender));
                    _command.Parameters.Add(new SqlParameter("@s_date",date));
                    _command.Parameters.Add(new SqlParameter("@s_faculty_id",s_faculty_id));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "AddStudents");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool UpdateStudents(long id,string name, string surname, int age, string gender, DateTime date, long s_faculty_id)
        {
            try
            {


                string query = "UPDATE Students SET student_name=@s_name,student_surname=@s_surname,student_age=@s_age,student_gender=@s_gender,student_date_of_enrollment=@s_date,student_faculty_id=@s_faculty_id WHERE student_id=@s_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@s_id", id));
                    _command.Parameters.Add(new SqlParameter("@s_name", name));
                    _command.Parameters.Add(new SqlParameter("@s_surname", surname));
                    _command.Parameters.Add(new SqlParameter("@s_age", age));
                    _command.Parameters.Add(new SqlParameter("@s_gender", gender));
                    _command.Parameters.Add(new SqlParameter("@s_date", date));
                    _command.Parameters.Add(new SqlParameter("@s_faculty_id", s_faculty_id));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "UpdateStudents");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool DeleteStudents(long id) 
        {
            try
            {


                string query = "DELETE FROM Students WHERE student_id = @s_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@s_id", id));
                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "DeleteStudents");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

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

                        teachers.Add(new Teachers(reader["teacher_code"].ToString(), int.Parse(reader["teacher_faculty_id"].ToString()), int.Parse(reader["teacher_matter_id"].ToString()), reader["teacher_role"].ToString(), reader["teacher_name"].ToString(), reader["teacher_surname"].ToString(), int.Parse(reader["teacher_age"].ToString()), reader["teacher_gender"].ToString()));
                    }
                }
            }
            _connection.Close();
            return teachers;
        }
        public Teachers GetTeachersByCode(string code)
        {

            Teachers teacher = new();
            try
            {

            string query = "SELECT * FROM Teacher WHERE teacher_code=@code";
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@code", code.ToUpper()));
                int rowCount = (int)_command.ExecuteScalar();


                    using (var reader = _command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teacher = new Teachers(reader["teacher_code"].ToString(), int.Parse(reader["teacher_faculty_id"].ToString()), int.Parse(reader["teacher_matter_id"].ToString()), reader["teacher_role"].ToString(), reader["teacher_name"].ToString(), reader["teacher_surname"].ToString(), int.Parse(reader["teacher_age"].ToString()), reader["teacher_gender"].ToString());

                        }
                    }
                   
                    return teacher;   
                
            }
            }
            catch (Exception ex) 
            { 
            
                    ILog.AddNewLog(ex.Message, "GetTeacherBycode");
                    return teacher;
            
            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public Teachers GetTeachersById(long id)
        {
            string query = "SELECT * FROM Teachers WHERE teacher_id=@id";
            Teachers teacher = new();
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@id", id));
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        teacher = new Teachers(reader["teacher_code"].ToString(), int.Parse(reader["teacher_faculty_id"].ToString()), int.Parse(reader["teacher_matter_id"].ToString()), reader["teacher_role"].ToString(), reader["teacher_name"].ToString(), reader["teacher_surname"].ToString(), int.Parse(reader["teacher_age"].ToString()), reader["teacher_gender"].ToString());



                    }
                }
            }
            _connection.Close();
            return teacher;

        }
        public bool AddTeachers(string t_code,long t_faculty_id,long t_matter_id,string t_role,string t_name,string t_surname,int t_age,string t_gender)
        {

            try
            {

                string query = "INSERT INTO Teachers (teacher_code,teacher_matter_id,teacher_faculty_id,teacher_role,teacher_name,teacher_surname,teacher_age,teacher_gender) VALUES (@t_code, @t_matter_id, @t_faculty_id, @t_role, @t_name, @t_surname, @t_age, @t_gender)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@t_code", t_code.ToUpper()));
                    _command.Parameters.Add(new SqlParameter("@t_role",t_role));
                    _command.Parameters.Add(new SqlParameter("@t_name",t_name));
                    _command.Parameters.Add(new SqlParameter("@t_surname", t_surname));
                    _command.Parameters.Add(new SqlParameter("@t_age", t_age));
                    _command.Parameters.Add(new SqlParameter("@t_gender", t_gender));
                    _command.Parameters.Add(new SqlParameter("@t_matter_id", t_matter_id));
                    _command.Parameters.Add(new SqlParameter("@t_faculty_id", t_faculty_id));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "AddTeachers");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public bool UpdateTeachers(long t_id ,long t_faculty_id, long t_matter_id, string t_role, string t_name, string t_surname, int t_age, string t_gender)
        {

            try
            {


                string query = "UPDATE Teachers SET teacher_role = @t_role, teacher_name = @t_name, teacher_surname = @t_surname, teacher_age = @t_age, teacher_gender = @t_gender, teacher_matter_id = @t_matter_id, teacher_faculty_id = @t_faculty_id WHERE teacher_id = @t_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@t_id",t_id));
                    _command.Parameters.Add(new SqlParameter("@t_role", t_role));
                    _command.Parameters.Add(new SqlParameter("@t_name", t_name));
                    _command.Parameters.Add(new SqlParameter("@t_surname", t_surname));
                    _command.Parameters.Add(new SqlParameter("@t_age", t_age));
                    _command.Parameters.Add(new SqlParameter("@t_gender", t_gender));
                    _command.Parameters.Add(new SqlParameter("@t_matter_id", t_matter_id));
                    _command.Parameters.Add(new SqlParameter("@t_faculty_id", t_faculty_id));


                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "UpdateTeachers");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool DeleteTeachers(long t_id)
        {
            try
            {


                string query = "DELETE FROM Teachers WHERE teacher_id = @t_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@t_id", t_id));
                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "DeleteTeachers");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
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
        public Exames GetByExamesCode(string code)
        {
            Exames exame = new();
            try
            {

                string query = "SELECT * FROM Exames WHERE exame_code=@code";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@code", code.ToUpper()));
                    int rowCount = (int)_command.ExecuteScalar();




                    using (var reader = _command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exame = new Exames(reader["exame_code"].ToString(), int.Parse(reader["exame_teacher_id"].ToString()), int.Parse(reader["exame_student_id"].ToString()), DateTime.Parse(reader["exame_date"].ToString()), int.Parse(reader["exame_result"].ToString()), int.Parse(reader["exame_matter_id"].ToString()));

                        }
                    }

                    return exame;




                }

            }
            catch (Exception ex) 
            {

                ILog.AddNewLog(ex.Message, "GetExameBycode");
                return exame;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            





        }
        public Exames GetById(long id)
        {
            string query = "SELECT * FROM Exames WHERE exame_id=@id";
            Exames exame = new();
            _connection.Open();
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add(new SqlParameter("@id", id));
                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        exame = new Exames(reader["exame_code"].ToString(), int.Parse(reader["exame_teacher_id"].ToString()), int.Parse(reader["exame_student_id"].ToString()), DateTime.Parse(reader["exame_date"].ToString()), int.Parse(reader["exame_result"].ToString()), int.Parse(reader["exame_matter_id"].ToString()));

                    }
                }
            }
            _connection.Close();
            return exame;


        }
        public bool AddExames(string e_code,long e_teacher_id,long e_student_id,DateTime e_date,int e_result)
        {

            try
            {

                string query = "INSERT INTO Exames (exame_code,exame_teacher_id,exame_student_id,exame_date,exame_result) VALUES (@e_code, @e_teacher_id, @e_student_id, @e_date, @e_result)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@e_code", e_code.ToUpper()));
                    _command.Parameters.Add(new SqlParameter("@e_teacher_id", e_teacher_id));
                    _command.Parameters.Add(new SqlParameter("@e_student_id", e_student_id));
                    _command.Parameters.Add(new SqlParameter("@e_date", e_date));
                    _command.Parameters.Add(new SqlParameter("@e_result", e_result));
                    

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "AddExames");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
        public bool UpdateExames(long e_id, long e_teacher_id, long e_student_id, DateTime e_date, int e_result)
        {
            try
            {

                string query = "UPDATE Exames SET exame_code = @e_code,exame_teacher_id = @e_teacher_id, exame_student_id = @e_student_id, exame_date = @e_date, exame_result = @e_result WHERE exame_id=@e_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@e_id", e_id));
                    _command.Parameters.Add(new SqlParameter("@e_teacher_id", e_teacher_id));
                    _command.Parameters.Add(new SqlParameter("@e_student_id", e_student_id));
                    _command.Parameters.Add(new SqlParameter("@e_date", e_date));
                    _command.Parameters.Add(new SqlParameter("@e_result", e_result));


                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "UpdateExames");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }



        }
        public bool DeleteExames(long e_id) 
        {
            try
            {


                string query = "DELETE FROM Exames WHERE exame_id = @e_id";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@e_id", e_id));
                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "DeleteExames");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }


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
        public bool AddLogs(string l_message,string l_error_place)
        {
            try
            {


                string query = "INSERT INTO Logs (log_message,log_date,log_error_place) VALUES (@l_message,@l_date,@l_error_place)";
                _connection.Open();
                using (_command = new SqlCommand(query, _connection))
                {
                    _command.Parameters.Add(new SqlParameter("@l_message",l_message ));
                    _command.Parameters.Add(new SqlParameter("@l_date", DateTime.Now));
                    _command.Parameters.Add(new SqlParameter("@l_error_place", l_error_place));

                    _command.ExecuteNonQuery();

                }

                return true;


            }
            catch (Exception ex)
            {


                ILog.AddNewLog(ex.Message, "AddLogs");
                return false;

            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }




    } 
}
