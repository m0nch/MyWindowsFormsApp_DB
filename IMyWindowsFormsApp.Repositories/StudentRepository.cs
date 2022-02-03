using IMyWindowsFormsApp.Data.DataProvider;
//using IMyWindowsFormsApp.Data.DB;
using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<Student> students = null;

        public StudentRepository() : base()
        {
            _dbContext = new MyDbContext();
            students = _dbContext.Set<Student>();
        }
        public StudentRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            students = _dbContext.Set<Student>();
        }

        public override void Add(Student model)
        {
            _dbContext.Students.Add(model);
        }

        public override Student Get(Guid id)
        {
            return _dbContext.Students.Find(id);
        }

        public Address GetAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public IEnumerable<Student> GetAllByTeacher(Guid id)
        {
            var students = new List<Student>();
            foreach (var item in _dbContext.Students)
            {
                if (item.TeacherId == id)
                    students.Add(item);
            }
            return students;
        }
        public override void Remove(Student model)
        {
            Student student = _dbContext.Students.Find(model.Id);
            _dbContext.Students.Remove(student);
        }
        public override void Update(Student model)
        {
            Student oldStudent = _dbContext.Students.Find(model.Id);
            _dbContext.Students.Remove(oldStudent);
            _dbContext.Students.Add(model);
            //_dbContext.Students.Attach(model);
            //_dbContext.Entry(model).State = EntityState.Modified;
        }
        public override void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
