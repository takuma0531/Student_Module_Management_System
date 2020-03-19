using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentView
    {
        void ShowStudentEachData(Student student);

        List<Student> ViewStudents();

        void ViewStudent();

        void RegisterStudent();

        void EditStudent();

        void DeleteStudent();
    }
}
