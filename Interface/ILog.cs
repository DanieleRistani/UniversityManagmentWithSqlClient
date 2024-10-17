using System;
using University.Entity;
using University.Repository;

namespace University.Interface;


public interface ILog
{
    
    static Logs AddNewLog(String message, String errorPlace)
    {
        Logs log = new Logs(message, DateTime.Now, errorPlace);
        return log;

    }
}
