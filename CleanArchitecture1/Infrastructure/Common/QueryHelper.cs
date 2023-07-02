using Application.Common.Models;
using Application.Common.Models.AgGrid;
using Application.Common.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace Infrastructure.Common
{
    public static class QueryHelper
    {

        private static decimal GetDecimal(this string val)
        {
            return decimal.Parse(val);
        }

        private static string FirstLetterToUpper(this string val)
        {
            return val.Substring(1).ToUpper() + val.Substring(1, val.Length - 1);
        }

        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods().FirstOrDefault(method =>
            method.Name == "OrderBy" &&
            method.GetParameters().Length == 2
        );

        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods().FirstOrDefault(method =>
            method.Name == "OrderByDescending" &&
            method.GetParameters().Length == 2
        );

        private static readonly MethodInfo ThenOrderByMethod = typeof(Queryable).GetMethods().FirstOrDefault(method =>
            method.Name == "ThenBy" &&
            method.GetParameters().Length == 2
        );

        private static readonly MethodInfo ThenOrderByDescendingMethod = typeof(Queryable).GetMethods().FirstOrDefault(method =>
            method.Name == "ThenByDescending" &&
            method.GetParameters().Length == 2
        );

        private static readonly MethodInfo WhereMethod = typeof(Queryable).GetMethods().FirstOrDefault(method =>
            method.Name == "Where" &&
            method.GetParameters().Length == 2
        //&&             method.MetadataToken == 100663503
        );

        private static bool PropertyExists<T>(this IQueryable<T> source, string propertyName)
        {
            return typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        private static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
            MethodInfo genericMethod = OrderByMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            IOrderedQueryable<T> query = (IOrderedQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
            return query;
        }

        private static IOrderedQueryable<T> OrderByPropertyDescending<T>(this IQueryable<T> source, string propertyName)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
            MethodInfo genericMethod = OrderByDescendingMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            IOrderedQueryable<T> query = (IOrderedQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
            return query;
        }

        private static IOrderedQueryable<T> ThenOrderByProperty<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
            MethodInfo genericMethod = ThenOrderByMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            IOrderedQueryable<T> query = (IOrderedQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
            return query;
        }

        private static IOrderedQueryable<T> ThenOrderByPropertyDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression orderByProperty = Expression.Property(parameterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, parameterExpression);
            MethodInfo genericMethod = ThenOrderByDescendingMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
            IOrderedQueryable<T> query = (IOrderedQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
            return query;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, string operation)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            // create parameter expression (x=>x.Property...)
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            MemberExpression property = Expression.Property(parameterExpression, propertyName);

            // Find type from model and convert string to model
            Type propertyType = ((PropertyInfo)property.Member).PropertyType;
            TypeConverter converter = TypeDescriptor.GetConverter(propertyType);
            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();
            Expression valueExpression;
            if (propertyType.AssemblyQualifiedName.ToString().IndexOf("DateTime") > -1)
            {
                DateTime v = PDate.ToGeorgianDate(value.Replace("/", "")).Date;
                value = v.Day.ToString("00/") + v.Month.ToString("00/") + v.Year.ToString("0000");
                DateTime parsedDate = DateTime.ParseExact(value, "dd/MM/yyyy", null);
                var dayStart = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, 0, 0, 0, 0);
                valueExpression = Expression.Constant(dayStart);


            }
            else
            {
                object propertyValue = converter.ConvertFromInvariantString(value);
                ConstantExpression constant = Expression.Constant(propertyValue);
                valueExpression = Expression.Convert(constant, propertyType);
            }

            // Create expression based on Grid Filter for Numbers and Dates using Binary Expressions
            Expression binaryExpression = operation switch
            {
                "equals" => Expression.Equal(property, valueExpression),
                "notEqual" => Expression.NotEqual(property, valueExpression),
                "greaterThan" => Expression.GreaterThan(property, valueExpression),
                "greaterThanOrEqual" => Expression.GreaterThanOrEqual(property, valueExpression),
                "lessThan" => Expression.LessThan(property, valueExpression),
                "lessThanOrEqual" => Expression.LessThanOrEqual(property, valueExpression),
                "inRange" => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };


            LambdaExpression lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, parameterExpression);

            MethodInfo genericMethod = WhereMethod.MakeGenericMethod(typeof(T));

            IQueryable<T> query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });

            /////////////////////////////////////////////////////////////
            ////    MethodInfo WhereMethod = typeof(Queryable).GetMethods().Single(method =>
            ////    method.Name == "Where" &&
            ////    method.GetParameters().Length == 2 &&
            ////    method.MetadataToken == 100663503
            ////);
            //    // New EF Core compatible
            //    var anyMethod = typeof(Enumerable)
            //        .GetMethods(BindingFlags.Static | BindingFlags.Public)
            //        .FirstOrDefault(m => m.Name == "Any" && m.GetParameters().Count() == 2)
            //        .MakeGenericMethod(typeof(T));
            //    // Child expression
            //    var expression = (Expression)typeof(ExpressionBuilder).GetMethod("GetExpression").MakeGenericMethod(typeof(T)).Invoke(null, new object[] { source, false });

            //    // We want the expression to evaluate to true where the child count is > 0
            //    var method = Expression.Call(anyMethod, binaryExpression, expression);
            //    var lambda = Expression.Lambda<Func<T, bool>>(method, parameterExpression);
            //    IQueryable<T> query = source.Where(lambda);

            ////////////////////////////////////////////////////////////

            return query;
        }
        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, List<string> value)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            var methodInfo = typeof(List<int>).GetMethod("Contains", new Type[] { typeof(int) });
            //List<int> inint = new List<int>();
            //foreach (var item in value)
            //{
            //    if ((item == "") || (item == "undefined")) continue;
            //    var result = item;// item.Substring(0,item.IndexOf('-') );
            //    int intitem = int.Parse(result);
            //    inint.Add(intitem);
            //}


            // create parameter expression (x=>x.Property...)
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "ft");//ft=>
            MemberExpression property = Expression.Property(parameterExpression, propertyName);//ft.propertyName
            // Find type from model and convert string to model
            Type propertyType = ((PropertyInfo)property.Member).PropertyType;
            TypeConverter converter = TypeDescriptor.GetConverter(propertyType);
            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();
            var i = 0;
            if (value[i].ToString() == "") return source;
            object propertyValue = converter.ConvertFromInvariantString(value[i].ToString());
            var constant = Expression.Constant(propertyValue);
            var valueExpression = Expression.Convert(constant, propertyType); // 4
            var ftStartTimeFirstClause = Expression.Equal(property, valueExpression); // ft.FilmId == 3

            while (i < value.Count - 1)
            {
                propertyValue = converter.ConvertFromInvariantString(value[i + 1].ToString());
                constant = Expression.Constant(propertyValue);
                valueExpression = Expression.Convert(constant, propertyType); // 4
                var ftStartTimeSecondClause = Expression.Equal(property, valueExpression); // ft.FilmId == 3

                ftStartTimeFirstClause = Expression.OrElse(ftStartTimeFirstClause, ftStartTimeSecondClause); // (ft.StartTime < beginTime || ft.StartTime >= endTime)
                i = i + 2;

            }


            // var body = Expression.Call(ftStartTimeFirstClause, methodInfo, property);



            LambdaExpression lambda = Expression.Lambda<Func<T, bool>>(ftStartTimeFirstClause, parameterExpression);
            MethodInfo genericMethod = WhereMethod.MakeGenericMethod(typeof(T));

            IQueryable<T> query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });


            return query;
        }

        private static IQueryable<T> Contains<T>(this IQueryable<T> source, string propertyName, string value, string operation)
        {
            if (!PropertyExists(source, propertyName))
            {
                return null;
            }
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");
            MemberExpression property = Expression.Property(parameterExpression, propertyName);
            var functions = Expression.Property(null, typeof(EF).GetProperty(nameof(EF.Functions)));
            var likeFunction = typeof(DbFunctionsExtensions).GetMethod("Like", new Type[] { functions.Type, typeof(string), typeof(string) });

            ConstantExpression Constant;
            switch (operation)
            {
                case "contains":
                    Constant = Expression.Constant($"%{value}%");
                    break;
                case "startsWith":
                    Constant = Expression.Constant($"{value}%");
                    break;
                case "endsWith":
                    Constant = Expression.Constant($"%{value}");
                    break;
                case "notContains":
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
            Expression ftStartTimeFirstClause = Expression.Call(null, likeFunction, functions, property, Constant);
            if (value.IndexOf("ي") > -1)
            {
                string Persiany = value.Persiany();
                switch (operation)
                {
                    case "contains":
                        Constant = Expression.Constant($"%{Persiany}%");
                        break;
                    case "startsWith":
                        Constant = Expression.Constant($"{Persiany}%");
                        break;
                    case "endsWith":
                        Constant = Expression.Constant($"%{Persiany}");
                        break;
                    case "notContains":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
                var ftStartTimetwoClause = Expression.Call(null, likeFunction, functions, property, Constant);

                ftStartTimeFirstClause = Expression.OrElse(ftStartTimeFirstClause, ftStartTimetwoClause);
            }
            if (value.IndexOf("ی") > -1)
            {

                string Arabicy = value.Arabicy();
                switch (operation)
                {
                    case "contains":
                        Constant = Expression.Constant($"%{Arabicy}%");
                        break;
                    case "startsWith":
                        Constant = Expression.Constant($"{Arabicy}%");
                        break;
                    case "endsWith":
                        Constant = Expression.Constant($"%{Arabicy}");
                        break;
                    case "notContains":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
                var ftStartTimetwoClause = Expression.Call(null, likeFunction, functions, property, Constant);

                ftStartTimeFirstClause = Expression.OrElse(ftStartTimeFirstClause, ftStartTimetwoClause);
            }
            if (value.IndexOf("ك") > -1)
            {
                string Persiank = value.Persiank();
                switch (operation)
                {
                    case "contains":
                        Constant = Expression.Constant($"%{Persiank}%");
                        break;
                    case "startsWith":
                        Constant = Expression.Constant($"{Persiank}%");
                        break;
                    case "endsWith":
                        Constant = Expression.Constant($"%{Persiank}");
                        break;
                    case "notContains":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
                var ftStartTimetwoClause = Expression.Call(null, likeFunction, functions, property, Constant);

                ftStartTimeFirstClause = Expression.OrElse(ftStartTimeFirstClause, ftStartTimetwoClause);
            }
            if (value.IndexOf("ک") > -1)
            {
                string Arabick = value.Arabick();
                switch (operation)
                {
                    case "contains":
                        Constant = Expression.Constant($"%{Arabick}%");
                        break;
                    case "startsWith":
                        Constant = Expression.Constant($"{Arabick}%");
                        break;
                    case "endsWith":
                        Constant = Expression.Constant($"%{Arabick}");
                        break;
                    case "notContains":
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
                var ftStartTimetwoClause = Expression.Call(null, likeFunction, functions, property, Constant);

                ftStartTimeFirstClause = Expression.OrElse(ftStartTimeFirstClause, ftStartTimetwoClause);
            }
            // Create expression based on Grid Filter for strings: EF.Functions.Like(p.PropertyName, "%SearchString%")
            //MethodCallExpression callLike = Expression.Call(
            //    typeof(DbFunctionsExtensions),
            //    "Like",
            //    Type.EmptyTypes,
            //    dbFunctionExpression,
            //    member,
            //    pattern);

            LambdaExpression lambda = Expression.Lambda<Func<T, bool>>(ftStartTimeFirstClause, parameterExpression);
            MethodInfo genericMethod = WhereMethod.MakeGenericMethod(typeof(T));

            IQueryable<T> query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
            return query;
        }

        //private static IQueryable<T> Contains<T>(this IQueryable<T> source, string propertyName, string value, string operation)
        //{
        //    if (!PropertyExists(source, propertyName))
        //    {
        //        return null;
        //    }
        //    ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");
        //    MemberExpression member = Expression.Property(parameterExpression, propertyName);
        //    Expression dbFunctionExpression = Expression.Constant(EF.Functions);
        //    ConstantExpression pattern;
        //    string Persiany = value.Persiany();
        //    string Arabicy= value.Arabicy();
        //    string Persiank = value.Persiank();
        //    string Arabick = value.Arabick();
        //    switch (operation)
        //    {
        //        case "contains":
        //            pattern = Expression.Constant($"%{value}%");
        //            break;
        //        case "startsWith":
        //            pattern = Expression.Constant($"{value}%");
        //            break;
        //        case "endsWith":
        //            pattern = Expression.Constant($"%{value}");
        //            break;
        //        case "notContains":
        //            throw new NotImplementedException();
        //        default:
        //            throw new NotImplementedException();
        //    }

        //    // Create expression based on Grid Filter for strings: EF.Functions.Like(p.PropertyName, "%SearchString%")
        //    MethodCallExpression callLike = Expression.Call(
        //        typeof(DbFunctionsExtensions),
        //        "Like",
        //        Type.EmptyTypes,
        //        dbFunctionExpression,
        //        member,
        //        pattern);

        //    LambdaExpression lambda = Expression.Lambda<Func<T, bool>>(callLike, parameterExpression);
        //    MethodInfo genericMethod = WhereMethod.MakeGenericMethod(typeof(T));

        //    IQueryable<T> query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambda });
        //    return query;
        //}

        public static ResultMessage GridSortQuery<T>(IQueryable<T> query, IEnumerable<SortModel> sortModel)
        {
            ResultMessage resultDTO = new ResultMessage();
            try
            {

                if (sortModel != null && sortModel.ToList().Count > 0)
                {
                    SortModel first = sortModel.First();
                    IOrderedQueryable<T> queryResult = first.Sort.Equals("asc")
                        ? query.OrderByProperty(first.ColId)
                        : query.OrderByPropertyDescending(first.ColId);
                    foreach (SortModel s in sortModel.Skip(1))
                    {
                        queryResult = s.Sort.Equals("asc")
                            ? queryResult.ThenOrderByProperty(s.ColId)
                            : queryResult.ThenOrderByPropertyDescending(s.ColId);
                    }
                    resultDTO.data = queryResult;
                    return resultDTO;
                }
                else
                {
                    var prope = query.ElementType.GetProperties();
                    IOrderedQueryable<T> queryResult = query.OrderByProperty(prope.ToList()[0].Name);
                    resultDTO.data = queryResult;
                    return resultDTO;
                }
            }
            catch (Exception ex)
            {
                resultDTO.errors.Add(new ErrorDTO()
                {
                    code = "99",
                    Desc = "Error in GridSortQuery : " + ex.GetBaseException().ToString()
                }); ;
                return resultDTO;
            }

        }
        public static ResultMessage GridFilterQuery<T>(IQueryable<T> query, List<ColumnFilter> filterModel)
        {
            ResultMessage resultDTO = new ResultMessage();
            try
            {
                if (filterModel != null)
                {
                    foreach (var model in filterModel)
                    {
                        var key = model.Field.ToUpper();
                        var values = model.Condition1;
                        query = values.filterType switch
                        {
                            "text" => PerformFilter(TextFilter, query, key, model),
                            "number" => PerformFilter(NumberFilter, query, key, model),
                            "date" => PerformFilter(DateFilter, query, key, model),
                            "set" => query.Where(key, values.values.ToList()),
                            _ => throw new NotImplementedException(),
                        };
                    }
                }
                resultDTO.data = query;
                return resultDTO;
            }
            catch (Exception ex)
            {
                resultDTO.errors.Add(new ErrorDTO()
                {
                    code = "99",
                    Desc = "Error in GridFilterQuery : " + ex.GetBaseException().ToString()
                }); ;
                return resultDTO;
            }


        }

        private static IQueryable<T> PerformFilter<T>(Func<IQueryable<T>, string, ConditionFilterModel, IQueryable<T>> filter, IQueryable<T> query, string key, ColumnFilter model)
        {
            if (!string.IsNullOrWhiteSpace(model.FilterOperator))
            {
                var query1 = filter(query, key, model.Condition1);
                var query2 = filter(query, key, model.Condition2);
                query = model.FilterOperator == "OR" ? query1.Union(query2) : query1.Intersect(query2);
            }
            else
            {
                query = filter(query, key, model.Condition1);
            }
            return query;
        }



        //private static IQueryable<T> PerformFilter<T>(Func<IQueryable<T>, string, FilterModel, IQueryable<T>> filter, IQueryable<T> query, string key, FilterModel model)
        //{
        //    //if (!string.IsNullOrWhiteSpace(model.filterOperator))
        //    //{
        //    //    var query1 = filter(query, key, model.condition1);
        //    //    var query2 = filter(query, key, model.condition2);
        //    //    query = model.filterOperator == "OR" ? query1.Union(query2) : query1.Intersect(query2);
        //    //}
        //    //else
        //    //{
        //        query = filter(query, key, model);
        //    //}
        //    return query;
        //}

        //private static IQueryable<T> DateFilter<T>(IQueryable<T> query, string key, ConditionFilterModel model)
        //{
        //    string dateFromString = model.DateFrom;
        //    //dateFromString = dateFromString.Replace("/", "");
        //    var xBeginingDate = Expression.Constant(dateFromString, typeof(string));
        //    var xParameter = Expression.Parameter(typeof(T), "p");

        //    MemberExpression property = Expression.Property(xParameter, key);
        //    Expression dateField = Expression.Property(xParameter, property.Member.Name);

        //    if (model.Type == "inRange")
        //    {
        //        string dateToString = model.DateTo;
        //        //  dateToString = dateToString.Replace("/", "");
        //        var xEndDate = Expression.Constant(dateToString, typeof(string));


        //        var xCompare1 = Expression.Call(
        //                 typeof(string)
        //                 .GetMethod("Compare", new Type[] { typeof(string), typeof(string) }),
        //                 xBeginingDate,
        //                 dateField);

        //        var xFinalCompare1 = Expression.LessThanOrEqual(xCompare1, Expression.Constant(0, typeof(int)));


        //        query = query.Where(Expression.Lambda<Func<T, bool>>(xFinalCompare1, xParameter));

        //        var xCompare2 = Expression.Call(
        //                typeof(string)
        //                .GetMethod("Compare", new Type[] { typeof(DateTime), typeof(DateTime) }),
        //                xEndDate,
        //                dateField);

        //        var xFinalCompare2 = Expression.GreaterThanOrEqual(xCompare2, Expression.Constant(0, typeof(int)));

        //        query = query.Where(Expression.Lambda<Func<T, bool>>(xFinalCompare2, xParameter));

        //    }
        //    else
        //    {
        //        //query = query.Where(key, dateFromString, model.Type);

        //        var xCompare1 = Expression.Call(
        //                 typeof(DateTime)
        //                 .GetMethod("Compare", new Type[] { typeof(DateTime), typeof(DateTime) }),
        //                 xBeginingDate,
        //                 dateField);

        //        var xFinalCompare1 = Expression.Equal(xCompare1, Expression.Constant(0, typeof(int)));
        //        query = query.Where(Expression.Lambda<Func<T, bool>>(xFinalCompare1, xParameter));

        //    }
        //    return query;
        //}
        private static IQueryable<T> DateFilter<T>(IQueryable<T> query, string key, ConditionFilterModel model)
        {
            string dateFromString = model.filter;
            if (model.type == "inRange")
            {
                string dateToString = model.DateTo;
                if (DateTime.Parse(dateFromString) < DateTime.Parse(dateToString))
                {
                    query = query.Where(key, dateFromString, "greaterThanOrEqual");
                    query = query.Where(key, dateToString, "lessThanOrEqual");
                }
                else
                {
                    query = query.Where(key, dateFromString, "lessThanOrEqual");
                    query = query.Where(key, dateToString, "greaterThanOrEqual");
                }
            }
            else
            {
                query = query.Where(key, dateFromString, model.type);
            }
            return query;
        }

        private static IQueryable<T> NumberFilter<T>(IQueryable<T> query, string key, ConditionFilterModel model)
        {
            string filter = model.filter.GetDecimal().ToString();
            if (model.type == "inRange")
            {
                string filterTo = model.FilterTo;
                if (model.filter.GetDecimal() < model.FilterTo.GetDecimal())
                {
                    query = query.Where(key, filter, "greaterThanOrEqual");
                    query = query.Where(key, filterTo, "lessThanOrEqual");
                }
                else
                {
                    query = query.Where(key, filter, "lessThanOrEqual");
                    query = query.Where(key, filterTo, "greaterThanOrEqual");
                }
            }
            else
            {
                query = query.Where(key, filter, model.type);
            }
            return query;
        }
        private static IQueryable<T> TextFilter<T>(IQueryable<T> query, string key, ConditionFilterModel model)
        {
            var filter = model.filter;
            key = key.ToUpper();
            switch (model.type)
            {
                case "equals":
                    query = query.Where(key, filter, model.type);
                    break;
                case "notEqual":
                    query = query.Where(key, filter, model.type);
                    break;
                case "contains":
                    query = query.Contains(key, filter, model.type);
                    break;
                case "startsWith":
                    query = query.Contains(key, filter, model.type);
                    break;
                case "endsWith":
                    query = query.Contains(key, filter, model.type);
                    break;
                case "notContains":
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
            return query;
        }

        private static IQueryable<T> SetFilter<T>(IQueryable<T> query, string key, ConditionFilterModel model)
        {

            List<string> instr = model.values.ToList();
            List<int> inint = new List<int>();
            //foreach (var item in instr)
            //{   if (item == "") continue;
            //    int filter = int.Parse(item.GetDecimal().ToString());
            //    inint.Add(filter);
            //}
            //query =query.Where(x => inint.Contains(int.Parse(key)));
            foreach (var item in instr)
            {
                if ((item.ToString() == "") || (item.ToString() == "undefined")) continue;
                string filter = item.ToString().GetDecimal().ToString();
                query = query.Where(key, filter, "equals").Union(query);
            }
            return query;
        }
    }
}
