using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public interface IFunctor<T> where T : class
    {
        void Execute(T entity);
    }
}
