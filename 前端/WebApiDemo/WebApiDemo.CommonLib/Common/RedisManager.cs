using CSRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.CommonLib.Common
{
    public class RedisManager
    {
        private IConfiguration _configuration;
        private readonly CSRedisClient _csredis;
        public RedisManager(IConfiguration configuration)
        {
            _configuration = configuration;
            //  _csredis = new CSRedis.CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=13,poolsize=50,ssl=false,writeBuffer=10240,prefix=key前辍");
            _csredis = new CSRedisClient(_configuration.GetSection("ConnectionStrings")["DefaultRedisConnection"]);
            RedisHelper.Initialization(_csredis);
          
        }
        private static int defaultTimeExpire = 86400;//默认过期秒数

        private void Dispose()
        {
            RedisHelper.Instance.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        private void Save()
        {
            RedisHelper.NodesServerManager.Save();
          
        }

        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        private void SaveAsync()
        {
            RedisHelper.NodesServerManager.SaveAsync(); 
         
        }

        #region /// redis操作方法

        /// <summary>
        /// 判断某个数据是否已经被缓存
        /// </summary>
        public bool Exist(string key)
        {
            try
            {
                var result = RedisHelper.Exists(key);
              
                return result;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 存储数据到redis
        /// </summary>
        public bool Set(string key, object value)
        {
            try
            {

                RedisHelper.Set(key, value, defaultTimeExpire);
               
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存储数据到redis
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeExpire"></param>
        /// <returns></returns>
        public bool Set(string key, string value, int timeExpire)
        {
            try
            {

                RedisHelper.Set(key, value, timeExpire);
               
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存储数据到hash表,默认24小时过期
        /// </summary>
        public bool Set<T>(string key, T t)
        {
            try
            {
                RedisHelper.Set(key, t, defaultTimeExpire);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存储数据到hash表
        /// </summary>
        public bool Set<T>(string key, T t, int timeExpire)
        {
            try
            {
                RedisHelper.Set(key, t, timeExpire);
               
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据key获取数据
        /// </summary>
        public string Get(string key)
        {
            try
            {
                var value = RedisHelper.Get<string>(key);
                return value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 存取任意类型的值
        /// </summary>
        public T Get<T>(string key)
        {
            try
            {
                var result = RedisHelper.Get<T>(key);
                return result;
            }
            catch
            {
                return default(T);
            }
        }

        ///// <summary>
        ///// 移除key的value
        ///// </summary>
        //public bool Remove(string key)
        //{
        //    try
        //    {
        //        var result = Redis.Remove(key);
        //        Dispose();
        //        return result;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 移除hash中的某值
        ///// </summary>
        //public bool Remove(string hashId, string key)
        //{
        //    try
        //    {
        //        var result = Redis.RemoveEntryFromHash(hashId, key);
        //        Dispose();
        //        return result;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        #endregion
    }



}
