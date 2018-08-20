using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bruna.Danilo.Testers.Models;
using Bruna.Danilo.Testers.Models.Extensions;

namespace Bruna.Danilo.Testers.Database.Extensions
{
    public static class QueryableExtensions
    {
		public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, SortModel sortModel)
        {
			var type = typeof(T);
            var property = type.GetProperty(sortModel.ColId.FirstLetterToUpper());
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

			MethodCallExpression resultExp = Expression.Call(typeof(Queryable), (sortModel.Sort == SortModel.Asc) ? "OrderBy" : "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);

        }


    }
}
