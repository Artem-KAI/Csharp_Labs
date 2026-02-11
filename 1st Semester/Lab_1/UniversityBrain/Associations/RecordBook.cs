using System;

namespace UniversityBrain.Associations
{
    public class RecordBook
    {
        public string recordBookNumber { get; set; }
        public double averageScore { get; set; }

        public RecordBook(string number, double averageScore)
        {
            recordBookNumber = number;
            this.averageScore = averageScore;
        }
    }
}