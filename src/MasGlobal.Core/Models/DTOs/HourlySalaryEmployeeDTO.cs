using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.DTOs
{
    public class HourlySalaryEmployeeDTO : EmployeeDTO
    {
        public int HourlySalary { get; set; }

        public HourlySalaryEmployeeDTO(int id, string name, string contractTypeName,
            int roleId, string roleName, string roleDescription, int hourlySalary)
            : base(id, name, contractTypeName, roleId, roleName, roleDescription)
        {
            HourlySalary = hourlySalary;
        }
    }
}
