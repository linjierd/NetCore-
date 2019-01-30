using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Model.DbModel.Client
{
    [Table("customer_user")]
    public class CustomerUserDb
    {
        public CustomerUserDb()
        { }
        #region Model
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
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
