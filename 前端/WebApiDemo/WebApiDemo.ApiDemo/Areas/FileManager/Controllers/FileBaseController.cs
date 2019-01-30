using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.ApiDemo.Controllers;

namespace WebApiDemo.ApiDemo.Areas.FileManager.Controllers
{
    [Route("api/FileManager/[controller]/[action]")]
    [ApiController]
    public class FileBaseController : BaseController
    {
    }
}