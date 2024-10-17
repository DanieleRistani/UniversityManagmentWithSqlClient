

namespace UniversityManagerWithDB.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Faculties
    {
        public long faculty_id { get; set; }
        public string faculty_name { get; set; }
        public string faculty_location { get; set; }

        public Faculties(string faculty_name, string faculty_location)
        {
            this.faculty_name = faculty_name;
            this.faculty_location = faculty_location;
        }

        public override string ToString()
        {
            return $"Faculty ID: {faculty_id} | Name: {faculty_name} | Location: {faculty_location}";
        }


    }
}
