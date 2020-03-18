using System;
using StudentModuleManagementSystem.BusinessLayer;


namespace StudentModuleManagementSystem.PresentationLayer
{
    public class PagesDisplayer : IPagesDisplayer
    {
        private readonly IOptionSelector _optionSelector;
        private readonly IStudentView _studentView;

        public PagesDisplayer(IOptionSelector optionSelector, IStudentView studentView)
        {
            _optionSelector = optionSelector;
            _studentView = studentView;
        }

        public void DisplayHomePage()
        {
            Console.WriteLine("Hello! May I help you?" + Environment.NewLine);
            Console.WriteLine("About Student : 1 {0}" +
                              "About Module  : 2 {0}" +
                              "Exit          : 0 {0}", Environment.NewLine);

            string selected = _optionSelector.SelectStringOption();
            switch (selected)
            {
                case "1":
                    DisplayStudentPage();
                    break;

                case "2":
                    break;

                case "0":
                    Environment.Exit(0);
                    Console.WriteLine("See you later!");
                    break;
            }
        }

        public void DisplayStudentPage()
        {
            Console.WriteLine("########## You can select your action below. ##########" + Environment.NewLine);
            Console.WriteLine("Register new student data         : 1 {0}" +
                              "Show the specified student data   : 2 {0}" +
                              "Show all the students data        : 3 {0}" +
                              "Edit the specified student data   : 4 {0}" +
                              "Delete the specified student data : 5 {0}" +
                              "Go back to the previous page      : 0 {0}", Environment.NewLine);

            string selected = _optionSelector.SelectStringOption();

            switch (selected)
            {
                case "1":
                    _studentView.RegisterStudent();
                    Console.WriteLine("Successfully registered.");
                    break;

                case "2":
                    _studentView.ViewStudent();
                    break;

                case "3":
                    _studentView.ViewStudents();
                    break;

                case "4":
                    _studentView.EditStudent();
                    break;

                case "5":
                    _studentView.DeleteStudent();
                    break;

                case "0":
                    break;
            }

            Console.Write(Environment.NewLine + "Press enter/return key to continue..." + Environment.NewLine);
            Console.ReadLine();
        }
    }
}
