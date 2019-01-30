using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;

namespace WebApiDemo.Bll.CustomerMangerBll
{
    public class CustomerUserBll : BaseBll, ICustomerUserBll
    {
        private ICustomerUserDal _iCustomerUserDal;
        public CustomerUserBll(ICustomerUserDal iCustomerUserDal)
        {
            _iCustomerUserDal = iCustomerUserDal;
        }
        public long Add(CustomerUserDto model)
        {
            return _iCustomerUserDal.Add(model);
        }

        public bool Delete(string userName)
        {
            return _iCustomerUserDal.Delete(userName);
        }

        public CustomerUserDto GetModel(long id)
        {
            return _iCustomerUserDal.GetModel(id);
        }
        public CustomerUserDto GetModel(string userName)
        {
            return _iCustomerUserDal.GetModel(userName);
        }

        public List<CustomerUserDto> GetPageList(int pageSize, int startRecord, string userLoginName, out int rowCount)
        {
            return _iCustomerUserDal.GetPageList(pageSize, startRecord, userLoginName, out rowCount);
        }

        public bool Update(CustomerUserDto model)
        {
            return _iCustomerUserDal.Update(model);
        }

        public bool UpdatePassWord(long userId, string passWord)
        {
            return _iCustomerUserDal.UpdatePassWord(userId,passWord);
        }
    }
}
