using System;
using System.Text.Json.Serialization;

namespace DAL.Base
{
    [Serializable]
    public abstract class Person
    {
        public string LastName { get; set; }

        public Person(string lastName)
        {
            LastName = lastName;
        }

        public Person() { }

        public virtual string GetInfo()
        {
            return $"{LastName}";
        }
    }
}