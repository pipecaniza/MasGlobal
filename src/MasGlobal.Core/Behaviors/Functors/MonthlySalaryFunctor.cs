using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class MonthlySalaryFunctor : IFunctor<MonthlySalaryEmployeeDTO>
    {
        public void Execute(MonthlySalaryEmployeeDTO entity)
        {
            entity.AnnualSalary = entity.MonthlySalary * 12;
        }
    }
}
