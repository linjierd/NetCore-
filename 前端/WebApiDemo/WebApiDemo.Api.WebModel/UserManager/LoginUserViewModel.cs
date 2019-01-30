using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Api.WebModel.UserManager
{
    public class LoginUserViewModel
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string loginName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickName { get; set; }

    }
}
