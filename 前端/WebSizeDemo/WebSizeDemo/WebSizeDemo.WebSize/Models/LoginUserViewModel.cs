using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSizeDemo.WebSize.Models
{
    public class LoginUserViewModel
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

    }
}
