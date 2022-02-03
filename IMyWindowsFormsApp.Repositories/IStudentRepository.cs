using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Address GetAddress(Guid id);
        IEnumerable<Student> GetAllByTeacher(Guid id);
    }
}
