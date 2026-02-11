using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
    public abstract class PersonModel
    {
        public string LastName { get; set; }

        public PersonModel() { }
      

        public PersonModel(string lastName)
        {
            LastName = lastName;
        }
    }
}
