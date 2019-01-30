using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Model.CustomerManger;
using WebApiDemo.Model.EnumCommon;
using WebApiDemo.Model.ViewModel;

namespace WebApiDemo.IBll.ICustomerMangerBll
{
    public interface IGerenxinxiBll
    {
        GerenxinxiDto GetModel(string gerenxinxiZhanghuming);
        UserAndTokenView GetToken(GerenxinxiDto gerenxinxiDto, ClientType clientType);

        GerenxinxiDto GetModelByToken(string token);
        UserAndTokenView GetUserInCachen(string token);
        bool ValidateToken(string token);

        UserAndTokenView GetToken(string userName, string passWord, ClientType clientType);

        bool Update(GerenxinxiDto userDto);
    }
}
