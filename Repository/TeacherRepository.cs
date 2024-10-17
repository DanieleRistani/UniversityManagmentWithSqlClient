using System;
using System.Configuration;
using System.Text.Json;
using OPP.Entity;
using University.Interface;
using University.Service;

namespace University.Repository;

public class TeacherRepository
{
    
    public List<Teacher> Teachers { get; set; } = [];

    public void ImportTeacher()
    {
        DBservice dBservice = new DBservice();

        Teachers = dBservice.GetTeacher();

        
       
    }

}
