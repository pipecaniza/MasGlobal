using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class HourlySalaryFunctor : IFunctor
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
