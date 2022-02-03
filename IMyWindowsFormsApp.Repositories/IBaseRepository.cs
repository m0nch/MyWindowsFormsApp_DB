using IMyWindowsFormsApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T model);
        void Remove(T model);
        void Update(T model);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
