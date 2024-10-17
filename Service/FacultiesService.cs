using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;

namespace University.Service
{
    internal class FacultiesService
    {
        public FacultiesRepository facultiesRepository { get; set; } = new FacultiesRepository();


        public void PrintFaculties()
        {
            facultiesRepository.Faculties.ForEach(f => Console.WriteLine(f.ToString()));
        }
    }
}
