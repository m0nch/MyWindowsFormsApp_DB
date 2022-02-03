using IMyWindowsFormsApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<Teacher> teachers = null;
        public TeacherRepository() : base()
        {
            _dbContext = new MyDbContext();
            teachers = _dbContext.Set<Teacher>();
        }
        public TeacherRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            teachers = _dbContext.Set<Teacher>();
        }
        public override void Add(Teacher model)
        {
            _dbContext.Teachers.Add(model);
        }
        public override Teacher Get(Guid id)
        {
            return _dbContext.Teachers.Find(id);
        }
        public override IEnumerable<Teacher> GetAll()
        {
            return _dbContext.Teachers.ToList();
        }
        public override void Remove(Teacher model)
        {
            Teacher teacher = _dbContext.Teachers.Find(model.Id);
            _dbContext.Teachers.Remove(teacher);
        }
        public override void Update(Teacher model)
        {
            Teacher oldTeacher = _dbContext.Teachers.Find(model.Id);
            _dbContext.Teachers.Remove(oldTeacher);
            _dbContext.Teachers.Add(model);
            //_dbContext.Entry(model).State = EntityState.Modified;
        }
        public override void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
