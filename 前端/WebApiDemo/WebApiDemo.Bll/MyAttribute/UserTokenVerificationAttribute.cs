using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Api.WebModel.Common;
using WebApiDemo.Bll.CustomerMangerBll;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.Model.EnumCommon;

namespace WebApiDemo.Bll.MyAttribute
{
    public class UserTokenVerificationAttribute : Attribute,  IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = GetToken(context);
            AllowAnonymousAttribute[] authoritybtnAttribute = (AllowAnonymousAttribute[])
                ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false);
            if (authoritybtnAttribute.Length > 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(token))
            {
                ResultModel model = new ResultModel();

                model.result_code = ResultCode.Error;
                model.result_data = null;
                model.result_mess = "您没有授权!";

                context.Result = new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(model)
                };
            }

           
            IGerenxinxiBll iGerenxinxiBll = DiManager.GetDiObj<IGerenxinxiBll>();
            if (!iGerenxinxiBll.ValidateToken(token))
            {
                ResultModel model = new ResultModel();
                model.result_code = ResultCode.Error;
                model.result_data = null;
                model.result_mess = "您没有授权!";
                context.Result = new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(model)
                };
            }
          

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
        }

        public string GetToken(ActionExecutingContext actionContext)
        {
            //  Microsoft.Extensions.Primitives.StringValues value;
            //  actionContext.HttpContext.Request.Headers.TryGetValue("token", out value);
            //  return value;
            return HttpContextManager.GetHeaderPara("token");
        }
    }
}
