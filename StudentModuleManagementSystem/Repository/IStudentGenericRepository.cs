using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.Repository
{

    public interface IStudentGenericRepository<Student> where Student : class
    {
        List<Student> ReadAll();

        Student ReadById(int id);

        Student ReadByFirstName(string firstName);

        Student ReadByLastName(string lastName);

        Student ReadByFacultyNumber(int facultyNumber);

        void Create(Student student);

        void Update(Student student);

        void Delete(int id);
    }


}

