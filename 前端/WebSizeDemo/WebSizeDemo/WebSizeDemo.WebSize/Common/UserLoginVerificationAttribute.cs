using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSizeDemo.WebSize;

namespace WebApiDemo.Bll.MyAttribute
{
    public class UserLoginVerificationAttribute : Attribute,  IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            AllowAnonymousAttribute[] authoritybtnAttribute = (AllowAnonymousAttribute[])
              ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false);
            if (authoritybtnAttribute.Length == 0&&!LoginManager.IsLogin)
            {
                context.HttpContext.Response.Redirect("/PersonalUser/Common/Login");
            }

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
        }

       
    }
}
