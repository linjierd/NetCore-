using Permission.Model.DbModel;
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
    public class SystemCenterContainer : DbContext
    {
        public SystemCenterContainer() : base("SystemCenterDbContainer")
        {
        }

        
        public virtual DbSet<ModuleDb> ModuleDb { get; set; }
        public virtual DbSet<RoleDb> RoleDb { get; set; }
        public virtual DbSet<RoleModuleRelationDb> RoleModuleRelation { get; set; }
        public virtual DbSet<AdminUserDb> AdminUser { get; set; }
        public virtual DbSet<AdminUserRoleRelationDb> AdminUserRoleRelation { get; set; }

        public virtual DbSet<DictionaryTableDb> DictionaryTable { get; set; }

        public virtual DbSet<DictionaryTypeTableDb> DictionaryTypeTableDb { get; set; }
        

    }
}
