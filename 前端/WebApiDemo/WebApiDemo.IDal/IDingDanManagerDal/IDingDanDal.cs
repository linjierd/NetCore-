using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Model.DingDan;

namespace WebApiDemo.IDal.IDingDanManagerDal
{
    public interface IDingDanDal
    {
        List<DingdanJiesuanDto> GetDingDanPage(int dingDanYongHuId, int pageIndex, int pageSize, out int rowCount);
    }
}
