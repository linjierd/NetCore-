using Permission.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Bll.Common
{
    public class BaseClientCenterBll<T, U> where T : class, new()
                                        where U : class, new()
    {

        public static U Instance { get; } = new U();
        private ClientCenterDal<T> _ClientCenterDal;
        /// <summary>
        /// 构造
        /// </summary>
        public BaseClientCenterBll()
        {
            //创建权限dal
            _ClientCenterDal = new ClientCenterDal<T>();
        }
        /// <summary>
        /// 权限dal只读属性
        /// </summary>
        public ClientCenterDal<T> ClientCenterDal
        {
            get
            {
                return new ClientCenterDal<T>();
            }
        }


    }
}
