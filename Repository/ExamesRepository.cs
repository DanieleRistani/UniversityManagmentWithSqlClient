using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;
using UniversityManagerWithDB.Entity;

namespace University.Repository;

public class ExamesRepository  
{
  public List<Exames> Exames { get; set; } = [];

  public void ImportExames()
  {
        DBservice dbservice = new DBservice();
        Exames = dbservice.GetExames();
   }
}
