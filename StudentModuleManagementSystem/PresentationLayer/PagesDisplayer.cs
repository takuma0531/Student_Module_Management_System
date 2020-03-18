using System;
using StudentModuleManagementSystem.BusinessLayer;


namespace StudentModuleManagementSystem.PresentationLayer
{
    public class PagesDisplayer : IPagesDisplayer
    {
        private readonly IOptionSelector _optionSelector;
        private readonly IStudentView _studentView;
        private readonly IModuleView _moduleView;

        public PagesDisplayer(IOptionSelector optionSelector, IStudentView studentView, IModuleView moduleView)
        {
            _optionSelector = optionSelector;
            _studentView = studentView;
            _moduleView = moduleView;
        }

        public void DisplayHomePage()
        {
            Console.WriteLine("Hello! May I help you?" + Environment.NewLine);
            Console.WriteLine("Manage student data : 1 {0}" +
                              "Manage module data  : 2 {0}" +
                              "Exit                : 0 {0}", Environment.NewLine);

            string selected = _optionSelector.SelectStringOption();
            switch (selected)
            {
                case "1":
                    DisplayStudentPage();
                    break;

                case "2":
                    DisplayModulePage();
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
            Console.WriteLine("Register new student data                                : 1 {0}" +
                              "Show the specified student data                          : 2 {0}" +
                              "Show which modules are assigned to the specified student : 3 {0}" +
                              "Show all the students data                               : 4 {0}" +
                              "Edit the specified student data                          : 5 {0}" +
                              "Delete the specified student data                        : 6 {0}" +
                              "Go back to the previous page                             : 0 {0}", Environment.NewLine);

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
                    // todo
                    break;

                case "4":
                    _studentView.ViewStudents();
                    break;

                case "5":
                    _studentView.EditStudent();
                    break;

                case "6":
                    _studentView.DeleteStudent();
                    break;

                case "0":
                    break;
            }

            Console.Write(Environment.NewLine + "Press enter/return key to continue..." + Environment.NewLine);
            Console.ReadLine();
        }

        public void DisplayModulePage()
        {
            Console.WriteLine("########## You can select your action below. ##########" + Environment.NewLine);
            Console.WriteLine("Register new module data                                 : 1 {0}" +
                              "Show all the modules data                                : 2 {0}" +
                              "Show which students are assigned to the specified module : 3 {0}" +
                              "Edit the specified module data                           : 4 {0}" +
                              "Delete the specified module data                         : 5 {0}" +
                              "Go back to the previous page                             : 0 {0}", Environment.NewLine);

            string selected = _optionSelector.SelectStringOption();

            switch (selected)
            {
                case "1":
                    _moduleView.RegisterModule();
                    break;

                case "2":
                    _moduleView.ViewModules();
                    break;

                case "3":
                    // todo
                    break;

                case "4":
                    _moduleView.EditModule();
                    break;

                case "5":
                    // todo
                    break;

                case "0":
                    break;
            }

            Console.Write(Environment.NewLine + "Press enter/return key to continue..." + Environment.NewLine);
            Console.ReadLine();
        }
    }
}
