using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;
using UniversityManagerWithDB.Entity;

namespace University;

public class FacultiesRepository
{
    public List<Faculties> Faculties {get;set;}=[];

    public void ImportFaculties(){


        DBservice dbservice = new DBservice();
        Faculties = dbservice.GetFaculties();


    }


}
