using Permission.Bll.Common;
using Permission.Library;
using Permission.Model.DbModel.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Permission.Library.Extensions;
namespace Permission.Bll.TestBll
{
    public class TestBll : BaseSystemCenterBll<TestDb, TestBll>
    {
        public PagedList<TestDb> GetPageList(SearchModel m)
        {
            return SystemCenterDal.Set<TestDb>().Where(m).Pager(m);
        }
    }
}
