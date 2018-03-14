using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class HourlySalaryFunctor : IFunctor<HourlySalaryEmployeeDTO>
    {
        public void Execute(HourlySalaryEmployeeDTO entity)
        {
            entity.AnnualSalary = 120 * entity.HourlySalary * 12;
        }
    }
}
