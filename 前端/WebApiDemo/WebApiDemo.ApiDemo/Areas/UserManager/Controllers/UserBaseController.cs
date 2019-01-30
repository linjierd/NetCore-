using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ApiDemo.Controllers;
using WebApiDemo.Bll.MyAttribute;

namespace WebApiDemo.ApiDemo.Areas.UserManager.Controllers
{
    [Route("api/UserManager/[controller]/[action]")]
    [ApiController]
    [UserTokenVerification]
    public class UserBaseController : BaseController
    {
    }
}