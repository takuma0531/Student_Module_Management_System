using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public interface IStudentPresenter
    {
        List<Student> GetStudents();

        Student GetStudentById(int id);

        Student GetStudentByFirstName(string firstName);

        Student GetStudentByLastName(string lastName);

        Student GetStudentByFacultyNumber(int facultyNumber);

        void EditStudent(Student student);

        void RegisterStudent(Student student);

        void DeleteStudent(int id);
    }
}
