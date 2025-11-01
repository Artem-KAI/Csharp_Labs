using BLL.Base;
using BLL.Models;
using DAL.Base;
using DAL.Entities;
using System;

namespace BLL.Mappers
{
    public static class PersonMapper
    {
        public static PersonModel ToModel(Person entity)
        {
            return entity switch
            {
                Student s => new StudentModel(
                    s.LastName,
                    s.Course,
                    s.StudentCard,
                    s.AverageGrade,
                    s.Country,
                    s.RecordBookNumber),

                Manager m => new ManagerModel(
                    m.LastName,
                    m.EmployeeID),

                McDonaldsWorker w => new McDonaldsWorkerModel(
                    w.LastName,
                    w.EmployeeID),

                _ => throw new InvalidOperationException("Unknown entity type")
            };
        }

        public static Person ToEntity(PersonModel model)
        {
            return model switch
            {
                StudentModel s => new Student(
                    s.LastName,
                    s.Course,
                    s.StudentCard,
                    s.AverageGrade,
                    s.Country,
                    s.RecordBookNumber),

                ManagerModel m => new Manager(
                    m.LastName,
                    m.EmployeeID),

                McDonaldsWorkerModel w => new McDonaldsWorker(
                    w.LastName,
                    w.EmployeeID),

                _ => throw new InvalidOperationException("Unknown model type")
            };
        }
    }
}
