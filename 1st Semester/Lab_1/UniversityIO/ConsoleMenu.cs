using UniversityBrain.Entities;
using UniversityBrain.Base;
using UniversityIO.Services.FileServices;
using UniversityIO.Services;

namespace UniversityIO
{
    public class ConsoleMenu : StudentOperations
    {
        private readonly string _path = "PersonsArray.txt";

        private readonly IFileService<Person> _personFileService;

        public ConsoleMenu()
        {
            _personFileService = new FileService();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n.    Menu    .");
                Console.WriteLine("1 – Add person (Student/McWorker/Manager)");
                Console.WriteLine("2 – See all persons");
                Console.WriteLine("3 – Count students (3 course, Ukraine)");
                Console.WriteLine("4 – Save to file");
                Console.WriteLine("5 – Load from file");
                Console.WriteLine("0 – Exit");
                Console.Write("Your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddPerson(); break;
                    case "2": ShowPersons(); break;
                    case "3": CountStudents(); break;
                    case "4": SaveToFile(); break;
                    case "5": LoadFromFile(); break;
                    case "0": return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void AddPerson()
        {
            Console.WriteLine("\nWho do you want to add?");
            Console.WriteLine("1 - Student");
            Console.WriteLine("2 - McDonalds Worker");
            Console.WriteLine("3 - Manager");
            Console.Write("Choice: ");
            var typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1": AddStudent(); break;
                case "2": AddMcWorker(); break;
                case "3": AddManager(); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ResetColor();
                    break;
            }
        }

        private void AddStudent()
        {
            Console.WriteLine("\n.    Add Student    .");
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Surname: "); var surname = Console.ReadLine();
            Console.Write("Country: "); var country = Console.ReadLine();

            int course;
            while (true)
            {
                Console.Write("Course: ");
                if (int.TryParse(Console.ReadLine(), out course))
                    break;
                else 
                { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: supports only int value");
                Console.ResetColor();
                }
            }

            double average;
            while (true)
            {
                Console.Write("AverageScore: ");
                if (double.TryParse(Console.ReadLine(), out average)) break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: supports only double value");
                Console.ResetColor();
            }

            string id;
            while (true)
            {
                Console.Write("StudentID: ");
                id = Console.ReadLine();
                if (!ValidatorRegex.IsValidStudentId(id))
                {
                    Console.WriteLine("StudentID must be like AB123456)");
                }
                else break;
            }

            Console.Write("RecordBookNumber: "); var book = Console.ReadLine();

            var student = new Student(name, surname, country, course, average, id, book);
            _people.Add(student);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student added");
            Console.ResetColor();
        }

        private void AddMcWorker()
        {
            Console.WriteLine("\n.    Add McDonalds Worker    .");
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Surname: "); var surname = Console.ReadLine();
            Console.Write("Employee ID: "); var id = Console.ReadLine();
            Console.Write("Work Position: "); var position = Console.ReadLine();

            var worker = new McDonaldsWorker(name, surname, id);

            if (!string.IsNullOrWhiteSpace(position)) // override default value 
                worker.WorkPositions = position;

            _people.Add(worker);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("McDonalds Worker added");
            Console.ResetColor();
        }

        private void AddManager()
        {
            Console.WriteLine("\n.    Add Manager    .");
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Surname: "); var surname = Console.ReadLine();
            Console.Write("Employee ID: "); var id = Console.ReadLine();
            Console.Write("Work Position: "); var position = Console.ReadLine();

            var manager = new Manager(name, surname, id);

            if (!string.IsNullOrWhiteSpace(position)) // override default value 
                manager.WorkPositions = position;

            _people.Add(manager);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Manager added");
            Console.ResetColor();
        }

        private void ShowPersons()
        {
            Console.WriteLine("\n--- Persons ---");
            if (_people.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No persons in data");
                Console.ResetColor();
                return;
            }

            int index = 1;
            foreach (var p in _people)
            {
                Console.WriteLine($"{index++}. {p.GetStudentInfo()}");
            }
        }

        private void SaveToFile()
        {
            _personFileService.SaveData(_path, _people.ToArray());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Data saved to file");
            Console.ResetColor();
        }

        private void LoadFromFile()
        {
            var loaded = _personFileService.LoadData(_path);

            _people.Clear();
            _people.AddRange(loaded);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {loaded.Length} persons from file");
            Console.ResetColor();
        }
    }
}
