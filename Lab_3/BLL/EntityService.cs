using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Entities;
using BLL.Exceptions;

namespace BLL
{
    public class EntityService
    {
        private readonly EntityContext _context;
        private List<Student> _students;

        public EntityService(EntityContext context)
        {
            _context = context;
            _students = new List<Student>();
        }

        public List<Student> LoadStudents(string filePath)
        {
            _students = _context.Load(filePath); // _students – internal collection, внутрішня колекція
            return _students;
        }

        public void SaveStudents(string path)
        {
            _context.Save(path, _students);
        }

        public void AddStudent(Student s)
        {
            _students.Add(s);
        }

        public List<Student> GetUkrainianThirdCourseStudents()
        {
            var list = _students.Where(s => s.Course == 3 && s.Country.ToLower() == "ukraine").ToList();
            if (list.Count == 0)
                throw new StudentNotFoundException("There are no students from 3 course from Ukraine!");
            return list;
        }

        public int CountUkrainianThirdCourseStudents()
        {
            return _students.Count(s => s.Course == 3 && s.Country.ToLower() == "ukraine");
        }
    }
}
