using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Bll.MyAttribute;
using WebSizeDemo.WebSize.Controllers;

namespace WebSizeDemo.WebSize.Areas.PersonalUser.Controllers
{
    [Area("PersonalUser")]
    [UserLoginVerification]
    public class BasePersonalUserController : BaseController
    {
        
    }
}