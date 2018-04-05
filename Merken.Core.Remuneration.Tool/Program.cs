using Merken.Common;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Interfaces;
using Merken.Core.Remuneration.Services;
using Merken.Core.Remuneration.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BootStrap();

                var employeeRepo = IOCContainer.Resolve<IEmployeeRepository>();
                var remunRepo = IOCContainer.Resolve<IRemunerationRepository>();
                var performanceRepo = IOCContainer.Resolve<IPerformanceRepository>();
                var salaryCalcService = IOCContainer.Resolve<ISalaryCalculationService>();

                var employee = employeeRepo.GetEmployeeInformation(0);
                var performanceInformation = performanceRepo.GetPerformanceInformation(0, 0);

                Console.WriteLine($"Calculating salary for {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"");

                var remunLines = salaryCalcService.CalculateSalaryForEmployee(0, 0);

                PrintPaySlip(remunLines);
                Console.WriteLine($"");

                var salary = remunLines.Sum(r => r.Value);

                Console.WriteLine($"Salary is {salary}");
                Console.WriteLine($"");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                Console.WriteLine($"Stack {ex.StackTrace}");
                Console.WriteLine($"");

            }
            finally
            {
                Console.WriteLine($"END OF PROGRAM");
                Console.ReadKey();
            }
        }

        private static void PrintPaySlip(IEnumerable<IRemunCalculationResult> remunResults)
        {
            if (remunResults != null && remunResults.Any())
            {
                foreach (var result in remunResults)
                {
                    Console.WriteLine($"{result.Code} {result.Description} {result.Days} {result.Hours} {result.Value}");
                    Console.WriteLine($"");
                }
            }
        }

        private static void BootStrap()
        {
            //Repos
            //IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            //IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryBlueCollar>();
            //IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryBlueCollar>();
            //IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryBlueCollar>();

            ////Services
            //IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();

            ////Repos
            IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryWhiteCollar>();
            IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunCalculationRepository, RemunComponentRepository>();

            //Services
            IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();
        }
    }
}
