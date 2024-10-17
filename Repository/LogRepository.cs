using System;
using System.Text;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;

namespace University.Repository;

public class LogRepository 
{
    public List<Log> LogList { get; set; } = [];

    public void ImportLog() { 
        DBservice dBservice = new DBservice();
        LogList = dBservice.GetLog();
    
    
    }
}
