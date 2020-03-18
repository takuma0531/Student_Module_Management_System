using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.Repository
{
    public class StudentGenericRepository : IStudentGenericRepository<Student>
    {
        protected readonly StudentModuleManagementDatabaseContext _context;
        protected readonly DbSet<Student> _table;

        public StudentGenericRepository(StudentModuleManagementDatabaseContext context)
        {
            this._context = context;

            this._table = _context.Set<Student>();
        }

        public List<Student> ReadAll()
        {
            return _table.ToList();
        }


        public Student ReadById(int id)
        {
            return _table.Find(id);
        }

        public Student ReadByFirstName(string firstName)
        {
            return _context.Student.SingleOrDefault(student => student.FirstName == firstName);
        }

        public Student ReadByLastName(string lastName)
        {
            return _context.Student.SingleOrDefault(student => student.LastName == lastName);
        }

        public Student ReadByFacultyNumber(int facultyNumber)
        {
            return _context.Student.SingleOrDefault(student => student.FacultyNumber == facultyNumber);
        }

        public void Update(Student student)
        {
            _table.Update(student);
            _context.SaveChanges();
        }


        public void Create(Student student)
        {
            _table.Add(student);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            Student entityToDelete = _table.Find(id);
            _table.Remove(entityToDelete);
            _context.SaveChanges();

        }
    }
}
