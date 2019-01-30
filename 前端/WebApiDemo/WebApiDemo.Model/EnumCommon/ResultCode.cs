using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Model.EnumCommon
{
    public class ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static readonly string Ok = "001";
        /// <summary>
        /// 失败
        /// </summary>
        public static readonly string Fail = "002";
        /// <summary>
        /// 错误
        /// </summary>
        public static readonly string Error = "-1";

    }
}
