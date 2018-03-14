using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Core.Behaviors
{
    public interface IEmployeeBehavior
    {
        Task<List<EmployeeDTO>> GetAllAsync();

        Task<List<EmployeeDTO>> GetByIdAsync(int Id);
    }
}
