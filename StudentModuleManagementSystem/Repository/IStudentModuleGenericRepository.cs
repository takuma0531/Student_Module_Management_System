using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.Repository
{
    public interface IStudentModuleGenericRepository<StudentModule>
    {
        List<StudentModule> ReadStudentModuleByStudentId(int studentId);

        List<StudentModule> ReadStudentModuleByModuleId(int moduleId);

        void CreateStudentModule(StudentModule studentModule);

        void DeleteStudentModule(int id);
    }
}
