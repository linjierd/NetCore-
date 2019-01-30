using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.IBll.IDingDan;
using WebApiDemo.IDal.IDingDanManagerDal;
using WebApiDemo.Model.DingDan;

namespace WebApiDemo.Bll.DingDan
{
    public class DingDanBll : IDingDanBll
    {
        private IDingDanDal _iDingDanDal;
        public DingDanBll(IDingDanDal iDingDanDal)
        {
            _iDingDanDal = iDingDanDal;
        }
        public List<DingdanJiesuanDto> GetDingDanPage(int dingDanYongHuId, int pageIndex, int pageSize, out int rowCount)
        {
            return _iDingDanDal.GetDingDanPage(dingDanYongHuId, pageIndex, pageSize, out rowCount);
        }
    }
}
