using System;

namespace University.Entity;


public class Logs
{
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public string ErrorPlace { get; set; }


    public Logs(string message, DateTime date, string errorPlace)
    {
        this.Message = message;
        this.Date = date;
        this.ErrorPlace = errorPlace;
    }

    public string PrintLog()
    {
        return $"Messaggio:{this.Message}|Data:{this.Date}|Localizzazione errore:{this.ErrorPlace}";
    }
}

