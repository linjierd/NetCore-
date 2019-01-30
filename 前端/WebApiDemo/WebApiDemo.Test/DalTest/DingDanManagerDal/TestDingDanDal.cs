using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.DingDanManagerDal;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.DalTest.DingDanManagerDal
{
    [TestClass]
    public class TestDingDanDal
    {
        public DingDanDal dingDanDal = new DingDanDal(ConfigManager.GetDbConnManager());
        [TestMethod]
        public void TestGetDingDanPage()
        {
            int intRowCount = 0;
            var resultList = dingDanDal.GetDingDanPage(3, 1, 3, out intRowCount);
            Assert.IsNotNull(resultList);
        }
    }
}
