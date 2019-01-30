using Microsoft.AspNetCore.Mvc.Filters;

namespace WebSizeDemo.WebSize
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Logger.Log.Error("全局异常过滤器捕获的异常：", context.Exception);
        }
    }
}
