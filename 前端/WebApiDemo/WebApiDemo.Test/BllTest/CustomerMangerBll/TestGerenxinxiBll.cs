using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Bll.CustomerMangerBll;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.Dal.CustomerMangerDal;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;
using WebApiDemo.Model.EnumCommon;
using WebApiDemo.Model.ViewModel;
using WebApiDemo.Test.Common;

namespace WebApiDemo.Test.BllTest.CustomerMangerBll
{
    [TestClass]
    public class TestGerenxinxiBll
    {
        [TestMethod]
        public void TestGetModelOnLoginName()
        {
            IGerenxinxiDal iGerenxinxiDal = new Mock<IGerenxinxiDal>().Object; //虚拟一个接口对象
            GerenxinxiBll bll = new GerenxinxiBll(iGerenxinxiDal,null);
            bll.GetModel("lzh");
        }
        [TestMethod]
        public void TestGetToken()
        {
            IGerenxinxiDal iGerenxinxiDal = new GerenxinxiDal(ConfigManager.GetDbConnManager());
            RedisManager redisManager = new RedisManager(ConfigManager.GetConfig());
            GerenxinxiBll bll = new GerenxinxiBll(iGerenxinxiDal, redisManager);
            GerenxinxiDto dto = bll.GetModel("lzh");
            UserAndTokenView token = bll.GetToken(dto, (ClientType)1);
            Assert.IsNotNull(token);
        }
        [TestMethod]
        public void TestGetUserInCachen()
        {
            IGerenxinxiDal iGerenxinxiDal = new GerenxinxiDal(ConfigManager.GetDbConnManager());
            RedisManager redisManager = new RedisManager(ConfigManager.GetConfig());
            GerenxinxiBll bll = new GerenxinxiBll(iGerenxinxiDal, redisManager);
            GerenxinxiDto dto = bll.GetModel("lzh");
            UserAndTokenView token = bll.GetToken(dto, (ClientType)1);
            UserAndTokenView dtoTemp= bll.GetUserInCachen(token.Token);
            Assert.IsNotNull(dtoTemp);
        }
    }
}
