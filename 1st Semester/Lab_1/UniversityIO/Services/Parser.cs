using UniversityBrain.Entities;
using UniversityBrain.Base;

namespace UniversityIO.Services
{
    public static class Parser
    {
        public static Person[] Parse(string[] lines)
        {
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
                if (lines[i].StartsWith("Student") ||
                    lines[i].StartsWith("McDonaldsWorker") ||
                    lines[i].StartsWith("Manager"))
                    count++;

            Person[] persons = new Person[count];
            int index = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line.StartsWith("Student"))
                {
                    string firstname = "", lastname = "", country = "", studentID = "", recordBookNumber = "";
                    int course = 0;
                    double average = 0;

                    for (int j = i + 2; j < lines.Length; j++)
                    {
                        string l = lines[j].Trim();
                        if (l.StartsWith("};")) { i = j; break; }

                        var parts = l.Split(':');
                        if (parts.Length < 2) continue;

                        string key = parts[0].Replace("\"", "").Trim();
                        string val = parts[1].Replace("\"", "").Replace(",", "").Trim();

                        switch (key)
                        {
                            case "firstname": firstname = val; break;
                            case "lastname": lastname = val; break;
                            case "country": country = val; break;
                            case "course": int.TryParse(val, out course); break;
                            case "averageScore": double.TryParse(val, out average); break;
                            case "studentID": studentID = val; break;
                            case "recordBookNumber": recordBookNumber = val; break;
                        }
                    }

                    persons[index++] = new Student(firstname, lastname, country, course, average, studentID, recordBookNumber);
                }

                else if (line.StartsWith("McDonaldsWorker"))
                {
                    string firstname = "", lastname = "", employeeID = "", position = "";

                    for (int j = i + 2; j < lines.Length; j++)
                    {
                        string l = lines[j].Trim();
                        if (l.StartsWith("};")) { i = j; break; }

                        var parts = l.Split(':'); 
                        if (parts.Length < 2) continue;

                        string key = parts[0].Replace("\"", "").Trim();
                        string val = parts[1].Replace("\"", "").Replace(",", "").Trim();

                        switch (key)
                        {
                            case "firstname": firstname = val; break; 
                            case "lastname": lastname = val; break;
                            case "employeeID": employeeID = val; break;
                            case "WorkPositions": position = val; break;
                        }
                    }

                    var worker = new McDonaldsWorker(firstname, lastname, employeeID)
                    {
                        WorkPositions = position // to overide default value  
                    };
                    persons[index++] = worker;

                }

                else if (line.StartsWith("Manager"))
                {
                    string firstname = "", lastname = "", employeeID = "", position = "";

                    for (int j = i + 2; j < lines.Length; j++)
                    {
                        string l = lines[j].Trim();
                        if (l.StartsWith("};")) { i = j; break; }

                        var parts = l.Split(':');
                        if (parts.Length < 2) continue;

                        string key = parts[0].Replace("\"", "").Trim();
                        string val = parts[1].Replace("\"", "").Replace(",", "").Trim();

                        switch (key)
                        {
                            case "firstname": firstname = val; break;
                            case "lastname": lastname = val; break;
                            case "employeeID": employeeID = val; break;
                            case "WorkPositions": position = val; break;
                        }
                    }

                    var manager = new Manager(firstname, lastname, employeeID)
                    {
                        WorkPositions = position // to override default value 
                    };
                    persons[index++] = manager;

                }
            }

            return persons;
        }
    }
}
