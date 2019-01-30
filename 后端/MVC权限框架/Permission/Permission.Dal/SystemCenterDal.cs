using Permission.Dal.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Dal
{
    public class SystemCenterDal<T>:BaseDal<T> where T : class, new()
    {
        private static DbContext _DbContext;
        public override DbContext DbContext
        {
            get
            {
                return DbContextFactory.SystemCenterContainer;
            }
            set {
                _DbContext = value;
                DbContextFactory.SystemCenterContainer = value;
            }
        }
        /// <summary>
        /// 释放上下文
        /// </summary>
        public void DbContextDispose()
        {
            DbContext = null;
        }
    }
}
