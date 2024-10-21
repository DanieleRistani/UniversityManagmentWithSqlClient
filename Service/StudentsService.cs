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
        
        public void PrintStudents(StudentsRepository studentsRepository)
        {
            studentsRepository.Students.ForEach(s => Console.WriteLine(s.ToString()));
        }
    }
}
