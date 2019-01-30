using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Model.DingDan;

namespace WebApiDemo.IBll.IDingDan
{
    public interface IDingDanBll
    {
        List<DingdanJiesuanDto> GetDingDanPage(int dingDanYongHuId, int pageIndex, int pageSize, out int rowCount);
    }
}
