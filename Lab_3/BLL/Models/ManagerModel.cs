using BLL.Base;

namespace BLL.Models
{
    public class  ManagerModel : PersonModel
    {
        public string EmployeeID { get; set; }
        public string WorkPosition { get; set; }

        public ManagerModel() { }

        public ManagerModel(string lastName, string employeeID)
            : base(lastName)
        {
            EmployeeID = employeeID;
            WorkPosition = "Support manager";
        }
    }
}
