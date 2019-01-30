using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSizeDemo.WebSize.Areas.PersonalUser.Controllers
{
    public class HomeController : BasePersonalUserController
    {
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}