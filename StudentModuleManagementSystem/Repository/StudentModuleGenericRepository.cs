using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.Repository
{
    public class StudentModuleGenericRepository : IStudentModuleGenericRepository<StudentModule>
    {
        protected readonly StudentModuleManagementDatabaseContext _context;
        protected readonly DbSet<StudentModule> _table;

        public StudentModuleGenericRepository(StudentModuleManagementDatabaseContext context)
        {
            this._context = context;

            this._table = _context.Set<StudentModule>();
        }


        // read student module data by student id
        public List<StudentModule> ReadStudentModuleByStudentId(int studentId)
        {
            var studentModuleData = from studentModule in _context.StudentModule
                                    where studentModule.StudentId == studentId
                                    select new StudentModule()
                                    {
                                        StudentId = studentModule.StudentId,
                                        ModuleId = studentModule.ModuleId,

                                        Student = studentModule.Student,
                                        Module = studentModule.Module
                                    };

            return studentModuleData.ToList();

        }


        // read student module by module id
        public List<StudentModule> ReadStudentModuleByModuleId(int moduleId)
        {
            var studentModuleData = from studentModule in _context.StudentModule
                                    where studentModule.ModuleId == moduleId
                                    select new StudentModule()
                                    {
                                        StudentId = studentModule.StudentId,
                                        ModuleId = studentModule.ModuleId,

                                        Student = studentModule.Student,
                                        Module = studentModule.Module
                                    };

            return studentModuleData.ToList();

        }


        // function which assign student to module
        public void CreateStudentModule(StudentModule studentModule)
        {
            _table.Add(studentModule);
            _context.SaveChanges();
        }


        // delete student module row by student id
        public void DeleteStudentModule(int id)
        {
            StudentModule studentModuleToDelete = _context.StudentModule.FirstOrDefault(studentModule => studentModule.Student.StudentId == id);
            _table.Remove(studentModuleToDelete);
            _context.SaveChanges();
        }

    }
}
