using System;
using University.Entity;
using University.Repository;

namespace University.Interface;


public interface ILog
{
    
    static bool AddNewLog(String message, String errorPlace)
    {
        
       DBservice dBservice = new DBservice();
       return dBservice.AddLogs(message, errorPlace);
        
        

    }
}
