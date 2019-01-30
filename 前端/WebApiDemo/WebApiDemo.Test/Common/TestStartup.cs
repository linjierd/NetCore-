using Castle.Core.Configuration;

using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.ApiDemo;

namespace WebApiDemo.Test.Common
{
    public class TestStartup: Startup
    {
        public TestStartup(Microsoft.Extensions.Configuration.IConfiguration iConfiguration) : base(iConfiguration)
        {
            
        }
    }
}
