using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApiDemo.CommonLib.Common
{
    public static class DiManager
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set
            {
                if (_serviceProvider == null)
                {
                    _serviceProvider = value;
                }

            }
        }
        /// <summary>
        /// 获取依赖注入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDiObj<T>()
        {
            return _serviceProvider.GetService<T>();
        }
       
    }
}
