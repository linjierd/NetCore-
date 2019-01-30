using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.CommonLib.Common
{
    public class HttpContextManager
    {
        public static HttpContext HttpContext {
            get{ return DiManager.GetDiObj<IHttpContextAccessor>().HttpContext; }
        }
        public static string GetHeaderPara(string key)
        {
            Microsoft.Extensions.Primitives.StringValues value;
            HttpContext.Request.Headers.TryGetValue(key, out value);
            return value;
        }
    }
}
