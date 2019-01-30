using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSizeDemo.WebSize.Areas.PersonalUser.Controllers
{
    public class YouHuiQuanController : BasePersonalUserController
    {
        /// <summary>
        /// 我的优惠券页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UsableYouHuiQuanIndex()
        {
            return View();
        }
        /// <summary>
        /// 我的优惠券已使用页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UsedYouHuiQuanIndex()
        {
            return View();
        }
        /// <summary>
        /// 我的优惠券已过期页面
        /// </summary>
        /// <returns></returns>
        public IActionResult OutOfDateYouHuiQuanIndex()
        {
            return View();
        }
    }
}