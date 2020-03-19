using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.BusinessLayer
{
    public class ModuleView : IModuleView
    {
        private readonly IModulePresenter _modulePresenter;
        private readonly IOptionSelector _optionSelector;

        string moduleName;

        public ModuleView(IModulePresenter modulePresenter, IOptionSelector optionSelector)
        {
            _modulePresenter = modulePresenter;
            _optionSelector = optionSelector;
        }


        // input module name
        public string InputModuleName()
        {
            Console.WriteLine("Please type in module name");
            moduleName = Console.ReadLine();
            while (moduleName == "")
            {
                if (moduleName == "")
                {
                    Console.WriteLine("Please enter the module name.");
                    moduleName = Console.ReadLine();
                }
            }
            return moduleName;
        }


        // show all the modules data
        public List<Module> ViewModules()
        {
            List<Module> modules = _modulePresenter.GetModules();
            if (modules.Count == 0)
            {
                Console.WriteLine(Environment.NewLine + "Sorry, any module data is not registered.");
            }
            else
            {
                Console.WriteLine("All the modules data is below." + Environment.NewLine);
                Console.WriteLine("[All Modules Info]" + Environment.NewLine);
                foreach (Module module in modules)
                {
                    Console.WriteLine($"*Module Id: {module.ModuleId}  " +
                                      $"Module Name: {module.ModuleName}" + Environment.NewLine);
                }
            }
            return modules;
        }


        // register new module
        public void RegisterModule()
        {
            InputModuleName();

            Module module = new Module()
            {
                ModuleName = moduleName
            };

            _modulePresenter.RegisterModule(module);

            Console.WriteLine(Environment.NewLine + "Successfully registered.");
        }


        // update module data
        public void EditModule()
        {
            List<Module> modules = ViewModules();

            if (modules.Count != 0)
            {
                Console.WriteLine("Please type in the module id to edit.");
                int selected = _optionSelector.SelectIntOption();
                Module module = _modulePresenter.GetModuleById(selected);

                if (module == null)
                {
                    Console.WriteLine(Environment.NewLine + "Sorry, the module data couldn't be found.");
                }
                else
                {
                    module.ModuleName = InputModuleName();
                    _modulePresenter.EditModule(module);

                    Console.WriteLine(Environment.NewLine + "Successfully updated.");
                }
            }
            else { }
        }


        // delete module data
        public void DeleteModule()
        {
            List<Module> modules = ViewModules();

            if (modules.Count != 0)
            {
                Console.WriteLine("Please type in the module id to delete.");
                int selected = _optionSelector.SelectIntOption();
                Module module = _modulePresenter.GetModuleById(selected);

                if (module == null)
                {
                    Console.WriteLine(Environment.NewLine + "The module data doesn't exist.");
                }
                else
                {
                    int id = module.ModuleId;
                    _modulePresenter.DeleteModule(id);

                    Console.WriteLine(Environment.NewLine + "Successfully deleted.");
                }
            }
            else { }
        }
    }
}
