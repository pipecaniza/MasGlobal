using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public interface IFunctor
    {
        void Execute(object entity);
    }
}
