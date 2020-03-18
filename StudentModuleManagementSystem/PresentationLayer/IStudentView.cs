using System;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.PresentationLayer
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
