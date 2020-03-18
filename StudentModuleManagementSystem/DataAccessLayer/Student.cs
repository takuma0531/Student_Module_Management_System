using System;
using System.Collections.Generic;

namespace StudentModuleManagementSystem.DataAccessLayer
{
    public partial class Student
    {
        public Student()
        {
            StudentModule = new HashSet<StudentModule>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FacultyNumber { get; set; }

        public virtual ICollection<StudentModule> StudentModule { get; set; }
    }
}
