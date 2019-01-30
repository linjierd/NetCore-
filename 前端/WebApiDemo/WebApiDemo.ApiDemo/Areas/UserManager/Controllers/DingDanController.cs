using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Api.WebModel.Common;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.IBll.IDingDan;
using WebApiDemo.Model.EnumCommon;

namespace WebApiDemo.ApiDemo.Areas.UserManager.Controllers
{

    [ApiController]
    public class DingDanController : UserBaseController
    {
        private IDingDanBll _iDingDanBll;
        private IGerenxinxiBll _iGerenxinxiBll;
        public DingDanController(IDingDanBll dingDanBll,IGerenxinxiBll iGerenxinxiBll)
        {
            _iDingDanBll = dingDanBll;
            _iGerenxinxiBll = iGerenxinxiBll;
        }
        public ResultModel GetDingDanPage( int pageIndex, int pageSize)
        {
            ResultModel resultModel = new ResultModel();
            string token = HttpContextManager.GetHeaderPara("token");
            if (string.IsNullOrEmpty(token))
            {
                resultModel.result_code = ResultCode.Fail;
                resultModel.result_mess = "token参数不正确";
                return resultModel;
            }
            var gerenxinModel= _iGerenxinxiBll.GetModelByToken(token);
            if (gerenxinModel == null)
            {
                resultModel.result_code = ResultCode.Fail;
                resultModel.result_mess = "无法通过token获取用户,可能是因为没有登录";
                return resultModel;
            }
            int rowCount = 0;
            var orderList = _iDingDanBll.GetDingDanPage(gerenxinModel.gerenxinxi_id, pageIndex, pageSize, out rowCount);
            var orderListPage = new
            {
                rowCount,
                orderList
            };
            resultModel.result_code = ResultCode.Ok;
            resultModel.result_data = orderListPage;
            resultModel.result_mess = "查询订单成功";
            return resultModel;
        }

    }
}