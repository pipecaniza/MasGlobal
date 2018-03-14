using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class MonthlySalaryFunctor : IFunctor
    {
        public void Execute(object entity)
        {
            var entityCasted = entity as MonthlySalaryEmployeeDTO;
            if (entityCasted == null)
            {
                throw new Exception("Unable to cast");
            }
            entityCasted.AnnualSalary = entityCasted.MonthlySalary * 12;
        }
    }
}
