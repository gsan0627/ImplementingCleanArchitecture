using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Entities.Specification
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ConditionExpression { get; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> expressionDelegate = ConditionExpression.Compile();
            return expressionDelegate(entity);
        }
    }
}
