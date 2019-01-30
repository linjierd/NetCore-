using Permission.Model.DbModel;
using Permission.Model.DbModel.Client;
using Permission.Model.DbModel.System;
using Permission.Model.DbModel.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Dal.Common
{
    /// <summary>
    /// 权限库的连接上下文
    /// </summary>
    public class ClientCenterContainer : DbContext
    {
        public ClientCenterContainer() : base("ClientCenterContainer")
        {
        }

     
        public virtual DbSet<CustomerUserGuid> CustomerUserGuid { get; set; }
         public virtual DbSet<CustomerUserDb> CustomerUserDb { get; set; }
        

    }
    
}
