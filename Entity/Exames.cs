

namespace UniversityManagerWithDB.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exames
    {
        public long exame_id { get; set; }
        public string exame_code { get; set; }
        public long exame_teacher_id { get; set; }
        public long exame_student_id { get; set; }
        public System.DateTime exame_date { get; set; }
        public int exame_result { get; set; }
        public long exame_matter_id { get; set; }
    

        public Exames() { } 
        public Exames(string exame_code, long exame_teacher_id, long exame_student_id, System.DateTime exame_date, int exame_result, long exame_matter_id) {
        
        this.exame_code = exame_code;
        this.exame_teacher_id = exame_teacher_id;
        this.exame_student_id = exame_student_id;
        this.exame_date = exame_date;
        this.exame_result = exame_result;
        this.exame_matter_id = exame_matter_id;
        }

       
        public override string ToString()
        {
            return $"Exame ID: {exame_id} | Code: {exame_code} | Teacher ID: {exame_teacher_id} | " +
                   $"Student ID: {exame_student_id} | Date: {exame_date:yyyy-MM-dd} | " +
                   $"Result: {exame_result} | Matter ID: {exame_matter_id}";
        }

    }

}


