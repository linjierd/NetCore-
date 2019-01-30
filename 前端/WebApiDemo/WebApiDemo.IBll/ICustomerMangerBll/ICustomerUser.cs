using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Model.CustomerManger;

namespace WebApiDemo.IBll.ICustomerMangerBll
{
    public interface ICustomerUserBll
    {
        CustomerUserDto GetModel(long id);
        CustomerUserDto GetModel(string  userName);
        long Add(CustomerUserDto model);

        bool Update(CustomerUserDto model);

        bool UpdatePassWord(long userId, string passWord);

        bool Delete(string userName);

        List<CustomerUserDto> GetPageList(int pageSize, int startRecord, string userLoginName, out int rowCount);
    }
}
