using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Model.YouHuiQuan
{
    public class YouhuiquanZhubiao
    {
        public YouhuiquanZhubiao()
        { }
        #region Model
        /// <summary>
        /// 优惠券编号
        /// </summary>
        public string youhuiquan_code
        {
            get; set;
        }
        /// <summary>
        /// 优惠券标题
        /// </summary>
        public string youhuiquan_title
        {
            get; set;
        }
        /// <summary>
        /// 优惠券类型(满减、包邮)
        /// </summary>
        public int? youhuiquan_type
        {
            get; set;
        }
        /// <summary>
        /// 限制平台(是移动端还是PC端)
        /// </summary>
        public int? youhuiquan_pingtai
        {
            get; set;
        }
        /// <summary>
        /// 限制品类(全品类还是家电)
        /// </summary>
        public int? youhuiquan_pinlei
        {
            get; set;
        }
        /// <summary>
        /// 领取限制(是否新用户)
        /// </summary>
        public int? youhuiquan_lingquxianzhi
        {
            get; set;
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? youhuiquan_dazhe
        {
            get; set;
        }
        /// <summary>
        /// 优惠券面值
        /// </summary>
        public decimal? youhuiquan_value
        {
            get; set;
        }
        /// <summary>
        /// 限领次数
        /// </summary>
        public int? youhuiquan_limit
        {
            get; set;
        }
        /// <summary>
        /// 优惠券使用门槛
        /// </summary>
        public decimal? youhuiquan_menkan
        {
            get; set;
        }
        /// <summary>
        /// 优惠券发行量
        /// </summary>
        public int? youhuiquan_count
        {
            get; set;
        }
        /// <summary>
        /// 优惠券商家id
        /// </summary>
        public long youhuiquan_store_id
        {
            get; set;
        }
        /// <summary>
        /// 优惠券使用地址
        /// </summary>
        public string youhuiquan_store_url
        {
            get; set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? youhuiquan_start_time
        {
            get; set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? youhuiquan_end_time
        {
            get; set;
        }
        /// <summary>
        /// 优惠券创建时间
        /// </summary>
        public DateTime? youhuiquan_create_time
        {
            get; set;
        }
        /// <summary>
        /// 是否支持累加
        /// </summary>
        public bool youhuiquan_leijia
        {
            get; set;
        }
        #endregion Model
    }
}
