using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebApiDemo.Dal.Common;

namespace WebApiDemo.Dal
{
    public class SystemCenterDalBase: BaseDal
    {
       
        public SystemCenterDalBase(DbConnManager dbConnManager):base(dbConnManager)
        {
            _dbConnManager = dbConnManager;
        }
        public override IDbConnection CurrentDbConn
        {
            get
            {
                return _dbConnManager.SystemCenterDbConn;
            }
        }

    }
}
