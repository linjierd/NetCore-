using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Api.WebModel.UserManager
{
    public class CustomerUserView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long user_id
        {
            get; set;
        }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string user_login_name
        {
            get; set;
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string user_password
        {
            get; set;
        }
        /// <summary>
        /// 用户全名
        /// </summary>
        public string user_full_name
        {
            get; set;
        }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string user_phone_number
        {
            get; set;
        }
        /// <summary>
        /// 用户邮箱地址
        /// </summary>
        public string user_mail
        {
            get; set;
        }
      
    }
}
