using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebSizeDemo.WebSize.Controllers;
using WebSizeDemo.WebSize.Models;

namespace WebSizeDemo.WebSize.Areas.PersonalUser.Controllers
{
    
    public class CommonController : BasePersonalUserController
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string userName,string userPassword)
        {
            ViewBag.UserName = userName;
            if (string.IsNullOrEmpty(userName)|| string.IsNullOrEmpty(userPassword))
            {
                ViewBag.Mess = "请输入用户名密码!";
            }
            string urlPara = $"/GetToken?loginName={userName}&passWord=" +
                $"{userPassword}&clientType={ConfigManager.ClentType}";
            string loginApiUrl = ConfigManager.UserApiHost + urlPara;
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient client = new HttpClient(handler))
            {
                //await异步等待回应
                var response =  client.GetAsync(loginApiUrl);
               string json=response.Result.Content.ReadAsStringAsync().Result;
                // dynamic result = JsonConvert.DeserializeObject<dynamic>(json);
                ResultModel result = JsonConvert.DeserializeObject<ResultModel>(json);
                if (result.result_code == ResultCode.Ok)
                {
                    LoginUserViewModel lgoinUser = new LoginUserViewModel
                    {
                        Token = result.result_data.token,
                        LoginName = result.result_data.loginName,
                        NickName = result.result_data.nickName,
                    };
                    LoginManager.IniLoginUser(lgoinUser);
                    return Redirect("/home/index");
                }
                else
                {
                    ViewBag.Mess = "用户名或者密码错误!";
                }
            }
                
            return View();
        }

        public IActionResult LoginOut()
        {
            LoginManager.LoginOut();
            return Redirect("/home/index");
        }
    }
}