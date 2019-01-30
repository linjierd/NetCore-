using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.Common;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.DalTest.Common
{
    [TestClass]
    public class DbConnManagerTest
    {
        [TestMethod]
        public void DbConnManager()
        {
            DbConnManager dbConnManager = ConfigManager.GetDbConnManager();
            var clientCenterDbConn = dbConnManager.ClientCenterDbConn;
            var systemCenterDbConn = dbConnManager.SystemCenterDbConn;
        }
       
    }
}
