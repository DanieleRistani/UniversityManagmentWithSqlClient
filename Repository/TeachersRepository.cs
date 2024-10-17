using System;
using System.Configuration;
using System.Text.Json;

using University.Interface;
using University.Service;
using UniversityManagerWithDB.Entity;

namespace University.Repository;

public class TeachersRepository
{
    
    public List<Teachers> Teachers { get; set; } = [];

    public void ImportTeachers()
    {
        DBservice dBservice = new DBservice();
        Teachers = dBservice.GetTeachers();



    }

}
