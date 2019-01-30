using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
namespace WebApiDemo.Dal.Common
{
    public class SqlCommon
    {
        /// <summary>
        /// 拼接Sqlserver的分页
        /// </summary>
        /// <param name="keyfield">主键</param>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="startRecord">开始记录</param>
        /// <param name="pars">参数</param>
        /// <param name="isOutRows">是否返回总行数</param>
        /// <returns></returns>
        public static string GetPaginationSqlOn2008(string fields, string table, string orderField, string sqlWhere, int pageSize, int startRecord, Dictionary<string, object> pars, bool isOutRows = true)
        {
            StringBuilder strSql = new StringBuilder("SELECT  " + fields);
            int endRecord = 0;
            if (sqlWhere.Trim().Length > 0)
            {
                sqlWhere = " WHERE " + sqlWhere;
            }
            endRecord = startRecord + pageSize - 1;
            strSql.Append(" FROM ( SELECT ROW_NUMBER() Over(order by " + orderField + " ) as rowId," + fields + " FROM " + table + sqlWhere + " ) AS a WHERE rowId BETWEEN  " + startRecord.ToString() + " and " + endRecord.ToString() + " order by rowId ");
            if (isOutRows) strSql.Append(" ;SELECT COUNT (*) FROM " + table + " " + sqlWhere);
            return strSql.ToString();
        }


        /// <summary>
        /// 拼接Sqlserver的分页
        /// </summary>
        /// <param name="keyfield">主键</param>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="startRecord">开始记录</param>
        /// <param name="pars">参数</param>
        /// <param name="isOutRows">是否返回总行数</param>
        /// <returns></returns>
        public static string GetPaginationSqlOn2012(string fields, string table, string orderField, string sqlWhere, int pageSize, int startRecord, Dictionary<string, object> pars, bool isOutRows = true)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(" select {0}  from {1} where {2}  order by {3}  OFFSET {4} ROW FETCH NEXT {5} rows only ",
                                   fields, table, sqlWhere, orderField, startRecord, pageSize);
            if (isOutRows) strSql.AppendFormat(" ;SELECT COUNT (*) FROM " + table + " where " + sqlWhere);
            return strSql.ToString();
        }



        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="startRecord">开始记录</param>
        /// <param name="rowCount">要返回的总记录数</param>
        /// <param name="pars">参数</param>
        /// <param name="conn">连接</param>
        /// <param name="isOutRows">是否返回总行数</param>
        /// <returns></returns>
        public List<T> SqlServerPage<T>(string fields, 
            string table, string orderField, 
            string sqlWhere, int pageSize, int startRecord,
            out int rowCount, Dictionary<string, object> pars, IDbConnection conn, bool isOutRows = true) where T : class, new()
        {
            string strSql = GetPaginationSqlOn2008(fields, table, orderField, sqlWhere, pageSize, startRecord, pars);
            // DynamicParameters dpars = new DynamicParameters();
            return DapperPage<T>(strSql, pars, conn, out rowCount, isOutRows);


        }

        /// <summary>
        /// dapper 分页
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">分页sql</param>
        /// <param name="pars"></param>
        /// <param name="rowCount">返回总记录数</param>
        /// <param name="conn"></param>
        /// <param name="isOutRows"></param>
        /// <returns></returns>
        public static List<T> DapperPage<T>(string sql,  Dictionary<string, object> pars, IDbConnection conn, out int rowCount,
            bool isOutRows = true)
        {
            DynamicParameters dpars = new DynamicParameters();
            foreach (var item in pars.Keys)
            {
                dpars.Add("@" + item, pars[item]);
            }
            var multi = conn.QueryMultiple(sql, dpars);
            if (!multi.IsConsumed)
            {
                List<T> list = multi.Read<T>().AsList();
                if (!multi.IsConsumed && isOutRows)
                {
                    rowCount = multi.ReadFirst<int>();
                }
                else
                {
                    rowCount = 0;
                }
                return list;
            }
            rowCount = 0;
            return null;
        }
    }
}
