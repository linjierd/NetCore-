using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebApiDemo.Dal.Common;

namespace WebApiDemo.Test.Common
{
    public class ConfigManager
    {
        public static IConfigurationRoot GetConfig()
        {
            var conf = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", true, true)
  // .AddJsonFile("appsettings.Development.json", true, true)
  .Build();
            return conf;
        }


        public static DbConnManager GetDbConnManager()
        {
           // IServiceCollection
            //IServiceCollection iServiceCollection = new ServiceCollection();
            //iServiceCollection.
            //var conf = GetConfig();
            //var dbConnOptions = conf.GetSection("DbConnOptions").Get<DbConnOptions>();
            //IOptions<DbConnOptions> options= dbConnOptions.
            DbConnManager dbConnManager = new
                DbConnManager(GetConfig());
            return dbConnManager;
        }


    }
}
