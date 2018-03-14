using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Actions
{
    public class ActionFactory : IActionFactory
    {
        private Dictionary<Type, Type> _table;

        public ActionFactory()
        {
            _table = new Dictionary<Type, Type>();
        }

        public void BindAction(Type entityType, Type actionType)
        {
            if (entityType == null || actionType == null)
            {
                throw new ArgumentNullException();
            }

            if (_table.ContainsKey(entityType))
            {
                throw new Exception("Entity type has an action assigned");
            }

            _table.Add(entityType, actionType);
        }

        public IAction GetAction(object entity)
        {
            var typeofEntity = entity.GetType();
            if (!_table.ContainsKey(typeofEntity))
            {
                throw new Exception("The entity doesn't have any action assigned");
            }

            var actionType = _table[typeofEntity];
            return (IAction)Activator.CreateInstance(actionType);
        }
    }
}
