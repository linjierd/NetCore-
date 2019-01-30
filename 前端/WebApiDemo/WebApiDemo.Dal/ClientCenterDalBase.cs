using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.Common;
using Dapper;
using System.Data;

namespace WebApiDemo.Dal
{
    public class ClientCenterDalBase : BaseDal
    {

        public ClientCenterDalBase(DbConnManager dbConnManager):base(dbConnManager)
        {
            
        }
        public override IDbConnection CurrentDbConn
        {
            get
            {
                return _dbConnManager.ClientCenterDbConn;
            }
        }








    }
}
