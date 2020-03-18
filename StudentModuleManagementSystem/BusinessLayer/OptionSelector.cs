using System;
using StudentModuleManagementSystem.DataAccessLayer;
using StudentModuleManagementSystem.PresentationLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class OptionSelector : IOptionSelector
    {
        private readonly IStudentPresenter _studentPresenter;

        int intSelected;


        public OptionSelector(IStudentPresenter studentPresenter)
        {
            _studentPresenter = studentPresenter;
        }

        public string SelectStringOption()
        {
            string selected = Console.ReadLine();

            return selected;
        }

        public int SelectIntOption()
        {

            string stringSelected = Console.ReadLine();

            while (stringSelected == "" || stringSelected.GetType() == typeof(string))
            {
                if (stringSelected == "")
                {
                    Console.WriteLine("Please enter the id.");
                    stringSelected = Console.ReadLine();
                }
                try
                {
                    intSelected = int.Parse(stringSelected);
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter the id.");
                    stringSelected = Console.ReadLine();
                }
            }
            return intSelected;
        }


        public Student SelectWayOfChoosingStudent()
        {
            Console.WriteLine("########### Please select a way of choosing the student data. ###########{0}" +
                  "By student id                : 1 {0}" +
                  "By student first name        : 2 {0}" +
                  "By student last name         : 3 {0}" +
                  "By student faculty number    : 4 {0}" +
                  "Exit                         : 0 {0}", Environment.NewLine);

            string wayOfSelectingStudent = Console.ReadLine();

            switch (wayOfSelectingStudent)
            {
                case "1":
                    Console.WriteLine("Please type in student id to choose the student data.");
                    int studentId = SelectIntOption();
                    Student studentById = _studentPresenter.GetStudentById(studentId);
                    return studentById;

                case "2":
                    Console.WriteLine("Please type in student first name to choose the student data.");
                    string firstName = SelectStringOption();
                    Student studentByFirstName = _studentPresenter.GetStudentByFirstName(firstName);
                    return studentByFirstName;

                case "3":
                    Console.WriteLine("Please type in student last name to choose the student data.");
                    string lastName = SelectStringOption();
                    Student studentByLastName = _studentPresenter.GetStudentByLastName(lastName);
                    return studentByLastName;

                case "4":
                    Console.WriteLine("Please type in student faculty number to choose the student data.");
                    int facultyNumber = SelectIntOption();
                    Student studentByFacultyNumber = _studentPresenter.GetStudentByFacultyNumber(facultyNumber);
                    return studentByFacultyNumber;

                case "0":
                    Environment.Exit(0);
                    return null;

                default:
                    Console.WriteLine("Please select any correct option.");
                    SelectWayOfChoosingStudent();
                    return null;
            }
        }
    }
}
