using MasGlobal.Core.Behaviors.Functors;
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
        protected readonly IFunctorFactory _factory;

        public EmployeeBehavior(IEmployeeService service,
            IFunctorFactory factory)
        {
            _service = service;
            _factory = factory;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employeeDTOs = await _service.GetAllAsync();

            foreach (var employeeDTO in employeeDTOs)
            {
                var functor = _factory.GetFunctor(employeeDTO);
                functor.Execute(employeeDTO);
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
