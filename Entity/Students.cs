

namespace UniversityManagerWithDB.Entity
{
    using System;
    using System.Collections.Generic;
   

    public partial class Students
    {
        public long student_id { get; set; }
        public string student_mat { get; set; }
        public string student_name { get; set; }
        public string student_surname { get; set; }
        public int student_age { get; set; }
        public string student_gender { get; set; }
        public DateTime student_date_of_enrollment { get; set; }
        public long student_faculty_id { get; set; }

        public Students() { }
        public Students(string student_mat, string student_name, string student_surname, int student_age, string student_gender, DateTime student_date_of_enrollment, long student_faculty_id)
        {
            this.student_mat = student_mat;
            this.student_name = student_name;
            this.student_surname = student_surname;
            this.student_age = student_age;
            this.student_gender = student_gender;
            this.student_date_of_enrollment = student_date_of_enrollment;
            this.student_faculty_id = student_faculty_id;
        }

        public override string ToString()
        {
            return $"Student ID: {student_id} | Matricola: {student_mat} | Name: {student_name} | " +
                   $"Surname: {student_surname} | Age: {student_age} | Gender: {student_gender} | " +
                   $"Date of Enrollment: {student_date_of_enrollment:yyyy-MM-dd} | Faculty ID: {student_faculty_id}";
        }


    }
}
