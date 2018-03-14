using MasGlobal.Core.DTOs;
using MasGlobal.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Helpers
{
    public static class ExtendedEmployee
    {
        public static EmployeeDTO ConvertEntityToDTO(this Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case Global.HourlySalaryName:                    
                    return new HourlySalaryEmployeeDTO(employee.Id, employee.Name, 
                        employee.ContractTypeName, employee.RoleId, employee.RoleName, 
                        employee.RoleDescription, employee.HourlySalary);

                case Global.MonthlySalaryName:
                    return new MonthlySalaryEmployeeDTO(employee.Id, employee.Name,
                        employee.ContractTypeName, employee.RoleId, employee.RoleName,
                        employee.RoleDescription, employee.MonthlySalary);

                default:
                    throw new Exception("Unable to match the ContractTypeName");
            }
        }

        public static List<EmployeeDTO> ConvertListToDTO(this List<Employee> employees)
        {
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                employeesDTO.Add(employee.ConvertEntityToDTO());
            }

            return employeesDTO;
        }
    }
}
