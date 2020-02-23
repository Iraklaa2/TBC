using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using TestProject.Domain.Entities;

namespace TestProject.Data.Context
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, object filter)
        {
            if (filter == null) return source;

            var properties = filter.GetType().GetProperties();

            foreach (var item in properties)
            {
                var value = item.GetValue(filter, null);
                
                if (value == null) continue;

                string propertyName = item.Name;

                source = ExpressionUtils.BuildPredicate<T>(source, propertyName, "Contains", value);
            }

            return source;
        }
    }

    public static partial class ExpressionUtils
    {
        public static IQueryable<T> BuildPredicate<T>(IQueryable<T> source, string propertyName, string comparison, object value)
        {
            // TODO: REFACTORING! It really need to be refactored.

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyNames = propertyName.Split('.').ToList();
            var properties = value.GetType().GetProperties();

            Expression left = propertyNames.Aggregate((Expression)parameter, Expression.Property);

            var tt = left.Type;

            if (IsIEnumerable(left.Type) && !IsString(left.Type))
            {
                var collectionType = left.Type.GetGenericArguments()[0];
                ParameterExpression tpe = Expression.Parameter(collectionType, "c");

                for (var i = 0; i < properties.Length; i++)
                {
                    var val = properties[i].GetValue(value, null);

                    if (val == null)
                        continue;

                    left = Expression.Property(tpe, collectionType.GetProperty(properties[i].Name));
                    Expression right = Expression.Constant(properties[i].GetValue(value, null));
                    Expression InnerLambda = Expression.Equal(left, right);

                    Expression<Func<PhoneNumberEntity, bool>> innerFunction = Expression.Lambda<Func<PhoneNumberEntity, bool>>(InnerLambda, tpe);

                    var method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(collectionType);

                    source = source.Where(Expression.Lambda<Func<T, bool>>(
                    Expression.Call(method, Expression.Property(parameter, typeof(T).GetProperty("PhoneNumbers")), innerFunction), parameter));
                }
                
                return source;
            }

            if (properties.Length == 1)
            {
                propertyNames.Add(properties[0].Name);
                value = properties[0].GetValue(value, null);
            }

            left = propertyNames.Aggregate((Expression)parameter, Expression.Property);

            if (IsString(left.Type))
            {
                return source.Where(Expression.Lambda<Func<T, bool>>(
                    Expression.Call(MakeString(left), comparison, Type.EmptyTypes, Expression.Constant(((string)value).ToLower(), typeof(string))), parameter));
            }
            
            return source.Where(Expression.Lambda<Func<T, bool>>(
                Expression.MakeBinary(ExpressionType.Equal, left, Expression.Constant(value, left.Type)), parameter));
        }

        private static bool IsIEnumerable(Type type)
        {
            return (type.GetInterface(nameof(IEnumerable)) != null);
        }

        private static bool IsString(Type type)
        {
            return type == typeof(string);
        }

        private static Expression MakeString(Expression source)
        {
            var str = source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
            return Expression.Call(str, "ToLower", Type.EmptyTypes);
        }
    }
}
