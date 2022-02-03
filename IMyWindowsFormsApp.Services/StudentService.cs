using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace IMyWindowsFormsApp.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(Student model)
        {
            _studentRepository.Add(model);
        }

        public Student Get(Guid id)
        {
            return _studentRepository.Get(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public IEnumerable<Student> GetAllByTeacher(Guid id)
        {
            return _studentRepository.GetAllByTeacher(id);
        }
        public void Remove(Student model)
        {
            _studentRepository.Remove(model);
        }
        public void Update(Student model)
        {
            _studentRepository.Update(model);
        }
        public void Save()
        {
            _studentRepository.Save();
        }

    }
}
