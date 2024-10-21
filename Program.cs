using University.Enum;
using University.Repository;
using University.Service;
using UniversityManagerWithDB.Service;

namespace University
{
    internal class Program
    {
        static void Main(string[] args)=>AppMenu();

        public static void AppMenu()
        {



            AppMenusService appMenusService = new AppMenusService();
            appMenusService.facultiesRepository.ImportFaculties();
            appMenusService.teachersRepository.ImportTeachers();
            appMenusService.examesRepository.ImportExames();
            appMenusService.studentsRepository.ImportStudents();
            
            bool exitLoop = false;

            while (!exitLoop)
            {
                Console.WriteLine("Menù Principale:\n----------------------------------------------");
                string[] options = { "Gestione Studenti", "Gestione Docenti", "Gestione Esami", "Gestione Facoltà", "Esci" };
                int selectedIndex = 0;
                ConsoleKeyInfo key;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Menù Principale:\n----------------------------------------------");
                    for (int i = 0; i < options.Length; i++)
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
                        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Length - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex < options.Length - 1) ? selectedIndex + 1 : 0;
                    }

                } while (key.Key != ConsoleKey.Enter);

                Console.Clear();

                switch (selectedIndex)
                {
                    case (int)AppMenuEnum.StudentsManagment:

                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        appMenusService.StudentsManagment();

                        break;
                    case (int)AppMenuEnum.TeachersManagment:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        appMenusService.TeachersManagment();

                        break;
                    case (int)AppMenuEnum.ExamsManagment:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        appMenusService.ExamsManagment();
                        break;
                    case (int)AppMenuEnum.FacultiesManagment:
                        Console.WriteLine($"Hai selezionato: {options[selectedIndex]}");
                        appMenusService.FacultiesManagment();
                        break;
                    case (int)AppMenuEnum.Exit:
                        Console.WriteLine($"Uscita dall' Applicazione");
                        exitLoop = true;
                        break;
                }

                if (exitLoop == false)
                {
                    Console.WriteLine("Premere un tasto per tornare al menù principale");
                    _ = Console.ReadKey();
                }

            }
            exitLoop = true;
        }
    }
}
