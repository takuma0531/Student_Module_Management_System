using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;
using StudentModuleManagementSystem.Repository;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class StudentPresenter : IStudentPresenter
    {
        private readonly IStudentGenericRepository<Student> _studentGenericRepository;

        public StudentPresenter(IStudentGenericRepository<Student> studentGenericRepository)
        {
            _studentGenericRepository = studentGenericRepository;
        }

        // read all
        public List<Student> GetStudents()
        {
            return _studentGenericRepository.ReadAll();
        }

        // read student by id
        public Student GetStudentById(int id)
        {
            Student studentData = _studentGenericRepository.ReadById(id);
            return studentData;
        }

        // read student by first name
        public Student GetStudentByFirstName(string firstName)
        {
            return _studentGenericRepository.ReadByFirstName(firstName);
        }

        // read student by last name
        public Student GetStudentByLastName(string lastName)
        {
            return _studentGenericRepository.ReadByLastName(lastName);
        }

        // read student by faculty number
        public Student GetStudentByFacultyNumber(int facultyNumber)
        {
            return _studentGenericRepository.ReadByFacultyNumber(facultyNumber);
        }

        // update student 
        public void EditStudent(Student student)
        {
            _studentGenericRepository.Update(student);
        }

        // create student
        public void RegisterStudent(Student student)
        {
            _studentGenericRepository.Create(student);
        }

        // delete student
        public void DeleteStudent(int id)
        {
            _studentGenericRepository.Delete(id);
        }
    }
}
