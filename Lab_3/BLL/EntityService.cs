using BLL.Base;
using BLL.Mappers;
using BLL.Models;

using DAL;
using DAL.Base;
using DAL.Entities;


namespace BLL
{
    public class EntityService
    {
        private readonly EntityContext<Person> _context;

        public EntityService(EntityContext<Person> context)
        {
            _context = context;
        }

        public void SavePeople(string filePath, List<PersonModel> people)
        {
            if (people == null) throw new ArgumentNullException(nameof(people));

            var entities = people.Select(PersonMapper.ToEntity).ToList();
            _context.Save(filePath, entities);
        }

        public List<PersonModel> LoadPeople(string filePath)
        {
            var entities = _context.Load(filePath);
            return entities.Select(PersonMapper.ToModel).ToList();
        }

        public List<StudentModel> GetUkrainianThirdCourseStudents(string filePath)
        {
            var all = LoadPeople(filePath);
            return all
                .OfType<StudentModel>()
                .Where(s => s.Country == "Ukraine" && s.Course == 3)
                .ToList();
        }
    }
}

