using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentModuleManagementSystem.BusinessLayer;
using StudentModuleManagementSystem.DataAccessLayer;
using StudentModuleManagementSystem.PresentationLayer;
using StudentModuleManagementSystem.Repository;
using System;

namespace EventManager
{
    public class Program
    {
        private readonly IPagesDisplayer _pagesDisplayer;

        public Program(IPagesDisplayer pagesDisplayer)
        {
            _pagesDisplayer = pagesDisplayer;
        }

        //Entry
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = RegisterServices();
            Program program = serviceProvider.GetService<Program>();

            while (true)
            {
                program._pagesDisplayer.DisplayHomePage();
            }

        }

        //Support
        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            // repositories
            services.AddScoped<IStudentGenericRepository<Student>, StudentGenericRepository>();

            // services
            services.AddScoped<IStudentPresenter, StudentPresenter>();
            services.AddScoped<IOptionSelector, OptionSelector>();
            services.AddScoped<IStudentView, StudentView>();
            services.AddScoped<IPagesDisplayer, PagesDisplayer>();

            // program
            services.AddScoped<Program>();

            // dbcontext
            services.AddDbContext<StudentModuleManagementDatabaseContext>(options => options
                   .UseSqlServer("Server=localhost,1433;Database=StudentManagementDb;User=sa;Password=tellmewhatyouaredoingrightnow0225howistheweathertodayitissunnytodayhowaboutyou"));

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        private static void DisposeServices(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable sp)
            {
                sp.Dispose();
            }
        }
    }
}
