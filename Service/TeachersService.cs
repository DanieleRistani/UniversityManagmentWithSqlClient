using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;

namespace University.Service
{
    public class TeachersService
    {

      public TeachersRepository teachersRepository { get; set; } = new TeachersRepository();

      public void PrintTeachers()
      {
          teachersRepository.Teachers.ForEach(t=> Console.WriteLine(t.ToString()));
      }
      
    }
}
