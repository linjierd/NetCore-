using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Dal.Common
{
    public partial class DbContextFactory
    {
        private static readonly object locker = new object();
        /// <summary>
        /// 创建EF上下文对象,已存在就直接取,不存在就创建,保证线程内是唯一。
        /// </summary>
        /// <param name="flag">是否直接创建</param>
        /// <returns></returns>
        //public static DbContext CreatePermission(bool flag = false) 
        //{

            //DbContext dbContext = CallContext.GetData("PermissionDbContainer") as DbContext;
            //if (flag)
            //{
            //    dbContext = new PermissionContainer();
            //    CallContext.SetData("PermissionDbContainer", dbContext);
            //}
            // else if (dbContext == null)
            //if (dbContext == null)
            //{
            //    lock (locker)
            //    {
            //        if (dbContext == null)
            //        {
            //            dbContext = new PermissionContainer();
            //            //   CallContext.SetData("PermissionDbContainer", dbContext);
            //        }
            //    }
            //}
          //  return dbContext;
        //    return new PermissionContainer();
        //}


        public static DbContext SystemCenterContainer
        {
            get
            {
                DbContext dbContext = CallContext.GetData("SystemCenterDbContainer") as DbContext;
                if (dbContext == null)
                {
                    lock (locker)
                    {
                        if (dbContext == null)
                        {
                            dbContext = new SystemCenterContainer();
                            CallContext.SetData("SystemCenterDbContainer", dbContext);
                        }
                    }
                }
                return dbContext;
            }
            set { CallContext.SetData("SystemCenterDbContainer", value); }
        }


        public static DbContext ClientCenterContainer
        {
            get
            {
                DbContext dbContext = CallContext.GetData("ClientCenterContainer") as DbContext;
                if (dbContext == null)
                {
                    lock (locker)
                    {
                        if (dbContext == null)
                        {
                            dbContext = new ClientCenterContainer();
                            CallContext.SetData("ClientCenterContainer", dbContext);
                        }
                    }
                }
                return dbContext;
            }
            set { CallContext.SetData("ClientCenterContainer", value); }
        }

    }
}
