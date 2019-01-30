using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSizeDemo.WebSize.Models;

namespace WebSizeDemo.WebSize
{
    public class LoginManager
    {
        public readonly static string loginUserSessionKey = "loginUserSessionKey";
        public readonly static string loginUserSessionTokenKey = "loginUserSessionTokenKey";
        public readonly static string loginUserCookieKey = "loginUserCookieKey";
        public static void IniLoginUser(LoginUserViewModel user)
        {
            if (user != null)
            {
                string userJson = JsonConvert.SerializeObject(user);
                SessionManager.Set(loginUserSessionKey, userJson);
                SessionManager.Set(loginUserSessionTokenKey, user.Token);
                CookieManager.Set(loginUserCookieKey, userJson, 60);
            }

        }
        public static string Token
        {
            get {
                string token = SessionManager.Get(loginUserSessionTokenKey);
                if (!string.IsNullOrEmpty(token)) return token;
                return "";
            }
        }
       

        public static LoginUserViewModel GetLoginUser()
        {
            string userJson = SessionManager.Get(loginUserSessionKey);
            if (string.IsNullOrEmpty(userJson))
            {
                userJson = CookieManager.Get(loginUserCookieKey);
            }
            if (!string.IsNullOrEmpty(userJson))
            {
                return JsonConvert.DeserializeObject<LoginUserViewModel>(userJson);
            }
            return null;
        }

        public static bool IsLogin
        {
            get
            {
                string userJson = SessionManager.Get(loginUserSessionKey);
                if (string.IsNullOrEmpty(userJson))
                {
                    userJson = CookieManager.Get(loginUserCookieKey);
                }
                if (!string.IsNullOrEmpty(userJson))
                {
                    return true;
                }
                return false;
            }
        }

       


        public static void LoginOut()
        {
            SessionManager.Remove(loginUserSessionKey);
            CookieManager.Remove(loginUserCookieKey);
        }
    }
}
