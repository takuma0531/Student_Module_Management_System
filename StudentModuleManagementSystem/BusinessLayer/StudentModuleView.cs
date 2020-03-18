using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class StudentModuleView : IStudentModuleView
    {
        private readonly IStudentModulePresenter _studentModulePresenter;
        private readonly IOptionSelector _optionSelector;
        private readonly IStudentView _studentView;
        private readonly IValidation _validation;

        public StudentModuleView(IStudentModulePresenter studentModulePresenter,
                                 IOptionSelector optionSelector,
                                 IStudentView studentView,
                                 IValidation validation)
        {
            _studentModulePresenter = studentModulePresenter;
            _optionSelector = optionSelector;
            _studentView = studentView;
            _validation = validation;
        }


        // show which modules student takes by selecting student id
        public void ViewStudentModule()
        {
            Console.WriteLine("Please type in the student id to check which modules he/she takes.");
            int studentId = _optionSelector.SelectIntOption();
            bool studentExistance = _validation.CheckStudentExists(studentId);
            bool studentModulesExistence = _validation.CheckStudentModuleExistsByStudentId(studentId);
            List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByStudentId(studentId);
            if (studentExistance)
            {
                if (studentModulesExistence)
                {
                    bool once = true;
                    foreach (StudentModule studentModule in studentModules)
                    {
                        if (once)
                        {
                            Console.WriteLine("*[Student Info]*" + Environment.NewLine);
                            _studentView.ShowStudentEachData(studentModule.Student);
                            Console.WriteLine(Environment.NewLine + "*[Module Info of the student's]*");
                            once = false;
                        }

                        Console.WriteLine($"Module Name: {studentModule.Module.ModuleName}");
                    }
                }

                else
                {
                    Console.WriteLine("The student doesn't take any module so far.");

                    Console.WriteLine(Environment.NewLine + "Press enter/return key to go back to the first page...");
                    Console.ReadLine();
                }

            }
            else
            {
                Console.WriteLine("Sorry, the student data couldn't be found.");
                Console.WriteLine(Environment.NewLine + "Press enter/return key to go back to the first page...");
                Console.ReadLine();
            }


        }

        // show which students are assigned to the module by selecting module id


        // assign student to module


        // get student id and module id to delete student module row
    }
}
