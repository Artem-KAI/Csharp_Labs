using BLL.Base;

namespace BLL.Models
{
    public class StudentModel : PersonModel
    {
        public int Course { get; set; }
        public string Country { get; set; }
        public double AverageGrade { get; set; }
        public string StudentCard { get; set; }
        public string RecordBookNumber { get; set; }

        public StudentModel() { }

        public StudentModel(string lastName, int course, string studentCard,
                            double averageGrade, string country, string recordBookNumber)
            : base(lastName)
        {
            Course = course;
            StudentCard = studentCard;
            AverageGrade = averageGrade;
            Country = country;
            RecordBookNumber = recordBookNumber;
        }
    }
}
