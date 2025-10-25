using System;

namespace DAL.Entities
{
    [Serializable] // for binaryformatter
    public class Student
    {
        public string LastName { get; set; }
        public int Course { get; set; }
        public string StudentCard { get; set; }
        public double AverageGrade { get; set; }
        public string Country { get; set; }
        public string RecordBookNumber { get; set; }

        public Student() { }

        public Student(string lastName, int course, string studentCard, 
                double averageGrade, string country, string recordBookNumber)
        {
            LastName = lastName;
            Course = course;
            StudentCard = studentCard;
            AverageGrade = averageGrade;
            Country = country;
            RecordBookNumber = recordBookNumber;
        }

        public override string ToString()
        {
            return $"{LastName}, {Course} course, {Country}, avg score: {AverageGrade}";
        }
    }
}

