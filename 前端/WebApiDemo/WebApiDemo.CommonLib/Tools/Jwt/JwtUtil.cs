using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.CommonLib.Tools.Jwt
{
    public class JwtUtil
    {
        private static string secret = "eyJ0eXAiOiJKV1QiLCJhbGciUIioNKrtMNer";//这个服务端加密秘钥 属于私钥

        public static string Encode(object obj)
        {


            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(obj, secret);
            return token;
        }
        public static T Decode<T>(string token)
        {
            string json;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                json = decoder.Decode(token, secret, verify: false);//token为之前生成的字符串
                T model = JsonConvert.DeserializeObject<T>(json);
                //对时间和用户账户密码进行认证
                return model;
            }
            catch (Exception)
            {
                return default(T);
            }


        }
    }
    public class SimpleTokenInfo
    {
        public SimpleTokenInfo()
        {
            CreateTimeStr = DateTime.Now.ToString("yyyyMMddhhmmss");

        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateTimeStr { get; set; }
        /// <summary>
        /// 用户账户
        /// </summary>
        public string ZhangHuMing { get; set; }
    }
}
