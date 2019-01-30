using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Model.DbModel.Client
{
    [Table("customer_user_guid")]
    public class CustomerUserGuid
    {
        public CustomerUserGuid()
        { }
        #region Model
        /// <summary>
        /// 用户id
        /// </summary>
        [Key]
        public long customer_user_id
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
        /// 创建时间
        /// </summary>
        public DateTime create_date
        {
            get; set;
        }
        #endregion Model

    }
}
