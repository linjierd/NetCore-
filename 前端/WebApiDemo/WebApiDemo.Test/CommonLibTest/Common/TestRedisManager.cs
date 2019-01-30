using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.CommonLibTest.Common
{
    [TestClass]
    public class TestRedisManager
    {
        [TestMethod]
        public void TestSet()
        {
            RedisManager redisManager = new RedisManager(ConfigManager.GetConfig());
            redisManager.Set("aa", "bb");
            Assert.AreEqual(redisManager.Get("aa"), "bb");
        }
    }
}
