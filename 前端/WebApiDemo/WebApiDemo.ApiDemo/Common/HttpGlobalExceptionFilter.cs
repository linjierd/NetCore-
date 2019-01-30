
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.CommonLib;

namespace WebApiDemo.ApiDemo
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LoggerTools.Log.Error("全局异常过滤器捕获的异常：", context.Exception);
        }
    }
}
