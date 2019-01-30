using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Bll;

namespace WebApiDemo.Test.BllTest
{
    [TestClass]
    public class TestBaseBll
    {
        [TestMethod]
        public void TestBllBaseCreated()
        {
            var bllBase = new BaseBll();
        }
    }
}
