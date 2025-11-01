using DAL.Base;
using System;

namespace DAL.Entities
{
    [Serializable]
    public class Student : Person
    {
        public int Course { get; set; }
        public string StudentCard { get; set; }
        public double AverageGrade { get; set; }
        public string Country { get; set; }
        public string RecordBookNumber { get; set; }

        public Student() { }

        public Student(string lastName, int course, string studentCard,
                       double averageGrade, string country, string recordBookNumber)
            : base(lastName)
        {
            Course = course;
            StudentCard = studentCard;
            AverageGrade = averageGrade;
            Country = country;
            RecordBookNumber = recordBookNumber;
        }

        public override string GetInfo()
        {
            return $"{LastName}, {Course} course, {Country}, avg score: {AverageGrade}";
        }
    }
}


