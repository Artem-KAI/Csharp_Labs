using System;
using DAL.Base;

namespace DAL.Entities
{
    [Serializable]
    public class Manager : Person
    {
        public string EmployeeID { get; set; }
        public string WorkPosition { get; set; }

        public Manager() { }

        public Manager(string lastName, string employeeID)
            : base(lastName)
        {
            EmployeeID = employeeID;
            WorkPosition = "Support manager";
        }

        public override string GetInfo()
        {
            return $"Manager: {LastName}, Work position: {WorkPosition}";
        }
    }
}
