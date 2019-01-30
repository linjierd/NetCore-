using Permission.Bll.ClientCenterBll;
using Permission.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Permission.WebManager.Controllers.CustomerUserManager
{
    public class CustomerUserManagerController :BaseController
    {
        // GET: CustomerUserManager
        public ActionResult List()
        {
            UrlBreadcrumbNavigation();
            return View();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="m">搜索模型</param>
        /// <returns></returns>
        public ActionResult GetList(SearchModel m)
        {
            var result = CustomerUserBll.Instance.GetPageList(m).ToDataTablesObject().
               Append(t => t.Add("edit", c => "<a class=\"ml-5 bg_xiugai\" href=\"JavaScript:void(null)\" onclick=\"openUpdate('" + c.user_id + "')\" >编辑</a> <a class=\"ml-5 bg_xiugai\" href=\"JavaScript:void(null)\" onclick=\"openUpdatePwd('" + c.user_id + "')\" >修改密码</a>")).GetDataTableJson(m);
            return Json(result);
        }
    }
}