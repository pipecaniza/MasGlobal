using MasGlobal.Core.Behaviors.Functors;
using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MasGlobal.Tests.Behaviors
{
    public class FunctorFactoryTests
    {
        private static void BindBasicFunctors(IFunctorFactory factory)
        {
            factory.BindFunctor(typeof(HourlySalaryEmployeeDTO), typeof(HourlySalaryFunctor));
            factory.BindFunctor(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryFunctor));
        }

        [Fact]
        public void SuccessFunctorFactoryCreation()
        {
            IFunctorFactory functorFactory = new FunctorFactory();
            BindBasicFunctors(functorFactory);

            Dictionary<Type, Type> table = null;

            table = functorFactory.GetType()
                .GetField("_table", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(functorFactory) as Dictionary<Type, Type>;

            Assert.Equal(2, table.Count);
            Assert.Equal(typeof(HourlySalaryFunctor), table[typeof(HourlySalaryEmployeeDTO)]);
            Assert.Equal(typeof(MonthlySalaryFunctor), table[typeof(MonthlySalaryEmployeeDTO)]);
        }

        [Fact]
        public void FailFunctorFactoryCreation()
        {
            IFunctorFactory functorFactory = new FunctorFactory();
            BindBasicFunctors(functorFactory);

            Assert.Throws<Exception>(() =>
                functorFactory.BindFunctor(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryFunctor)));
        }

        [Fact]
        public void NullArgumentFunctorFactoryBinding()
        {
            IFunctorFactory functorFactory = new FunctorFactory();
            BindBasicFunctors(functorFactory);

            Assert.Throws<ArgumentNullException>(() =>
                functorFactory.BindFunctor(null, null));
        }
    }
}
