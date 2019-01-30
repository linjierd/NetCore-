using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSizeDemo.WebSize.Controllers
{
    public class UserManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}