using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public interface IFunctorFactory
    {
        void BindFunctor(Type entityType, Type functorType);

        IFunctor GetFunctor(object entity);
    }
}
