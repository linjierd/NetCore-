using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal;
using WebApiDemo.Dal.Common;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.DalTest
{
    [TestClass]
    public class TestClientCenterDalBase
    {

        [TestMethod]
        public void TestClientCenterDalBaseM()
        {
            DbConnManager dbConnManager = ConfigManager.GetDbConnManager();
            ClientCenterDalBase systemCenterDalBase = new ClientCenterDalBase(dbConnManager);
        }
    }
}
