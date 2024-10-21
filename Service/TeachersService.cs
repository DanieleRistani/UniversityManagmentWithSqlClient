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

      public void PrintTeachers(TeachersRepository teachersRepository)
      {
          teachersRepository.Teachers.ForEach(t=> Console.WriteLine(t.ToString()));
      }
      
    }
}
