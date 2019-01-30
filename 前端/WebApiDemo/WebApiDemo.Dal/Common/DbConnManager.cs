using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebApiDemo.Dal.Common
{
    public class DbConnManager
    {
        private IConfiguration _configuration;
        private object obj = new object();
        public DbConnManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region 客户库连接
        private IDbConnection _clientCenterDbConn;
        public IDbConnection ClientCenterDbConn
        {
            get
            {
                if (_clientCenterDbConn == null)
                {
                    lock (obj)
                    {
                        if (_clientCenterDbConn == null)
                        {
                            _clientCenterDbConn = new SqlConnection(_configuration.GetSection("ConnectionStrings")["ClientCenterConnection"]);

                        }
                    }
                }
                //if (_clientCenterDbConn.State == ConnectionState.Closed)
                //{
                //    _clientCenterDbConn.Open();
                //}
                return _clientCenterDbConn;
            //    return new SqlConnection(_configuration.GetSection("ConnectionStrings")["ClientCenterConnection"]);
            }
        }
        #endregion


        #region 后台库连接
        private IDbConnection _systemCenterDbConn;
        public IDbConnection SystemCenterDbConn
        {
            get
            {
                if (_systemCenterDbConn == null)
                {
                    lock (obj)
                    {
                        if (_systemCenterDbConn == null)
                        {
                            _systemCenterDbConn = new SqlConnection(_configuration.GetSection("ConnectionStrings")["SystemCenterConnection"]);
                        }
                    }
                }
                //if (_systemCenterDbConn.State == ConnectionState.Closed)
                //{
                //    _systemCenterDbConn.Open();
                //}
                return _systemCenterDbConn;
             //   return new SqlConnection(_configuration.GetSection("ConnectionStrings")["SystemCenterConnection"]);

            }
        }
        #endregion
    }
}
