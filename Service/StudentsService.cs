using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;


namespace University.Service
{
    public class StudentsService
    {
        DBservice db = new();
        public void PrintStudents()
        {
            db.GetStudents().ForEach(s => Console.WriteLine(s.ToString()));
        }
    }
}
