using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.DTOs
{
    public class HourlySalaryEmployeeDTO : EmployeeDTO
    {
        public decimal HourlySalary { get; set; }

        public HourlySalaryEmployeeDTO(int id, string name, string contractTypeName,
            int roleId, string roleName, string roleDescription, decimal hourlySalary)
            : base(id, name, contractTypeName, roleId, roleName, roleDescription)
        {
            HourlySalary = hourlySalary;
        }
    }
}
