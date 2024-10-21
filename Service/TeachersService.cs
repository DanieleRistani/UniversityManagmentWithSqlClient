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
        DBservice db = new();
      public void PrintTeachers()
      {
         db.GetTeachers().ForEach(t=> Console.WriteLine(t.ToString()));
      }
      
    }
}
