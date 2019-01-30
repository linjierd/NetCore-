using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Model.CustomerManger
{
    public class CustomerUserDto
    {
        public CustomerUserDto()
        { }
        #region Model
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
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime creator_date
        {
            get; set;
        }
        #endregion Model

    }
}
