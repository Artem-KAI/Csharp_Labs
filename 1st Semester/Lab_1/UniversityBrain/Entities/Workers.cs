using UniversityBrain.Base;

namespace UniversityBrain.Entities
{
    public class McDonaldsWorker : Person 
    {
        public string employeeID { get; set; }  
        public string WorkPositions { get; set; }

        public McDonaldsWorker(string name, string surname, string employeeID)
            : base(name, surname)
        {
            this.employeeID = employeeID;
            WorkPositions = "Cooker";
        }

        public override string GetStudentInfo()
        {         
            return $"Manager: {name} {surname}, Position: {WorkPositions}"; 
        }
    }

    public class Manager : Person
    {
        public string employeeID { get; set; }  
        public string WorkPositions { get; set; }

        public Manager (string name, string surname, string employeeID)
            : base(name, surname)
        {
            this.employeeID = employeeID;
            WorkPositions = "Support manager";
        }

        public  override string GetStudentInfo()
        {
            return $"Manager: {surname}, Work position: {WorkPositions}";
        }
    }
}
