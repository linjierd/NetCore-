using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSizeDemo.WebSize.Models;

namespace WebSizeDemo.WebSize.Controllers
{
    public class BaseController : Controller
    {
        public LoginUserViewModel LoginUser
        {
            get {
                return LoginManager.GetLoginUser();
            }
        }
        public bool IsLogin {
            get {
                return LoginManager.IsLogin;
            }
        }
    }
}