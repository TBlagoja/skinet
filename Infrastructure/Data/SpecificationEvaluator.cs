﻿using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public SpecificationEvaluator() 
        { 
        } 
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> queryExpresion, ISpecification<TEntity> specification) 
        {

            var query = queryExpresion;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria); 
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}
