using System;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentView
    {
        void ShowStudentEachData(Student student);

        void ViewStudents();

        void ViewStudent();

        void RegisterStudent();

        void EditStudent();

        void DeleteStudent();
    }
}
