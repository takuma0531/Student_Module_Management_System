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
        private readonly IStudentPresenter _studentPresenter;
        private readonly IModulePresenter _modulePresenter;

        public StudentModuleView(IStudentModulePresenter studentModulePresenter,
                                 IStudentPresenter studentPresenter,
                                 IModulePresenter modulePresenter,
                                 IOptionSelector optionSelector,
                                 IStudentView studentView,
                                 IValidation validation)
        {
            _studentModulePresenter = studentModulePresenter;
            _studentPresenter = studentPresenter;
            _modulePresenter = modulePresenter;
            _optionSelector = optionSelector;
            _studentView = studentView;
            _validation = validation;
            
        }


        // show which modules student takes by selecting student id
        public void ViewStudentModuleByStudentId()
        {
            Console.WriteLine("Please type in the student id to check which modules he/she takes.");
            int studentId = _optionSelector.SelectIntOption();
            Student student = _studentPresenter.GetStudentById(studentId);
            List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByStudentId(studentId);

            if (student != null)
            {
                if (studentModules.Count != 0)
                {
                    bool once = true;
                    foreach (StudentModule studentModule in studentModules)
                    {
                        if (once)
                        {
                            Console.WriteLine("[Student Info]" + Environment.NewLine);
                            _studentView.ShowStudentEachData(studentModule.Student);
                            Console.WriteLine(Environment.NewLine + "[Module Info of the student's]");
                            once = false;
                        }

                        Console.WriteLine($"Module Id: {studentModule.Module.ModuleId}  Module Name: {studentModule.Module.ModuleName}");
                    }
                }

                else
                {
                    Console.WriteLine("The student doesn't take any module so far.");
                    _optionSelector.PressKey();
                }

            }
            else
            {
                Console.WriteLine("Sorry, the student data couldn't be found.");
                _optionSelector.PressKey();
            }


        }

        // show which students are assigned to the module by selecting module id
        public void ViewStudentModuleByModuleId()
        {
            Console.WriteLine("Please type in the module id to check which students are assigned to the module.");
            int moduleId = _optionSelector.SelectIntOption();
            Module module = _modulePresenter.GetModuleById(moduleId);
            List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByModuleId(moduleId);

            if (module != null)
            {
                if (studentModules.Count != 0)
                {
                    bool once = true;
                    foreach (StudentModule studentModule in studentModules)
                    {
                        if (once)
                        {
                            Console.WriteLine("[Module Info]" + Environment.NewLine);
                             Console.WriteLine($"Module Id: {studentModule.Module.ModuleId}  Module Name: {studentModule.Module.ModuleName}");
                            Console.WriteLine(Environment.NewLine + "[Student Info of the module]");
                            once = false;
                        }

                        _studentView.ShowStudentEachData(studentModule.Student);
                    }
                }
                else
                {
                    Console.WriteLine("The module is not assigned to any students so far.");
                    _optionSelector.PressKey();
                }

            }
            else
            {
                Console.WriteLine("Sorry, the module data couldn't be found.");
                _optionSelector.PressKey();
            }
        }


        // assign student to module
        public void AssignStudentToModule()
        {
            Console.WriteLine("Please type in student id to assign the student to a module.");
            int studentId = _optionSelector.SelectIntOption();
            Student student = _studentPresenter.GetStudentById(studentId);

            Console.WriteLine("Please type in module id to assign the student to the module.");
            int moduleId = _optionSelector.SelectIntOption();
            Module module = _modulePresenter.GetModuleById(moduleId);

            if (student != null && module != null)
            {
                if (student.StudentId != studentId && module.ModuleId != moduleId)
                {
                    StudentModule studentModule = new StudentModule()
                    {
                        StudentId = student.StudentId,
                        ModuleId = module.ModuleId
                    };

                    _studentModulePresenter.RegisterStudentModule(studentModule);

                    Console.WriteLine("Successfully assigned.");
                    _optionSelector.PressKey();
                }
                else
                {
                    Console.WriteLine("The student has already taken the module.");
                    _optionSelector.PressKey();
                }
        
            }
            else
            {
                Console.WriteLine("Sorry, the student data or the module data couldn't be found.");
                _optionSelector.PressKey();
            }
        }


        // get student id and module id to delete student module row
        public void UnassignStudentToModule()
        {
            Console.WriteLine("Please type in student id to unassign the student to a module.");
            int studentId = _optionSelector.SelectIntOption();
            Student student = _studentPresenter.GetStudentById(studentId);

            Console.WriteLine("Please type in module id to unassign the student to the module.");
            int moduleId = _optionSelector.SelectIntOption();
            Module module = _modulePresenter.GetModuleById(moduleId);

            if (student != null && module != null)
            {
                List<StudentModule> studentModules = _studentModulePresenter.GetStudentModuleByModuleId(moduleId);

                foreach (StudentModule studentModule in studentModules)
                {
                    if (studentModule.StudentId == studentId && studentModule.ModuleId == moduleId)
                    {
                        _studentModulePresenter.DeleteStudentModule(studentId);

                        Console.WriteLine("Successfully unassigned.");
                        _optionSelector.PressKey();
                    }
                    else if (studentModule.StudentId != studentId && studentModule.ModuleId != moduleId)
                    {
                        Console.WriteLine("The student doesn't take the module.");
                        _optionSelector.PressKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, the student data or the module data couldn't be found.");
                _optionSelector.PressKey();
            }

        }
    }
}
