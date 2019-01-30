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
    public class TestSystemCenterDalBase
    {
        [TestMethod]
        public void TestSystemCenterDalBaseM()
        {
            DbConnManager dbConnManager =  ConfigManager.GetDbConnManager();
            SystemCenterDalBase systemCenterDalBase = new SystemCenterDalBase(dbConnManager); 
        }
    }
}
