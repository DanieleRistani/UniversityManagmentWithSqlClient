using System;
using System.Configuration;
using System.Text.Json;
using OPP.Entity;
using University.Interface;
using University.Service;

namespace University.Repository; 

public class StudentRepository
{
   
    public List<Student> Students { get; set; } = [];

    public void ImportStudents()
    {


       DBservice dBservice = new DBservice();
        Students = dBservice.GetStudent();

    }


}
