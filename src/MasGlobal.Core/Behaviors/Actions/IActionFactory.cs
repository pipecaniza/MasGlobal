using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Actions
{
    public interface IActionFactory
    {
        void BindAction(Type entityType, Type actionType);

        IAction GetAction(object entity);
    }
}
