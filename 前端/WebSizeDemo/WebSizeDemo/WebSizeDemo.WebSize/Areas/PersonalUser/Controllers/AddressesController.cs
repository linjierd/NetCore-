using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSizeDemo.WebSize.Areas.PersonalUser.Controllers
{
    public class AddressesController : BasePersonalUserController
    {
        public IActionResult Index()
        {
            ViewBag.MenumNumber = 2;
            return View();
        }
    }
}