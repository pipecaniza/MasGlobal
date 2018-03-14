using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Core.Behaviors.Functors
{
    public class FunctorFactory
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

        public IFunctor<T> GetFunctor<T>(T entity)
            where T : class
        {
            var typeofEntity = typeof(T);
            if (!Table.ContainsKey(typeofEntity))
            {
                throw new Exception("The entity doesn't have any functor assigned");
            }

            var functorType = Table[typeofEntity];
            Type[] typeArgs = { typeof(T) };
            var genericType = functorType.MakeGenericType(typeArgs);
            return (IFunctor<T>)Activator.CreateInstance(genericType);
        }
    }
}
