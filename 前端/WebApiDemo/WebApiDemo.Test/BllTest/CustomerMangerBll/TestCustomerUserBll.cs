using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Bll.CustomerMangerBll;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;

namespace WebApiDemo.Test.BllTest.CustomerMangerBll
{
    [TestClass]
    public class TestCustomerUserBll
    {
        
        [TestMethod]

        public void TestGetAddUpdate()
        {
            ICustomerUserDal iCustomerUserDal = new Mock<ICustomerUserDal>().Object; //虚拟一个接口对象
            CustomerUserDto dto = new CustomerUserDto
            {
                user_login_name = "test",
                user_password = "testpwd",
                user_full_name = "lzh",
                user_phone_number = "1111111111111",
                user_mail = "aaa@qq.com",
                creator_date = DateTime.Now
            };
            CustomerUserBll customerUserBll = new CustomerUserBll(iCustomerUserDal);
            customerUserBll.Add(dto);
            var model = customerUserBll.GetModel("test");
            customerUserBll.GetModel(1);

          
            customerUserBll.Update(model);
            customerUserBll.UpdatePassWord(1, "dddd");
            customerUserBll.Delete("test");
        }
        [TestMethod]
        public void TestGetPageList()
        {
            ICustomerUserDal iCustomerUserDal = new Mock<ICustomerUserDal>().Object; //虚拟一个接口对象
            CustomerUserBll customerUserBll = new CustomerUserBll(iCustomerUserDal);
            int rowCount = 0;
            var pageList = customerUserBll.GetPageList(2, 0, "1", out rowCount);

        }
    }

}
