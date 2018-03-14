using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.DTOs
{
    public class MonthlySalaryEmployeeDTO : EmployeeDTO
    {
        public decimal MonthlySalary { get; set; }

        public MonthlySalaryEmployeeDTO(int id, string name, string contractTypeName,
            int roleId, string roleName, string roleDescription, decimal monthlySalary)
            : base (id, name, contractTypeName, roleId, roleName, roleDescription)
        {
            MonthlySalary = monthlySalary;
        }
    }
}
