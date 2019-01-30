using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Model.CustomerManger;

namespace WebApiDemo.IDal.ICustomerMangerDal
{
    public interface IGerenxinxiDal
    {
        /// <summary>
        /// 获取前端用户
        /// </summary>
        /// <param name="GerenxinxiZhanghuming">账户名,  被逼这样命名</param>
        /// <returns></returns>
        GerenxinxiDto GetModel(string GerenxinxiZhanghuming);

        GerenxinxiDto GetModel(int id);

        bool Update(GerenxinxiDto userDto);
    }
}
