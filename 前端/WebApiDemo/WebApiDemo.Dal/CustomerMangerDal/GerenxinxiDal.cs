using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.Common;
using WebApiDemo.Model.CustomerManger;
using Dapper;
using WebApiDemo.IDal.ICustomerMangerDal;

namespace WebApiDemo.Dal.CustomerMangerDal
{
    public class GerenxinxiDal :SystemCenterDalBase, IGerenxinxiDal
    {
        public GerenxinxiDal(DbConnManager dbConnManager) : base(dbConnManager)
        {

        }
        /// <summary>
        /// 获取前端用户
        /// </summary>
        /// <param name="GerenxinxiZhanghuming">账户名,  被逼这样命名</param>
        /// <returns></returns>
        public GerenxinxiDto GetModel(string GerenxinxiZhanghuming)
        {
            string sql = " select * from gerenxinxi where gerenxinxi_zhanghuming=@gerenxinxi_zhanghuming ";
            try
            {
                return CurrentDbConn.QueryFirstOrDefault<GerenxinxiDto>(sql, new { gerenxinxi_zhanghuming = GerenxinxiZhanghuming });
            }
            catch (Exception ex)
            {

            }
            return null;
            
        }

        public GerenxinxiDto GetModel(int id)
        {
            string sql = " select * from gerenxinxi where gerenxinxi_id=@gerenxinxi_id ";
            return CurrentDbConn.QueryFirstOrDefault<GerenxinxiDto>(sql, new { gerenxinxi_id = id });
        }


        public bool Update(GerenxinxiDto userDto)
        {
            string sql = @"UPDATE gerenxinxi 
   SET gerenxinxi_zhanghuming  =@gerenxinxi_zhanghuming
      ,gerenxinxi_mima  =@gerenxinxi_mima 
      ,gerenxinxi_touxiang  =@gerenxinxi_touxiang
      ,gerenxinxi_shengri  =@gerenxinxi_shengri 
      ,gerenxinxi_zhenshixingming  =@gerenxinxi_zhenshixingming 
      ,gerenxinxi_xingbie  =@gerenxinxi_xingbie
      ,gerenxinxi_shoujihao  =@gerenxinxi_shoujihao 
      ,gerenxinxi_provinceId  =@gerenxinxi_provinceId
      ,gerenxinxi_cityId  =@gerenxinxi_cityId
      ,gerenxinxi_areasId  =@gerenxinxi_areasId
      ,gerenxinxi_xiangxidizhi  =@gerenxinxi_xiangxidizhi 
      ,gerenxinxi_qq  =@gerenxinxi_qq
      ,gerenxinxi_youxiang  =@gerenxinxi_youxiang 
      ,gerenxinxi_xinyongdaima  =@gerenxinxi_xinyongdaima 
      ,gerenxinxi_shenfenzhenghao  =@gerenxinxi_shenfenzhenghao 
      ,gerenxinxi_zhuceriqi  =@gerenxinxi_zhuceriqi
      ,gerenxinxi_shifoukaidian  =@gerenxinxi_shifoukaidian
      ,gerenxinxi_huiyuandengji  =@gerenxinxi_huiyuandengji
      ,gerenxinxi_huiyuanjifen  =@gerenxinxi_huiyuanjifen
      ,gerenxinxi_huoyuedu  =@gerenxinxi_huoyuedu
 WHERE gerenxinxi_id=@gerenxinxi_id";
            return CurrentDbConn.Execute(sql, userDto) > 0;
        }
    }
}
