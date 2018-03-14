using MasGlobal.Core.Behaviors;
using MasGlobal.Core.Behaviors.Functors;
using MasGlobal.Core.DTOs;
using MasGlobal.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MasGlobal.Tests.Behaviors
{
    public class EmployeeBehaviorTests
    {
        private static void BindBasicFunctors(IFunctorFactory factory)
        {
            factory.BindFunctor(typeof(HourlySalaryEmployeeDTO), typeof(HourlySalaryFunctor));
            factory.BindFunctor(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryFunctor));
        }

        private static List<EmployeeDTO> GetDTOs()
        {
            return new List<EmployeeDTO>()
            {
                new MonthlySalaryEmployeeDTO(1, "Test1", "MonthlySalaryEmployee", 0, "", "", 8000),
                new HourlySalaryEmployeeDTO(2, "Test2", "HourlySalaryEmployee", 0, "", "", 200),
                new MonthlySalaryEmployeeDTO(3, "Test3", "MonthlySalaryEmployee", 0, "", "", 6000),
            };
        }

        private static List<EmployeeDTO> GetFailDTOs()
        {
            return new List<EmployeeDTO>()
            {
                new MonthlySalaryEmployeeDTO(1, "Test1", "MonthlySalaryEmployee", 0, "", "", 8000),
                new EmployeeDTO(2, "Test2", "Salary", 0, "", "")
            };
        }

        [Fact]
        public async Task GetAllEmployees()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(s => s.GetAllAsync())
                .ReturnsAsync(GetDTOs());

            IFunctorFactory factory = new FunctorFactory();
            BindBasicFunctors(factory);

            EmployeeBehavior behavior = new EmployeeBehavior(service.Object, factory);

            var employees = await behavior.GetAllAsync();

            Assert.True(employees.Count == 3);
            Assert.Equal(8000 * 12, employees[0].AnnualSalary);
            Assert.Equal(120 * 200 * 12, employees[1].AnnualSalary);
            Assert.Equal(6000 * 12, employees[2].AnnualSalary);

        }

        [Fact]
        public async Task GetEmployeeById()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(s => s.GetAllAsync())
                .ReturnsAsync(GetDTOs());

            IFunctorFactory factory = new FunctorFactory();
            BindBasicFunctors(factory);

            EmployeeBehavior behavior = new EmployeeBehavior(service.Object, factory);

            var employees = await behavior.GetByIdAsync(1);

            Assert.True(employees.Count == 1);
            Assert.Equal(8000 * 12, employees[0].AnnualSalary);
            Assert.Equal("Test1", employees[0].Name);
            Assert.Equal("", employees[0].RoleDescription);
            Assert.Equal(0, employees[0].RoleId);
            Assert.Equal("", employees[0].RoleName);
            Assert.Equal("MonthlySalaryEmployee", employees[0].ContractTypeName);
        }

        [Fact]
        public async Task GetEmptyEmployeeListById()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(s => s.GetAllAsync())
                .ReturnsAsync(GetDTOs());

            IFunctorFactory factory = new FunctorFactory();
            BindBasicFunctors(factory);

            EmployeeBehavior behavior = new EmployeeBehavior(service.Object, factory);

            var employees = await behavior.GetByIdAsync(0);

            Assert.True(employees.Count == 0);
        }

        [Fact]
        public async Task GetAllEmployeesWithUnknownFunctor()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(s => s.GetAllAsync())
                .ReturnsAsync(GetFailDTOs());

            IFunctorFactory factory = new FunctorFactory();
            BindBasicFunctors(factory);

            EmployeeBehavior behavior = new EmployeeBehavior(service.Object, factory);

            await Assert.ThrowsAsync<Exception>(() => behavior.GetAllAsync());
            
        }
    }
}
