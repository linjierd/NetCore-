using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.Common;
using WebApiDemo.IDal.IDingDanManagerDal;
using WebApiDemo.Model.DingDan;

namespace WebApiDemo.Dal.DingDanManagerDal
{
    public class DingDanDal : SystemCenterDalBase, IDingDanDal
    {
        public DingDanDal(DbConnManager dbConnManager) : base(dbConnManager)
        {

        }
        public List<DingdanJiesuanDto> GetDingDanPage(int dingDanYongHuId, int pageIndex, int pageSize, out int rowCount)
        {
           
            string strWhere = "dingdan_yonghu=@dingdan_yonghu";
            Dictionary<string, object> whereDi = new Dictionary<string, object>();
            whereDi.Add("dingdan_yonghu", dingDanYongHuId);
            return SqlServer2012Page<DingdanJiesuanDto>(" * ", " dingdan_jiesuan ", " xiadan_shijian desc ", strWhere, pageSize, pageIndex, out rowCount, whereDi);
        }
    }
}
