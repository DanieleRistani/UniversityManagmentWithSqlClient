using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using University.Service;
using UniversityManagerWithDB.Entity;

namespace University.Repository
{
      
    internal class MattersRepository
    {
        List<Matters> matters = [];

        public void ImportMatters()
        {
            DBservice dBservice = new DBservice();
            matters = dBservice.GetMatters();
        }

    }
}
