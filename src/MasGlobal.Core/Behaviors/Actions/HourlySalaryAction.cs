using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Actions
{
    public class HourlySalaryAction : IAction
    {
        public void Execute(object entity)
        {
            var entityCasted = entity as HourlySalaryEmployeeDTO;
            if (entityCasted == null)
            {
                throw new Exception("Unable to cast");
            }
            entityCasted.AnnualSalary = 120 * entityCasted.HourlySalary * 12;
        }
    }
}
