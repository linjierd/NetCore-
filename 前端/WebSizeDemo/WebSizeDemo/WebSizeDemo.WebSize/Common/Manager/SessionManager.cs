using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebSizeDemo.WebSize
{
    public class SessionManager
    {
        public static ISession Session {
            get {
                return DiManager.GetDiObj<IHttpContextAccessor>().HttpContext.Session;

            }
        }

        public static void Set(string key, string value)
        {
            Session.SetString(key, value);
        }


        public static string Get(string key)
        {
           return Session.GetString(key);
        }

        public static void Remove(string key)
        {
             Session.Remove(key);
        }

    }
}
