using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.CustomerMangerDal;
using WebApiDemo.Model.CustomerManger;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.DalTest.CustomerMangerDal
{
    [TestClass]
    public class TestGerenxinxiDal
    {
        [TestMethod]
        public void TestGetModelInLoginName()
        {
            GerenxinxiDal dal  = new GerenxinxiDal(ConfigManager.GetDbConnManager());
            dal.GetModel("lzh");
        }
    }
}
