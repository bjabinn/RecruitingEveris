using Recruiting.Business.BaseClasses.DataTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace Recruiting.Business.Helpers
{

    public static class DataTableHelper
    {
        #region Constants
        #endregion

        #region Mapper
        public static IQueryable<TSource> ApplyColumnSettings<TSource>(this IQueryable<TSource> query, DataTableRequest request,
                                                            Func<string, string> columnPropertiePathSelector = null)
        {
            if ((request == null) || ((request.Columns != null) && request.Columns.All(x => !x.SortDirection.HasValue)) || (columnPropertiePathSelector == null))
            {
                return query;
            }

            var orderedColumn = request.Columns.First(x => x.SortDirection.HasValue);

            var propertiePath = columnPropertiePathSelector(orderedColumn.Name);

            if (orderedColumn.SortDirection == DataTableSortDirectionEnum.Ascending)
            {
                query = query.OrderByProperty(propertiePath);
            }
            else
            {
                query = query.OrderByProperty(propertiePath, DataTableSortDirectionEnum.Descending);
            }

            if (request.PageSize.HasValue)
            {
                query = query.Skip(request.PageNumber * request.PageSize.Value).Take(request.PageSize.Value);
            }
            return query;
        }


        public static IEnumerable<T> ApplyColumnSettings<T>(this IEnumerable<T> list, DataTableRequest request,
                                                      Func<string, string> columnPropertiePathSelector = null)
        {
            if ((request == null) || (request.Columns == null))
            {
                return list;
            }

            if (request.PageSize.HasValue)
            {
                list = list.Skip(request.PageNumber * request.PageSize.Value).Take(request.PageSize.Value);
            }
            return list;
        }

        #endregion
    }

    public static class ReflectionQueryable
    {
        private static readonly MethodInfo OrderByAscMethod =
            typeof(Queryable).GetMethods()
                .Where(method => method.Name == "OrderBy")
                .Where(method => method.GetParameters().Length == 2)
                .Single();

        private static readonly MethodInfo OrderByDescMethod =
            typeof(Queryable).GetMethods()
                .Where(method => method.Name == "OrderByDescending")
                .Where(method => method.GetParameters().Length == 2)
                .Single();

        public static IQueryable<TSource> OrderByProperty<TSource>(this IQueryable<TSource> source, string propertyPath, DataTableSortDirectionEnum sortDirection = DataTableSortDirectionEnum.Ascending)
        {
            var parameter = Expression.Parameter(typeof(TSource));
            var properties = propertyPath.Split('.');

            Expression parent = parameter;

            foreach (var propertie in properties)
            {
                parent = Expression.Property(parent, propertie);
            }

            var lambda = Expression.Lambda(parent, parameter);
            MethodInfo genericMethod = OrderByAscMethod.MakeGenericMethod
                (new[] { typeof(TSource), parent.Type });
            if (sortDirection == DataTableSortDirectionEnum.Descending)
            {
                genericMethod = OrderByDescMethod.MakeGenericMethod
                   (new[] { typeof(TSource), parent.Type });
            }

            object ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IQueryable<TSource>)ret;
        }
    }


    public static class ExportTableHelper
    {
        public static void ExportTabletoExcel (HttpResponseBase Response, object clientsList)
        {
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = clientsList;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
