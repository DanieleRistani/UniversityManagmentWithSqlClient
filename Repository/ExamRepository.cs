using System;
using System.Configuration;
using System.Text.Json;
using University.Entity;
using University.Interface;
using University.Service;

namespace University.Repository;

public class ExamRepository  
{
  public List<Exam> Exams { get; set; } = [];

  public void ImportExams()
  {
        DBservice dbservice = new DBservice();
        Exams = dbservice.GetExam();
  }
}
