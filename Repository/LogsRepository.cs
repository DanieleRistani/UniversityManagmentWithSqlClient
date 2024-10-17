using System;
using System.Text;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;

namespace University.Repository;

public class LogsRepository 
{
    public List<Logs> LogList { get; set; } = [];

    public void ImportLogs() {
        DBservice dBservice = new DBservice();
        LogList = dBservice.GetLog();

    }
}
