using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;
using StudentModuleManagementSystem.Repository;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class StudentModulePresenter : IStudentModulePresenter
    {
        private readonly IStudentModuleGenericRepository<StudentModule> _studentModuleGenericRepository;

        public StudentModulePresenter(IStudentModuleGenericRepository<StudentModule> studentModuleGenericRepository)
        {
            _studentModuleGenericRepository = studentModuleGenericRepository;
        }

        // fetch student module data by student id
        public List<StudentModule> GetStudentModuleByStudentId(int studentId)
        {
            return _studentModuleGenericRepository.ReadStudentModuleByStudentId(studentId);
        }

        // fetch student module data by module id
        public List<StudentModule> GetStudentModuleByModuleId(int moduleId)
        {
            return _studentModuleGenericRepository.ReadStudentModuleByModuleId(moduleId);
        }

        // create a student module row
        public void RegisterStudentModule(StudentModule studentModule)
        {
            _studentModuleGenericRepository.CreateStudentModule(studentModule);
        }

        // delete a student module row
        public void DeleteStudentModule(int id)
        {
            _studentModuleGenericRepository.DeleteStudentModule(id);
        }
    }
}
