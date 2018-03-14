using MasGlobal.Core.Behaviors.Actions;
using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MasGlobal.Tests.Behaviors
{
    public class ActionFactoryTests
    {
        private static void BindBasicActions(IActionFactory factory)
        {
            factory.BindAction(typeof(HourlySalaryEmployeeDTO), typeof(HourlySalaryAction));
            factory.BindAction(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryAction));
        }

        [Fact]
        public void SuccessActionFactoryCreation()
        {
            IActionFactory actionFactory = new ActionFactory();
            BindBasicActions(actionFactory);

            Dictionary<Type, Type> table = null;

            table = actionFactory.GetType()
                .GetField("_table", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(actionFactory) as Dictionary<Type, Type>;

            Assert.Equal(2, table.Count);
            Assert.Equal(typeof(HourlySalaryAction), table[typeof(HourlySalaryEmployeeDTO)]);
            Assert.Equal(typeof(MonthlySalaryAction), table[typeof(MonthlySalaryEmployeeDTO)]);
        }

        [Fact]
        public void FailActionFactoryCreation()
        {
            IActionFactory actionFactory = new ActionFactory();
            BindBasicActions(actionFactory);

            Assert.Throws<Exception>(() =>
                actionFactory.BindAction(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryAction)));
        }

        [Fact]
        public void NullArgumentActionFactoryBinding()
        {
            IActionFactory actionFactory = new ActionFactory();
            BindBasicActions(actionFactory);

            Assert.Throws<ArgumentNullException>(() =>
                actionFactory.BindAction(null, null));
        }
    }
}
