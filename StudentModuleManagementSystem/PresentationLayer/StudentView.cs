﻿using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.BusinessLayer;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.PresentationLayer
{
    public class StudentView : IStudentView
    {
        private readonly IStudentPresenter _studentPresenter;
        private readonly IOptionSelector _optionSelector;

        string firstName;
        string lastName;
        int facultyNumber;

        public StudentView(IStudentPresenter studentPresenter, IOptionSelector optionSelector)
        {
            _studentPresenter = studentPresenter;
            _optionSelector = optionSelector;
        }

        public void ShowStudentEachData(Student student)
        {
            Console.WriteLine($"*student Id: {student.StudentId}  " +
                              $"First name: {student.FirstName}  " +
                              $"Last name: {student.LastName}  " +
                              $"Faculty Number: {student.FacultyNumber}");
        }

        // input student data
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
        public void ViewStudents()
        {
            List<Student> students = _studentPresenter.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine(Environment.NewLine + "Sorry, no students data is not registered.");
            }
            else
            {
                Console.WriteLine("All the students data is below." + Environment.NewLine);
                Console.WriteLine("*[All Students Info]*" + Environment.NewLine);
                foreach (Student student in students)
                {
                    ShowStudentEachData(student);
                }
            }
        }


        // show a student data
        public void ViewStudent()
        {
            Student student = _optionSelector.SelectWayOfChoosingStudent();
            if (student != null)
            {
                Console.WriteLine("*[Student Info]*" + Environment.NewLine);
                ShowStudentEachData(student);
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Sorry, the student data couldn't be found.");
            }

        }


        // register student 
        public void RegisterStudent()
        {
            firstName = InputStudentFirstName();
            lastName = InputStudentLastName();
            facultyNumber = InputStudentFacultyNumber();

            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                FacultyNumber = facultyNumber
            };

            _studentPresenter.RegisterStudent(student);
        }


        // update
        public void EditStudent()
        {
            Student student = _optionSelector.SelectWayOfChoosingStudent();

            if (student == null)
            {
                Console.WriteLine("Sorry, the student data couldn't be found.");
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

                Console.WriteLine("Successfully updated.");
            }
        }


        // delete
        public void DeleteStudent()
        {
            Student student = _optionSelector.SelectWayOfChoosingStudent();

            if (student == null)
            {
                Console.WriteLine("The student data doesn't exist.");
            }
            else
            {
                _studentPresenter.DeleteStudent(student.StudentId);
                Console.WriteLine("Successfully deleted.");
            }
        }
    }
}