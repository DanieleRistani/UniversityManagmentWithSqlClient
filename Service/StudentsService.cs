using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;

namespace University.Service
{
    internal class StudentsService
    {
        public StudentsRepository studentsRepository { get; set; } = new StudentsRepository();

        public void PrintStudents()
        {
            studentsRepository.Students.ForEach(s => Console.WriteLine(s.ToString()));
        }
    }
}
