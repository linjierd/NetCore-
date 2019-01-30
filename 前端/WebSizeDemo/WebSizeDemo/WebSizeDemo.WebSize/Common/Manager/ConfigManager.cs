using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSizeDemo.WebSize
{
    public class ConfigManager
    {
        public static IConfiguration Configuration
        {
            get{
                return DiManager.GetDiObj<IConfiguration>();
            }
            
        }
        /// <summary>
        /// api访问地址
        /// </summary>
        public static string ApiHost
        {
            get
            {
                return Configuration.GetSection("ApiConfig")["ApiHost"].ToString();
            }
        }
        /// <summary>
        /// 用户接口地址
        /// </summary>
        public static string UserApiHost
        {
            get
            {
                return Configuration.GetSection("ApiConfig")["UserApiHost"].ToString();
            }
        }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public static string ClentType
        {
            get
            {
                return Configuration.GetSection("ApiConfig")["ClentType"].ToString();
            }
        }

        public static string ImageApiHost
        {
            get {
                return Configuration.GetSection("ApiConfig")["ImageApiHost"].ToString();
            }
        }


        public static string ImageServerPath
        {
            get
            {
                return Configuration.GetSection("ApiConfig")["ImageApiHost"].ToString();
            }
        }
    }
}
