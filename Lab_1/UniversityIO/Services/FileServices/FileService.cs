using UniversityBrain.Entities;
using UniversityBrain.Base;

namespace UniversityIO.Services.FileServices
{
    public class FileService : IFileService<Person>
    {
        public void SaveData(string path, Person[] persons)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                foreach (var p in persons)
                {
                    if (p is Student s)
                    {
                        writer.WriteLine($"Student {s.name}{s.surname}");
                        writer.WriteLine("{");
                        writer.WriteLine($"\"firstname\": \"{s.name}\",");
                        writer.WriteLine($"\"lastname\": \"{s.surname}\",");
                        writer.WriteLine($"\"country\": \"{s.country}\",");
                        writer.WriteLine($"\"course\": \"{s.course}\",");
                        writer.WriteLine($"\"averageScore\": \"{s.Book.averageScore}\",");
                        writer.WriteLine($"\"studentID\": \"{s.studentID}\",");
                        writer.WriteLine($"\"recordBookNumber\": \"{s.Book.recordBookNumber}\"");
                        writer.WriteLine("};");
                    }
                    else if (p is McDonaldsWorker w)
                    {
                        writer.WriteLine($"McDonaldsWorker {w.name}{w.surname}");
                        writer.WriteLine("{");
                        writer.WriteLine($"\"firstname\": \"{w.name}\",");
                        writer.WriteLine($"\"lastname\": \"{w.surname}\",");
                        writer.WriteLine($"\"employeeID\": \"{w.employeeID}\",");
                        writer.WriteLine($"\"WorkPositions\": \"{w.WorkPositions}\"");
                        writer.WriteLine("};");
                    }
                    else if (p is Manager m)
                    {
                        writer.WriteLine($"Manager {m.name}{m.surname}");
                        writer.WriteLine("{");
                        writer.WriteLine($"\"firstname\": \"{m.name}\",");
                        writer.WriteLine($"\"lastname\": \"{m.surname}\",");
                        writer.WriteLine($"\"employeeID\": \"{m.employeeID}\",");
                        writer.WriteLine($"\"WorkPositions\": \"{m.WorkPositions}\"");
                        writer.WriteLine("};");
                    }
                }
            }
        }

        public Person[] LoadData(string path)
        {
            if (!File.Exists(path))
                return Array.Empty<Person>();

            string[] lines = File.ReadAllLines(path);
            return Parser.Parse(lines);
        }
    }
}
