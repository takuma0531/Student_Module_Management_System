using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentModulePresenter
    {
        List<StudentModule> GetStudentModuleByStudentId(int studentId);

        List<StudentModule> GetStudentModuleByModuleId(int moduleId);

        void RegisterStudentModule(StudentModule studentModule);

        void DeleteStudentModule(int id);
    }
}
