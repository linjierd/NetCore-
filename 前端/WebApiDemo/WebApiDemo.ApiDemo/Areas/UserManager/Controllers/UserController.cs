using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Api.WebModel.Common;
using WebApiDemo.Api.WebModel.UserManager;
using WebApiDemo.ApiDemo.Controllers;
using WebApiDemo.Bll.MyAttribute;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.CommonLib.Tools.TypeTools;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;
using WebApiDemo.Model.EnumCommon;
using WebApiDemo.Model.ViewModel;

namespace WebApiDemo.ApiDemo.Areas.UserManager.Controllers
{
   
    [ApiController]
    public class UserController : UserBaseController
    {
        private IGerenxinxiBll _iGerenxinxiBll;
        public UserController(IGerenxinxiBll iGerenxinxiBll
            )
        {
            _iGerenxinxiBll = iGerenxinxiBll;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="passWord"></param>
        /// <param name="clientType"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ResultModel GetToken(string loginName, string passWord, int clientType)
        {
            ResultModel model = new ResultModel();
            try
            {
                if (!Enum.IsDefined(typeof(ClientType), clientType))
                {
                    model.result_code = ResultCode.Error;
                    model.result_data = "";
                    model.result_mess = "客户端类型不正确!";
                    return model;
                }
                // DiManager.GetDiObj<ICustomerUserBll>().GetModel("lzh");
                // _iCustomerUserBll.GetModel("lzh");
                UserAndTokenView userAndTokenView = _iGerenxinxiBll.GetToken(loginName, passWord, (ClientType)clientType);
              
                if (userAndTokenView == null)
                {
                    model.result_code = ResultCode.Fail;
                    model.result_data = "";
                    model.result_mess = "获取token失败!";
                }
                else
                {
                    LoginUserViewModel resultData = new LoginUserViewModel
                    {
                        token = userAndTokenView.Token,
                        loginName = userAndTokenView.gerenxinxi_zhanghuming,
                        nickName = userAndTokenView.gerenxinxi_zhenshixingming
                    };
                    model.result_code = ResultCode.Ok;
                    model.result_data = resultData;
                    model.result_mess = "获取token成功!";
                }
            }
            catch (Exception ex)
            {
                model.result_code = ResultCode.Error;
                model.result_data = "";
                model.result_mess = ex.ToString();
            }
            return model;
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public ResultModel GetUser()
        {
            ResultModel model = new ResultModel();
            string token = HttpContextManager.GetHeaderPara("token");
            if (string.IsNullOrEmpty(token))
            {
                model.result_code = ResultCode.Fail;
                model.result_data = "";
                model.result_mess = "缺少参数token";
                return model;
            }
            try
            {
                var dto = _iGerenxinxiBll.GetModelByToken(token);
                UserAndTokenView view = new UserAndTokenView();
                ModelCopier.CopyModel(dto, view);
                view.Token = token;
                model.result_code = ResultCode.Ok;
                model.result_data = view;
                model.result_mess = "获取用户成功";
            }
            catch (Exception ex)
            {
                model.result_code = ResultCode.Error;
                model.result_data = "";
                model.result_mess = ex.ToString();
            }
            return model;
        }
        [HttpPost]
        public ResultModel UpdateUser(UserAndTokenView view)
        {
            ResultModel model = new ResultModel();
            if (view == null)
            {
                model.result_code = ResultCode.Fail;
                model.result_data = "";
                model.result_mess = "提交数据不正确";
                return model;
            }
            if (string.IsNullOrEmpty(view.Token))
            {
                model.result_code = ResultCode.Fail;
                model.result_data = "";
                model.result_mess = "缺少参数token";
                return model;
            }
            try
            {
              var dto=  _iGerenxinxiBll.GetModel(view.gerenxinxi_zhanghuming);
                ModelCopier.CopyModel(view, dto, "gerenxinxi_zhanghuming");
                _iGerenxinxiBll.Update(dto);
                model.result_code = ResultCode.Ok;
                model.result_data = "";
                model.result_mess = "更新成功";
                return model;
            }
            catch (Exception ex)
            {
                model.result_code = ResultCode.Error;
                model.result_data = "";
                model.result_mess = ex.ToString();
            }
            return model;
        }
       
    }
}