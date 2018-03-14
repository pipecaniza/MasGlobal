using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class FunctorFactory : IFunctorFactory
    {
        private Dictionary<Type, Type> _table;

        public FunctorFactory()
        {
            _table = new Dictionary<Type, Type>();
        }

        public void BindFunctor(Type entityType, Type functorType)
        {
            if (entityType == null || functorType == null)
            {
                throw new ArgumentNullException();
            }

            if (_table.ContainsKey(entityType))
            {
                throw new Exception("Entity type has an functor assigned");
            }

            _table.Add(entityType, functorType);
        }

        public IFunctor GetFunctor(object entity)
        {
            var typeofEntity = entity.GetType();
            if (!_table.ContainsKey(typeofEntity))
            {
                throw new Exception("The entity doesn't have any functor assigned");
            }

            var functorType = _table[typeofEntity];
            return (IFunctor)Activator.CreateInstance(functorType);
        }
    }
}
