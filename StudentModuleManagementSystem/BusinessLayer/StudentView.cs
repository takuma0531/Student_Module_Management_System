using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class StudentView : IStudentView
    {
        private readonly IStudentPresenter _studentPresenter;
        private readonly IStudentModulePresenter _studentModulePresenter;
        private readonly IOptionSelector _optionSelector;

        string firstName;
        string lastName;
        int facultyNumber;

        public StudentView(IStudentPresenter studentPresenter,
                           IStudentModulePresenter studentModulePresenter,
                           IOptionSelector optionSelector)
        {
            _studentPresenter = studentPresenter;
            _studentModulePresenter = studentModulePresenter;
            _optionSelector = optionSelector;
        }


        // show student each data
        public void ShowStudentEachData(Student student)
        {
            Console.WriteLine($"*Student Id: {student.StudentId}  " +
                              $"First Name: {student.FirstName}  " +
                              $"Last Name: {student.LastName}  " +
                              $"Faculty Number: {student.FacultyNumber}" + Environment.NewLine);
        }


        // input student first name
        public string InputStudentFirstName()
        {
            Console.WriteLine("Please type in first name of new student. ");
            firstName = Console.ReadLine();
            while (firstName == "")
            {
                if (firstName == "")
                {
                    Console.WriteLine("Please enter the first name.");
                    firstName = Console.ReadLine();
                }
            }
            return firstName;
        }


        // input student last name
        public string InputStudentLastName()
        {
            Console.WriteLine("Please type in last name of new student.");
            lastName = Console.ReadLine();
            while (lastName == "")
            {
                if (lastName == "")
                {
                    Console.WriteLine("Please enter the last name.");
                    lastName = Console.ReadLine();
                }
            }
            return lastName;
        }


        // input student faculty number
        public int InputStudentFacultyNumber()
        {
            Console.WriteLine("please type in the faculty number of new student.");
            string facultyNumberInput = Console.ReadLine();
            while (facultyNumberInput == "" || facultyNumberInput.GetType() == typeof(string))
            {
                if (facultyNumberInput == "")
                {
                    Console.WriteLine("Please enter number in the faculty number.");
                    facultyNumberInput = Console.ReadLine();
                }
                try
                {
                    facultyNumber = int.Parse(facultyNumberInput);
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter number in the faculty number.");
                    facultyNumberInput = Console.ReadLine();
                }

            }
            return facultyNumber;
        }


        // show all the students data
        public List<Student> ViewStudents()
        {
            List<Student> students = _studentPresenter.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine(Environment.NewLine + "Sorry, any student data is not registered.");
            }
            else
            {
                Console.WriteLine("All the students data is below." + Environment.NewLine);
                Console.WriteLine("[All Students Info]" + Environment.NewLine);
                foreach (Student student in students)
                {
                    ShowStudentEachData(student);
                }
            }
            return students;
        }


        // show a student data
        public void ViewStudent()
        {
            Student student = _optionSelector.SelectWayOfChoosingStudent();
            if (student != null)
            {
                Console.WriteLine("[Student Info]" + Environment.NewLine);
                ShowStudentEachData(student);
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Sorry, the student data couldn't be found.");
            }

        }


        // register new student 
        public void RegisterStudent()
        {
            InputStudentFirstName();
            InputStudentLastName();
            InputStudentFacultyNumber();

            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                FacultyNumber = facultyNumber
            };

            _studentPresenter.RegisterStudent(student);
            Console.WriteLine("Successfully registered.");
        }


        // update student data
        public void EditStudent()
        {
            List<Student> students = ViewStudents();

            if (students.Count != 0)
            {
                Student student = _optionSelector.SelectWayOfChoosingStudent();

                if (student == null)
                {
                    Console.WriteLine(Environment.NewLine + "Sorry, the student data couldn't be found.");
                }
                else
                {
                    firstName = InputStudentFirstName();
                    lastName = InputStudentLastName();
                    facultyNumber = InputStudentFacultyNumber();

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.FacultyNumber = facultyNumber;

                    _studentPresenter.EditStudent(student);

                    Console.WriteLine(Environment.NewLine + "Successfully updated.");
                }
            }
            else { }


        }


        // delete
        public void DeleteStudent()
        {
            List<Student> students = ViewStudents();

            if (students.Count != 0)
            {
                Student student = _optionSelector.SelectWayOfChoosingStudent();

                if (student == null)
                {
                    Console.WriteLine(Environment.NewLine + "The student data doesn't exist.");
                }
                else
                {
                    List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByStudentId(student.StudentId);
                    if (studentModules.Count == 0)
                    {
                        _studentPresenter.DeleteStudent(student.StudentId);
                        Console.WriteLine(Environment.NewLine + "Successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("The student still has some modules. Please unaasign the student to all the modules, so you can delete the data.");
                    }
                }
            }
            else { }
        }
    }
}
