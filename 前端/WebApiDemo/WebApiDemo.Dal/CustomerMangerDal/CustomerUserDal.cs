using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Dal.Common;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;
using Dapper;
namespace WebApiDemo.Dal.CustomerMangerDal
{
    public class CustomerUserDal : ClientCenterDalBase, ICustomerUserDal
    {
        
        public CustomerUserDal(DbConnManager dbConnManager) :base(dbConnManager)
        {
           
        }
       

        public CustomerUserDto GetModel(long id)
        {
            string sql = " select * from customer_user  where user_id=@user_id ";
            return CurrentDbConn.QueryFirstOrDefault<CustomerUserDto>(sql, new { user_id = id });
        }

        public CustomerUserDto GetModel(string userName)
        {
            string sql = " select * from customer_user  where user_login_name=@user_login_name ";
            return CurrentDbConn.QueryFirstOrDefault<CustomerUserDto>(sql, new { user_login_name = userName });
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(CustomerUserDto model)
        {
            string getIdSql = @"INSERT INTO  customer_user_guid 
           (user_login_name 
           ,create_date )
     VALUES
           ('@user_login_name' 
           ,getdate());SELECT IDENT_CURRENT('customer_user_guid') ";
            long id = CurrentDbConn.ExecuteScalar<int>(getIdSql, new { model.user_login_name }); //获取id
            model.user_id = id;
            model.creator_date = DateTime.Now;
            string sql = @"INSERT INTO customer_user 
           (user_id 
           ,user_login_name 
           ,user_password 
           ,user_full_name 
           ,user_phone_number 
           ,user_mail 
           ,creator_date )
     VALUES
             (@user_id 
             ,@user_login_name 
             ,@user_password 
             ,@user_full_name 
             ,@user_phone_number 
             ,@user_mail 
             ,@creator_date );";
            CurrentDbConn.Execute(sql, model); //插入用户
            return id;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(CustomerUserDto model)
        {
            string sql = @"UPDATE customer_user 
   SET user_full_name  = @user_full_name
      ,user_phone_number  = @user_phone_number
      ,user_mail  = @user_mail
 WHERE user_id  = @user_id ;";
            int result = CurrentDbConn.Execute(sql, model); //更新用户
            return result > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePassWord(long userId,string passWord)
        {
            string sql = @"UPDATE customer_user 
   SET user_password  = @user_password
   WHERE user_id  = @user_id ;";
            int result = CurrentDbConn.Execute(sql, new { user_password=passWord, user_id=userId }); //更新用户
            return result > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Delete(string  userName)
        {
            string sql = @"delete customer_user 
  
   WHERE user_login_name  = @user_login_name ;";
            int result = CurrentDbConn.Execute(sql, new { user_login_name = userName }); //更新用户
            return result > 0;
        }

        public List<CustomerUserDto> GetPageList(int pageSize, int startRecord, string userLoginName, out int rowCount)
        {
            StringBuilder strWhere = new StringBuilder();
            Dictionary<string, object> searchItem = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(userLoginName))
            {
                strWhere.Append(" user_login_name like @user_login_name ");
                searchItem.Add("user_login_name", userLoginName);
            }

            List<CustomerUserDto> result = SqlServer2012Page<CustomerUserDto>(
                "*", "customer_user", "user_id desc", strWhere.ToString(), pageSize, startRecord, out rowCount, searchItem, true);
            return result;
        }
        
        
       
    }
}
