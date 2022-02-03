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
    public interface IStudentService
    {
        void Add(Student model);
        void Remove(Student model);
        void Update(Student model);
        Student Get(Guid id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAllByTeacher(Guid id);
        void Save();
    }
}
