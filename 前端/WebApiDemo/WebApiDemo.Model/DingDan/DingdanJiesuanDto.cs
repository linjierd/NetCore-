using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Model.DingDan
{
    public class DingdanJiesuanDto
    {
        public DingdanJiesuanDto()
        { }
        #region Model
        /// <summary>
        /// 订单ID
        /// </summary>
        public int dingdan_id
        {
            get; set;
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public int? dingdan_shouhuo_dizhi
        {
            get; set;
        }
        /// <summary>
        /// 下单用户
        /// </summary>
        public int? dingdan_yonghu
        {
            get; set;
        }
        /// <summary>
        /// 邮费
        /// </summary>
        public decimal? dingdan_youfei
        {
            get; set;
        }
        /// <summary>
        /// 积分使用数
        /// </summary>
        public decimal? jifen_shiyongshu
        {
            get; set;
        }
        /// <summary>
        /// 积分抵扣金额
        /// </summary>
        public decimal? jifen_jifendikou_jine
        {
            get; set;
        }
        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal? zhifu_jine
        {
            get; set;
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? xiadan_shijian
        {
            get; set;
        }
        /// <summary>
        /// 订单确认时间
        /// </summary>
        public DateTime? queren_shijian
        {
            get; set;
        }
        /// <summary>
        /// 订单状态(未付款，已付款，确认收货……)
        /// </summary>
        public int? dingdan_zhuangtai
        {
            get; set;
        }
        /// <summary>
        /// 发票ID
        /// </summary>
        public int? fapiao_id
        {
            get; set;
        }
        /// <summary>
        /// 下单店铺ID（每单商品限定同一店铺）
        /// </summary>
        public int? xiadan_dianpu_id
        {
            get; set;
        }
        #endregion Model

    }
}
