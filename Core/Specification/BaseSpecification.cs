using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpresion)
        {
            OrderBy = orderByExpresion;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDscExpresion)
        {
            OrderByDescending = orderByDscExpresion;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPaggingEnabled = true;
        }
        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaggingEnabled { get; private set; }
    }
}
