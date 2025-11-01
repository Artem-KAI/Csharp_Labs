using System;
using DAL.Base;

namespace DAL.Entities
{
    [Serializable]
    public class McDonaldsWorker : Person
    {
        public string EmployeeID { get; set; }
        public string WorkPosition { get; set; }

        public McDonaldsWorker() { } // для серіалізації

        public McDonaldsWorker(string lastName, string employeeID)
            : base(lastName)
        {
            EmployeeID = employeeID;
            WorkPosition = "Cooker";
        }

        public override string GetInfo()
        {
            return $"Worker: {LastName}, Position: {WorkPosition}";
        }
    }
}
