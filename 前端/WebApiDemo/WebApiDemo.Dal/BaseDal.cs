using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using WebApiDemo.Dal.Common;

namespace WebApiDemo.Dal
{
    public abstract class BaseDal
    {
        protected DbConnManager _dbConnManager;
        public BaseDal(DbConnManager dbConnManager)
        {
            _dbConnManager = dbConnManager;
        }
        public abstract IDbConnection CurrentDbConn { get; }







        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="startRecord">开始记录</param>
        /// <param name="rowCount">要返回的总记录数</param>
        /// <param name="pars">参数</param>
        /// <param name="isOutRows">是否返回总行数</param>
        /// <returns></returns>
        public List<T> SqlServer2012Page<T>(string fields, string table, string orderField, string sqlWhere, int pageSize, int startRecord, out int rowCount, Dictionary<string, object> pars, bool isOutRows = true) where T : class, new()
        {
            string strSql = SqlCommon.GetPaginationSqlOn2012(fields, table, orderField, sqlWhere, pageSize, startRecord, pars);
            
            return SqlCommon.DapperPage<T>(strSql, pars, CurrentDbConn, out rowCount, isOutRows);
        }
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="startRecord">开始记录</param>
        /// <param name="rowCount">要返回的总记录数</param>
        /// <param name="pars">参数</param>
        /// <param name="isOutRows">是否返回总行数</param>
        /// <returns></returns>
        public List<T> SqlServer2012Page<T>(string fields, string table, string orderField, string sqlWhere, int pageSize, int pageIndex, out int rowCount, Dictionary<string, object> pars) where T : class, new()
        {
            int startRecord = (pageIndex - 1) * pageSize;
            string strSql = SqlCommon.GetPaginationSqlOn2012(fields, table, orderField, sqlWhere, pageSize, startRecord, pars);

            return SqlCommon.DapperPage<T>(strSql, pars, CurrentDbConn, out rowCount, true);
        }
    }
}
