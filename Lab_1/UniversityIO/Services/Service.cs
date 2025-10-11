using System.Text.RegularExpressions;
using UniversityBrain.Base;
using UniversityBrain.Entities;

namespace UniversityIO.Services
{
    public class StudentOperations
    {
        protected readonly List<Person> _people = new List<Person>();
        protected void CountStudents()
        {
            int c = 0;
            foreach (var p in _people)
            {
                if (p is Student s)
                {
                    if (!string.IsNullOrWhiteSpace(s.country) &&
                        s.country.Trim().ToLower() == "ukraine" && s.course == 3)
                    {
                        c++;
                    }
                }                
            }
            Console.WriteLine($"Students of 3 course and from Ukraine: {c}");
        }
    }

    public class ValidatorRegex
    {
        public static bool IsValidStudentId(string id)
        {
            return Regex.IsMatch(id, @"^[A-Z]{2}\d{6}$"); //  \d - number 0-9
        }
    }
}
