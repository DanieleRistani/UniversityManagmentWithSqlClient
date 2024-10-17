using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;

namespace University;

public class FacultyRepository
{
    public List<Faculty> Faculties {get;set;}=[];

    public void ImportFaculty(){


        DBservice dbservice = new DBservice();
        Faculties = dbservice.GetFaculty();


    }
    
   
}
