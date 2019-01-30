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
    public class TestCustomerUserDal
    {
        CustomerUserDal customerUserDal = new CustomerUserDal(ConfigManager.GetDbConnManager());
      
        [TestMethod]
        public void TestGetAddUpdate()
        {
            CustomerUserDto dto = new CustomerUserDto
            {
                user_login_name = "test",
                user_password = "testpwd",
                user_full_name = "lzh",
                user_phone_number = "1111111111111",
                user_mail = "aaa@qq.com",
                creator_date = DateTime.Now
            };
            customerUserDal.Add(dto);
            var model = customerUserDal.GetModel("test");
            customerUserDal.GetModel(model.user_id);

            model.user_full_name = model.user_full_name + "1";
            customerUserDal.Update(model);
            customerUserDal.UpdatePassWord(model.user_id, "dddd");
            customerUserDal.Delete("test");
        }

        [TestMethod]
        public void TestGetPageList()
        {
    
            int rowCount = 0;
           var pageList= customerUserDal.GetPageList(2, 0, "1", out rowCount);

        }








    }
}
