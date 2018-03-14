using MasGlobal.Core.Behaviors.Actions;
using MasGlobal.Core.DTOs;
using MasGlobal.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Core.Behaviors
{
    public class EmployeeBehavior : IEmployeeBehavior
    {
        protected readonly IEmployeeService _service;
        protected readonly IActionFactory _factory;

        public EmployeeBehavior(IEmployeeService service,
            IActionFactory factory)
        {
            _service = service;
            _factory = factory;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employeeDTOs = await _service.GetAllAsync();

            foreach (var employeeDTO in employeeDTOs)
            {
                var action = _factory.GetAction(employeeDTO);
                action.Execute(employeeDTO);
            }

            return employeeDTOs;           
        }

        public async Task<List<EmployeeDTO>> GetByIdAsync(int Id)
        {
            var employees =  await GetAllAsync();
            return employees.Where(e => e.Id == Id).ToList();
        }
    }
}
