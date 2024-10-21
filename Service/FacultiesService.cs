using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repository;

namespace University.Service
{
    public  class FacultiesService
    {

        public void PrintFaculties(FacultiesRepository facultiesRepository)
        {
            facultiesRepository.Faculties.ForEach(f => Console.WriteLine(f.ToString()));
        }
    }
}
