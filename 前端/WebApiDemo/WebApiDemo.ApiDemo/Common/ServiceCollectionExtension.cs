using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Bll.CustomerMangerBll;
using WebApiDemo.Bll.DingDan;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.Dal.Common;
using WebApiDemo.Dal.CustomerMangerDal;
using WebApiDemo.Dal.DingDanManagerDal;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.IBll.IDingDan;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.IDal.IDingDanManagerDal;

namespace WebApiDemo.ApiDemo
{
    public static class ServiceCollectionExtension
    {
        internal static void AddIocConfiguration(this IServiceCollection services)
        {

            services.AddScoped<IDingDanBll, DingDanBll>();
            services.AddScoped<IDingDanDal, DingDanDal>();
            services.AddScoped<ICustomerUserDal, CustomerUserDal>();
            services.AddScoped<IGerenxinxiDal, GerenxinxiDal>();
            services.AddScoped<DbConnManager>();
          //  services.AddSingleton<DbConnManager>();
            services.AddScoped<ICustomerUserBll, CustomerUserBll>();
            services.AddScoped<IGerenxinxiBll, GerenxinxiBll>();
            services.AddScoped<RedisManager>();
            
        }
    }
}
