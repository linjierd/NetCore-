using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSizeDemo.WebSize.Models;

namespace WebSizeDemo.WebSize.Controllers
{
    public class CommonController :BaseController
    {
        public IActionResult ScriptConfig()
        {
            StringBuilder script = new StringBuilder();
            script.Append(" var webSizeConfig = {");
            script.Append("  apiHost:'" + ConfigManager.ApiHost + "',");
            script.Append("  userApiHost:'" + ConfigManager.UserApiHost + "',");
            script.Append("  clentType:'" + ConfigManager.ClentType + "',");
            script.Append("  token:'" + LoginManager.Token + "',");
            script.Append("  imageApiHost:'" + ConfigManager.ImageApiHost + "',");
            script.Append("  imageServerPath:'" + ConfigManager.ImageServerPath + "',");
            script.Append("  pageSize:10,");
            script.Append("  resultOk:'" + ResultCode.Ok + "',");
            script.Append("  resultFail:'" + ResultCode.Fail + "',");
            script.Append("  resultError:'" + ResultCode.Error + "'");
            script.Append(" } ");
            return Content(script.ToString());
        }
    }
}