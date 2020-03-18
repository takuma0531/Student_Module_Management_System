using System;
using System.Collections.Generic;
using StudentModuleManagementSystem.BusinessLayer;
using StudentModuleManagementSystem.DataAccessLayer;

namespace StudentModuleManagementSystem.PresentationLayer
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
        public void ViewModules()
        {
            List<Module> modules = _modulePresenter.GetModules();
            if (modules.Count == 0)
            {
                Console.WriteLine(Environment.NewLine + "Sorry, no module data is registered.");
            }
            else
            {
                Console.WriteLine("All the modules data is below." + Environment.NewLine);
                Console.WriteLine("*[All Modules Info]*" + Environment.NewLine);
                foreach (Module module in modules)
                {
                    Console.WriteLine($"*Module Id: {module.ModuleId}  " +
                                      $"Module Name: {module.ModuleName}");
                }
            }
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


        // delete module data
        public void DeleteModule()
        {
            Console.WriteLine("Please type in the module id to edit.");
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
    }
}
