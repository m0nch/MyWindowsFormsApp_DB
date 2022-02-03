using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Services
{
    public interface ITeacherService
    {
        void Add(Teacher model);
        void Remove(Teacher model);
        void Update(Teacher model);
        Teacher Get(Guid id);
        IEnumerable<Teacher> GetAll();
        void Save();
    }
}
