using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Actions
{
    public interface IAction
    {
        void Execute(object entity);
    }
}
