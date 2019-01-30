using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebApiDemo.Dal.Common
{
    public class SystemCenterDb 
    {
        private IConfiguration _configuration;
        private object obj = new object();
        public SystemCenterDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection _SystemCenterDbConn;
        public IDbConnection SystemCenterDbConn
        {
            get
            {
                if (_SystemCenterDbConn == null)
                {
                    lock (obj)
                    {
                        if (_SystemCenterDbConn == null)
                        {
                            _SystemCenterDbConn = new SqlConnection(_configuration.GetConnectionString("SystemCenterConnection"));
                        }
                    }
                }
                return _SystemCenterDbConn;
               
            }
        }
    }
}
