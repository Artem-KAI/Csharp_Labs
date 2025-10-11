using UniversityBrain.Base;
using UniversityBrain.Associations;

namespace UniversityBrain.Entities
{
    public class Student : Person, IChessplayer 
    {
        public string country { get; set; }
        public int course { get; set; }
        public string studentID { get; set; }

        public RecordBook Book { get; private set; }


        public Student(string name, string surname, string country, int course,
                        double averageScore, string studentID, string recordBookNumber) : base(name, surname)
        {
            this.country = country;
            this.course = course;
            this.studentID = studentID;

            Book = new RecordBook(recordBookNumber, averageScore);
        }

        public override string GetStudentInfo() 
        {
            return $"Student: {name} {surname}, Course: {course}, Country: {country}, StudentID: {studentID}";
        }   

        public string PlayChess() 
        {
            return $"{surname} is playing chess.";
        }

        public string Study()
        {
            return $"The {name} {surname} is studing";
        }
    }
}