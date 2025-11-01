using BLL;
using BLL.Base;
using BLL.Models;

#pragma warning disable SYSLIB0011
namespace PL
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("                                                   -----| MENU |-----");
            Console.Write("Type of serialization |1 Binary |2 XML |3 JSON |4 Custom |: ");
            string choice = Console.ReadLine();

            Console.Write("Enter file name (without extension): ");
            string fileName = Console.ReadLine();
            string filePath = $"{fileName}.{GetExtension(choice)}";

            var service = ProviderFactory.CreateService(choice);
            List<PersonModel> people;

            if (File.Exists(filePath))
            {
                Console.WriteLine("File found, deserializing...");
                people = service.LoadPeople(filePath);
            }
            else
            {
                Console.WriteLine("File not found, creating default data...");
                people = CreateDefaultPeople();
                service.SavePeople(filePath, people);
            }

            Console.WriteLine("\nAll people:");
            foreach (var p in people)
                Console.WriteLine($"[{p.GetType().Name}] {p.LastName}");

            Console.WriteLine("\nUkrainian 3rd course students:");
            var ukrStudents = service.GetUkrainianThirdCourseStudents(filePath);
            ukrStudents.ForEach(s => Console.WriteLine($"{s.LastName}, avg: {s.AverageGrade}"));
        }

        private static List<PersonModel> CreateDefaultPeople()
        {
            return new List<PersonModel>
            {
                new StudentModel("Vlasiuk", 3, "ST001", 89.5, "Ukraine", "ZK123"),
                new StudentModel("Evtushenko", 2, "ST002", 75.2, "Poland", "ZK124"),
                new StudentModel("Bezyshko", 3, "ST003", 91.0, "Ukraine", "ZK125"),
                new McDonaldsWorkerModel("Petrenko", "MC001"),
                new ManagerModel("Andrushenko", "MG001")
            };
        }

        private static string GetExtension(string choice) =>
            choice switch
            {
                "1" => "bin",
                "2" => "xml",
                "3" => "json",
                "4" => "txt",
                _ => "dat"
            };
    }
}
