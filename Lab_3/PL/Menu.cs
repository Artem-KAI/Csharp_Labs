using System;
using System.Collections.Generic;
using System.IO;
using DAL.Entities;
using DAL;
using DAL.Providers;
using BLL;

namespace PL
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("|||-----|     MENU     |-----|||\n");
            Console.WriteLine("_________________________________________________________________________");
            Console.Write("Type of serialization |1 = бінарна| 2 = XML| 3 = JSON| 4 = Користувацька|: ");
            string choice = Console.ReadLine();

            Console.WriteLine("________________________________________________________________________|");
            Console.Write("Enter the file name (without extension):");
            string fileName = Console.ReadLine();

            string filePath = $"{fileName}.{GetExtension(choice)}";
            var provider = GetProvider(choice);
            var context = new EntityContext(provider);
            var service = new EntityService(context);

            Console.WriteLine($"\nChecking for file existence: {filePath}");

            List<Student> students;

            // deserialization
            if (File.Exists(filePath))
            {
                Console.WriteLine("File founded, deserialization... ");
                students = service.LoadStudents(filePath);

                if (students.Count == 0)
                {               
                    students = CreateDefaultStudents();
                    service.SaveStudents(filePath);
                }

                Console.WriteLine("\nData deserialized successfully. List of students:");
                students.ForEach(s => Console.WriteLine(s));
            }
            else
            {
                students = CreateDefaultStudents();
                service.SaveStudents(filePath);
                Console.WriteLine($"\nNew data serialized to file {filePath}");
            }

            try
            {
                var ukrStudents = service.GetUkrainianThirdCourseStudents();
                Console.WriteLine("\nStudent 3 course, from Ukraine:");
                ukrStudents.ForEach(s => Console.WriteLine(s));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static List<Student> CreateDefaultStudents()
        {
            return new List<Student>
            {
                new Student("Vlasiuk", 3, "ST001", 89.5, "Ukraine", "ZK123"),
                new Student("Evtushenko", 2, "ST002", 75.2, "Poland", "ZK124"),
                new Student("Bezyshko", 3, "ST003", 91.0, "Ukraine", "ZK125"),
            };
        }

        private static string GetExtension(string choice)
        {
            return choice switch
            {
                "1" => "bin",
                "2" => "xml",
                "3" => "json",
                "4" => "txt",
                _ => "dat"
            };
        }

        private static dynamic GetProvider(string choice)
        {
            return choice switch
            {
                "1" => new BinaryProvider<Student>(),
                "2" => new XmlProvider<Student>(),
                "3" => new JsonProvider<Student>(),
                "4" => new CustomProvider<Student>(),
                _ => new JsonProvider<Student>()
            };
        }
    }
}
