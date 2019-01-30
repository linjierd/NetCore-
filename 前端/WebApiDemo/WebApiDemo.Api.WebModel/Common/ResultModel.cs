using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Api.WebModel.Common
{
    public class ResultModel
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string result_mess { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic result_data { get; set; }
    }
}
