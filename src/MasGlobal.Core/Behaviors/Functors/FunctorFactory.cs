using MasGlobal.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class FunctorFactory : IFunctorFactory
    {
        private Dictionary<Type, Type> Table;

        public FunctorFactory()
        {
            Table = new Dictionary<Type, Type>();
        }

        public void BindFunctor(Type entityType, Type functorType)
        {
            if (entityType == null || functorType == null)
            {
                throw new ArgumentNullException();
            }

            if (Table.ContainsKey(entityType))
            {
                throw new Exception("Entity type has an functor assigned");
            }

            Table.Add(entityType, functorType);
        }

        public IFunctor GetFunctor(object entity)
        {
            var typeofEntity = entity.GetType();
            if (!Table.ContainsKey(typeofEntity))
            {
                throw new Exception("The entity doesn't have any functor assigned");
            }

            var functorType = Table[typeofEntity];
            if (functorType.IsGenericType)
            {
                Type[] typeArgs = { entity.GetType() };
                var genericType = functorType.MakeGenericType(typeArgs);
                return (IFunctor)Activator.CreateInstance(genericType);
            }
            return (IFunctor)Activator.CreateInstance(functorType);
        }
    }
}
