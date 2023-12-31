﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalExaminationSys.Extenstions
{
    public static class DbContextExtensions
    {
        public static void ApplyGlobalFilter<T>(this ModelBuilder modelBuilder, Expression<Func<T, bool>> filterExpression)
        {
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(T)))
                {
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.First(), parameter, filterExpression.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }
    }
}
