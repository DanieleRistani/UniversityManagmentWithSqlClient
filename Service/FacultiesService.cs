using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Interface;
using University.Repository;
using UniversityManagerWithDB.Entity;


namespace University.Service
{
    public  class FacultiesService
    {
        DBservice db = new();

        public void PrintFaculties()
        {
            db.GetFaculties().ForEach(f=>Console.WriteLine(f.ToString()));
        }
        public void AddFaculties()
        {

            Console.WriteLine("Inserimento nuova facoltà");

            bool isValidField = false;
            int xCursor = 0;
            int yCursor = 0;



            Console.Write("Nome:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string name = string.Empty;

            while (!isValidField)
            {
                name = Console.ReadLine();

                if (db.GetFaculties().Select(f => f.faculty_name).Contains(name))
                {
                    ILog.AddNewLog("Valore non valido università gia presente", "AddFacultiesService");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore non valido università gia presente");
                    Console.SetCursorPosition(xCursor, yCursor);
                }
                else
                {
                    if (int.TryParse(name, out _))
                    {

                        ILog.AddNewLog("Valore non valido", "AddFacultiesService");

                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.WriteLine("Valore numerico non valido");
                        Console.SetCursorPosition(xCursor, yCursor);

                    }
                    else if (name == string.Empty)
                    {
                        ILog.AddNewLog("Valore non valido", "AddFacultiesService");

                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.Write(new string(' ', Console.WindowWidth - xCursor));
                        Console.SetCursorPosition(xCursor, yCursor + 1);
                        Console.WriteLine("Valore nullo");
                        Console.SetCursorPosition(xCursor, yCursor);

                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, Console.CursorTop);
                        isValidField = true;
                    }


                }

                
            }
            isValidField = false;





            Console.Write("Locazione:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string location = string.Empty;

            while (!isValidField)
            {
                location = Console.ReadLine();

                if (int.TryParse(location, out _))
                {

                    ILog.AddNewLog("Valore non valido", "AddFacultiesService");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore numerico non valido");
                    Console.SetCursorPosition(xCursor, yCursor);

                }
                else if (location == string.Empty)
                {
                    ILog.AddNewLog("Valore non valido", "AddFacultiesService");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore nullo");
                    Console.SetCursorPosition(xCursor, yCursor);

                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    isValidField = true;
                }
            }
            isValidField = false;

            db.AddFaculties(name,location);

        }
        public void DeleteFaculties()
        {
            Console.WriteLine("Inserisci facoltà da eliminare");

            bool isValidField = false;
            int xCursor = 0;
            int yCursor = 0;



            Console.Write("Nome:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string name = string.Empty;

            while (!isValidField)
            {
                name = Console.ReadLine();

                if (db.GetFaculties().Select(f => f.faculty_name.ToUpper()).Contains(name.ToUpper()))
                {

                    db.GetFaculties().ForEach(f =>
                    {
                        if (f.faculty_name.ToUpper() == name.ToUpper())
                        {
                            db.DeleteFaculties(f.faculty_id);
                            isValidField = true;

                        }

                    });
                }
                else
                {
                    ILog.AddNewLog("Valore non valido università non presente", "AddFacultiesService");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore non valido università non presente");
                    Console.SetCursorPosition(xCursor, yCursor);


                }


            }
            isValidField = false;

        }
        public void UpdateFaculties()
        {
            Console.WriteLine("Inserisci facoltà da aggiornare");

            bool isValidField = false;
            int xCursor = 0;
            int yCursor = 0;



            Console.Write("Nome:");
            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;
            string name = string.Empty;





            while (!isValidField)
            {
                name = Console.ReadLine();

                if (db.GetFaculties().Select(f => f.faculty_name).Contains(name))
                {

                    Faculties faculty = db.GetFaculties().Find(f => f.faculty_name.Equals(name));
                    List<string> options = ["Nome", "Locazione"];

                    string newName=String.Empty;
                    string newLocation=String.Empty;

                    int selectedIndex = 0;
                    ConsoleKeyInfo key;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Seleziona il campo da modificare:");
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (i == selectedIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(options[i]);
                            Console.ResetColor();
                        }

                        key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Count - 1;
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = (selectedIndex < options.Count - 1) ? selectedIndex + 1 : 0;
                        }

                    } while (key.Key != ConsoleKey.Enter);

                    Console.Clear();


                    switch (selectedIndex)
                    {
                        case 0:
                            Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                            Console.WriteLine("Nome attuale: " + faculty.faculty_name);
                            Console.WriteLine("Inserisci nuovo nome:");
                            xCursor = Console.GetCursorPosition().Left;
                            yCursor = Console.GetCursorPosition().Top;
                            newName = string.Empty;
                            newLocation = faculty.faculty_location;

                            while (!isValidField)
                            {
                                name = Console.ReadLine();

                                if (int.TryParse(newName, out _))
                                {

                                    ILog.AddNewLog("Valore non valido", "AddStudent");

                                    Console.SetCursorPosition(xCursor, yCursor);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.WriteLine("Valore numerico non valido");
                                    Console.SetCursorPosition(xCursor, yCursor);

                                }
                                else if (newName == string.Empty)
                                {
                                    ILog.AddNewLog("Valore non valido", "AddStudent");

                                    Console.SetCursorPosition(xCursor, yCursor);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.WriteLine("Valore nullo");
                                    Console.SetCursorPosition(xCursor, yCursor);

                                }
                                else
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop);
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.SetCursorPosition(0, Console.CursorTop);
                                    isValidField = true;
                                }
                            }

                            isValidField = false;


                            break;
                        case 1:
                            Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                            Console.WriteLine("Cognome attuale: " + faculty.faculty_location);
                            Console.WriteLine("Inserisci nuovo cognome:");
                            xCursor = Console.GetCursorPosition().Left;
                            yCursor = Console.GetCursorPosition().Top;
                            newLocation = string.Empty;
                            newName = faculty.faculty_name;

                            while (!isValidField)
                            {
                                newLocation = Console.ReadLine();

                                if (int.TryParse(newLocation, out _))
                                {

                                    ILog.AddNewLog("Valore non valido", "AddStudent");

                                    Console.SetCursorPosition(xCursor, yCursor);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.WriteLine("Valore numerico non valido");
                                    Console.SetCursorPosition(xCursor, yCursor);

                                }
                                else if (newLocation == string.Empty)
                                {
                                    ILog.AddNewLog("Valore non valido", "AddStudent");

                                    Console.SetCursorPosition(xCursor, yCursor);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                                    Console.SetCursorPosition(xCursor, yCursor + 1);
                                    Console.WriteLine("Valore nullo");
                                    Console.SetCursorPosition(xCursor, yCursor);

                                }
                                else
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop);
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.SetCursorPosition(0, Console.CursorTop);
                                    isValidField = true;
                                }
                            }

                            isValidField = false;

                         break;





                    }
                    db.UpdateFaculties(db.GetFaculties().Find(f => f.faculty_name.Equals(name)).faculty_id, newName, newLocation);

                }
                else
                {
                    ILog.AddNewLog("Valore non valido università non presente", "AddFacultiesService");

                    Console.SetCursorPosition(xCursor, yCursor);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.Write(new string(' ', Console.WindowWidth - xCursor));
                    Console.SetCursorPosition(xCursor, yCursor + 1);
                    Console.WriteLine("Valore non valido università non presente");
                    Console.SetCursorPosition(xCursor, yCursor);


                }


            }
            isValidField = false;

        }
    
    }
}
