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
        public ExamesRepository examesRepository { get; set; }=new ExamesRepository();

        public void PrintExames()
        {
          examesRepository.Exames.ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}
