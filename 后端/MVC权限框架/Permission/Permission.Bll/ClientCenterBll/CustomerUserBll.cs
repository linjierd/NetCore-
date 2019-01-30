using Permission.Bll.Common;
using Permission.Library;
using Permission.Model.DbModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Permission.Library.Extensions;
namespace Permission.Bll.ClientCenterBll
{
    public class CustomerUserBll:BaseClientCenterBll<CustomerUserDb, CustomerUserBll>
    {
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="m">搜索模型</param>
        /// <returns></returns>
        public PagedList<CustomerUserDb> GetPageList(SearchModel m)
        {
            return ClientCenterDal.Set<CustomerUserDb>().Where(m).Pager(m);
        }

    }
}
