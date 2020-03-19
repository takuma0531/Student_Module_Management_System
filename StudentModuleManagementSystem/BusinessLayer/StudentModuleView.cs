using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class StudentModuleView : IStudentModuleView
    {
        private readonly IStudentModulePresenter _studentModulePresenter;
        private readonly IStudentPresenter _studentPresenter;
        private readonly IModulePresenter _modulePresenter;
        private readonly IOptionSelector _optionSelector;
        private readonly IStudentView _studentView;
        private readonly IModuleView _moduleView;
        
     
        public StudentModuleView(IStudentModulePresenter studentModulePresenter,
                                 IStudentPresenter studentPresenter,
                                 IModulePresenter modulePresenter,
                                 IOptionSelector optionSelector,
                                 IStudentView studentView,
                                 IModuleView moduleView)
        {
            _studentModulePresenter = studentModulePresenter;
            _studentPresenter = studentPresenter;
            _modulePresenter = modulePresenter;
            _optionSelector = optionSelector;
            _studentView = studentView;
            _moduleView = moduleView;
            
        }


        // show which modules student takes by selecting student id
        public void ViewStudentModuleByStudentId()
        {
            List<Student> students = _studentView.ViewStudents();
            Console.WriteLine(Environment.NewLine);

            if (students.Count != 0)
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
                    }

                }
                else
                {
                    Console.WriteLine("Sorry, the student data couldn't be found.");
                }
            }
            else { }
        }


        // show which students are assigned to the module by selecting module id
        public void ViewStudentModuleByModuleId()
        {
            List<Module> modules = _moduleView.ViewModules();
            Console.WriteLine(Environment.NewLine);

            if (modules.Count != 0)
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
                    }

                }
                else
                {
                    Console.WriteLine("Sorry, the module data couldn't be found.");
                }
            }
            else { }
        }


        // assign student to module
        public void AssignStudentToModule()
        {
            List<Student> students = _studentView.ViewStudents();
            Console.WriteLine(Environment.NewLine);
            List<Module> modules = _moduleView.ViewModules();
            Console.WriteLine(Environment.NewLine);

            if (students.Count != 0 && modules.Count != 0)
            {
                Console.WriteLine("Please type in student id to assign the student to a module.");
                int studentId = _optionSelector.SelectIntOption();
                Student student = _studentPresenter.GetStudentById(studentId);

                Console.WriteLine("Please type in module id to assign the student to the module.");
                int moduleId = _optionSelector.SelectIntOption();
                Module module = _modulePresenter.GetModuleById(moduleId);

                if (student != null && module != null)
                {
                    
                    StudentModule newStudentModule = new StudentModule();

                    List<StudentModule> existingStudentModules = _studentModulePresenter.GetStudentModuleByModuleId(moduleId);
                    foreach (StudentModule existingStudentModule in existingStudentModules)
                    {
                        if (existingStudentModule.StudentId != studentId && existingStudentModule.ModuleId != moduleId)
                        {
                            newStudentModule.StudentId = student.StudentId;
                            newStudentModule.ModuleId = module.ModuleId;

                            _studentModulePresenter.RegisterStudentModule(newStudentModule);

                            Console.WriteLine("Successfully assigned.");
                        }
                        else if (existingStudentModule.StudentId == studentId && existingStudentModule.ModuleId == moduleId)
                        {
                            Console.WriteLine("The student has already taken the module.");
                        }
                    }
                 

                }
                else
                {
                    Console.WriteLine("Sorry, the student data or the module data couldn't be found.");
                }
            }
            else if (students.Count == 0) { }
            else if (modules.Count == 0) { }
            else { }
        }


        // get student id and module id to delete student module row
        public void UnassignStudentToModule()
        {
            List<Student> students = _studentView.ViewStudents();
            Console.WriteLine(Environment.NewLine);
            List<Module> modules = _moduleView.ViewModules();
            Console.WriteLine(Environment.NewLine);

            if (students.Count != 0 && modules.Count != 0)
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
                        }
                        else if (studentModule.StudentId != studentId && studentModule.ModuleId != moduleId)
                        {
                            Console.WriteLine("The student doesn't take the module.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the student data or the module data couldn't be found.");
                }
            }
            else if (students.Count == 0) { }
            else if (modules.Count == 0) { }
            else { }
        }
    }
}
