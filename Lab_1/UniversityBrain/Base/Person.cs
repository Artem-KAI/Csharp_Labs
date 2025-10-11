using System;

namespace UniversityBrain.Base
{
    public abstract class Person
    {
        public string name { get; set; }
        public string surname { get; set; }

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public virtual string GetStudentInfo()
        {   
            return $"{name} {surname}";
        }
    }
}
