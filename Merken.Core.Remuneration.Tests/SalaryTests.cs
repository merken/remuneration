using System;
using Merken.Core.Remuneration.Interfaces;
using Merken.Core.Remuneration.Tests.Repositories;
using Merken.Common;
using System.Linq;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Services;
using Xunit;

namespace Merken.Core.Remuneration.Tests
{
    public class SalaryTests
    {
        [Fact]
        public void BlueCollarSalaryTest()
        {
            //Arrange
            BootStrapBlueCollar();

            //Act
            var salaryCalcService = IOCContainer.Resolve<ISalaryCalculationService>();
            var remunLines = salaryCalcService.CalculateSalaryForEmployee(0, 0);

            var salary = remunLines.Sum(r => r.Value);

            //Assert
            Assert.Equal(remunLines.Count, 9);
            Assert.Equal(1680.27d, salary);
        }

        [Fact]
        public void WhiteCollarSalaryTest()
        {
            //Arrange
            BootStrapWhiteCollar();

            //Act
            var salaryCalcService = IOCContainer.Resolve<ISalaryCalculationService>();
            var remunLines = salaryCalcService.CalculateSalaryForEmployee(0, 0);

            var salary = remunLines.Sum(r => r.Value);

            //Assert
            Assert.NotEqual(remunLines.Count, 0);
            Assert.NotEqual(salary, 0);
        }


        [Fact]
        public void WhiteCollarSalaryBasic2Test()
        {
            //Arrange
            BootStrapWhiteCollarBasic2();

            //Act
            var salaryCalcService = IOCContainer.Resolve<ISalaryCalculationService>();
            var remunLines = salaryCalcService.CalculateSalaryForEmployee(0, 0);

            var salary = remunLines.Sum(r => r.Value);

            //Assert
            Assert.NotEqual(remunLines.Count, 0);
            Assert.NotEqual(salary, 0);
        }


        [Fact]
        public void WhiteCollarBasicSalaryTest()
        {
            //Arrange
            BootStrapWhiteCollarBasic();

            //Act
            var salaryCalcService = IOCContainer.Resolve<ISalaryCalculationService>();
            var remunLines = salaryCalcService.CalculateSalaryForEmployee(0, 0);

            var salary = remunLines.Sum(r => r.Value);

            //Assert
            Assert.NotEqual(remunLines.Count, 0);
            Assert.NotEqual(salary, 0);
        }

        private static void BootStrapBlueCollar()
        {
            IOCContainer.Clear();

            //Repos
            IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryBlueCollar>();
            IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryBlueCollar>();
            IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryBlueCollar>();
            IOCContainer.Register<IRemunCalculationRepository, RemunComponentRepository>();

            //Services
            IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();
        }

        private static void BootStrapWhiteCollar()
        {
            IOCContainer.Clear();

            //Repos
            IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryWhiteCollar>();
            IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunCalculationRepository, RemunComponentRepository>();

            //Services
            IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();
        }

        private static void BootStrapWhiteCollarBasic()
        {
            IOCContainer.Clear();

            //Repos
            IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryWhiteCollarBasic>();
            IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryWhiteCollar>();
            IOCContainer.Register<IRemunCalculationRepository, RemunComponentRepository>();

            //Services
            IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();
        }

        private static void BootStrapWhiteCollarBasic2()
        {
            IOCContainer.Clear();

            //Repos
            IOCContainer.Register<IEmployerRepository, FakeEmployerRepository>();
            IOCContainer.Register<IEmployeeRepository, FakeEmployeeRepositoryWhiteCollar2>();
            IOCContainer.Register<IRemunerationRepository, FakeRemunerationRepositoryWhiteCollarBasic2>();
            IOCContainer.Register<IPerformanceRepository, FakePerformanceRepositoryWhiteCollar2>();
            IOCContainer.Register<IRemunCalculationRepository, RemunComponentRepository>();

            //Services
            IOCContainer.Register<ISalaryCalculationService, SalaryCalculationService>();
        }
    }
}
