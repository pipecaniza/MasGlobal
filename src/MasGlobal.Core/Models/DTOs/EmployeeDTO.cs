using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public int AnnualSalary { get; set; }

        public EmployeeDTO(int id, string name, string contractTypeName,
            int roleId, string roleName, string roleDescription)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
        }
    }
}
