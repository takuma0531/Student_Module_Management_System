using System;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentView
    {
        void ViewStudents();

        void ViewStudent();

        void RegisterStudent();

        void EditStudent();

        void DeleteStudent();
    }
}
