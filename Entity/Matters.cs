

namespace UniversityManagerWithDB.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matters
    {
       
        public long matter_id { get; set; }
        public string matter_code { get; set; }
        public string matter_name { get; set; }
        public long matter_faculty_id { get; set; }
        public Matters(string matter_code, string matter_name, long matter_faculty_id)
        {
            this.matter_code = matter_code;
            this.matter_name = matter_name;
            this.matter_faculty_id = matter_faculty_id;
        }



        public override string ToString()
        {
            return $"Matter ID: {matter_id} | Code: {matter_code} | Name: {matter_name} | Faculty ID: {matter_faculty_id}";
        }
    }
}
