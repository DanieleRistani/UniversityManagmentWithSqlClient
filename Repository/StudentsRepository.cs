using System;
using System.Configuration;
using System.Text.Json;
using University.Interface;
using University.Service;
using UniversityManagerWithDB.Entity;

namespace University.Repository; 

public class StudentsRepository
{
   
    public List<Students> Students { get; set; } = [];

    public void ImportStudents()
    {


        DBservice dBservice = new DBservice();
        Students = dBservice.GetStudents();

    }


}
