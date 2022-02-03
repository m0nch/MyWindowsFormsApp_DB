using IMyWindowsFormsApp.Data.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMyWindowsFormsApp.Data.DAL;
using System.Data.Entity;

namespace IMyWindowsFormsApp.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<T> table = null;
        public BaseRepository()
        {
            _dbContext = new MyDbContext();
            table = _dbContext.Set<T>();
        }
        public BaseRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }

        public virtual void Add(T model)
        {
            table.Add(model);
        }

        public virtual T Get(Guid id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public virtual void Remove(T model)
        {
            T existing = table.Find(model);
            table.Remove(existing);
        }

        public virtual void Update(T model)
        {
            table.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }
        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
