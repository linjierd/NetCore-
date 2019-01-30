using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebSizeDemo.WebSize
{
    public class CookieManager
    {
        public static IResponseCookies ResponseCookies
        {
            get
            {
                return DiManager.GetDiObj<IHttpContextAccessor>().HttpContext.Response.Cookies;
            }
        }

        public static IRequestCookieCollection RequestCookieCollection
        {
            get
            {
                return DiManager.GetDiObj<IHttpContextAccessor>().HttpContext.Request.Cookies;
            }
        }
        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeExpire">过期时间,单位:秒</param>
        public static void Set(string key, string value,int timeExpire)
        {
            ResponseCookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(timeExpire)
            });
        }
        public static string Get(string key)
        {
            string value = "";
            RequestCookieCollection.TryGetValue(key, out value);
            return value;
        }

        public static void Remove(string key)
        {
            ResponseCookies.Delete(key);
        }
    }
}
