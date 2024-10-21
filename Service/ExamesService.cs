using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;


namespace University.Service
{
    public class ExamesService
    {
        DBservice db =new();

        public void PrintExames()
        {
          db.GetExames().ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}
