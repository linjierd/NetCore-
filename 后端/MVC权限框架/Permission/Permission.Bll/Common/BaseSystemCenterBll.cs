using Permission.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Bll.Common
{
    /// <summary>
    /// SystemCenter 运维操作的Bll的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseSystemCenterBll<T,U> where T : class, new()
                                        where U : class, new()
    {

        public static U Instance { get;} = new U();
        private SystemCenterDal<T> _SystemCenterDal;
        /// <summary>
        /// 构造
        /// </summary>
        public BaseSystemCenterBll()
        {
            //创建权限dal
            _SystemCenterDal = new SystemCenterDal<T>();
        }
        /// <summary>
        /// 权限dal只读属性
        /// </summary>
        public SystemCenterDal<T> SystemCenterDal
        {
            get
            {
                return new SystemCenterDal<T>();
            }
        }

        
    }
}
