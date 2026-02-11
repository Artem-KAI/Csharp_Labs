using BLL.Base;

namespace BLL.Models
{
    public class McDonaldsWorkerModel : PersonModel
    {
        public string EmployeeID { get; set; }
        public string WorkPosition { get; set; }

        public McDonaldsWorkerModel() { }
        public McDonaldsWorkerModel(string lastName, string employeeID)
            : base(lastName)
        {
            EmployeeID = employeeID;
            WorkPosition = "Cooker";
        }
    }
}
