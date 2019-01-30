using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.CommonLib.Common;
using WebApiDemo.CommonLib.Tools.Jwt;
using WebApiDemo.CommonLib.Tools.Text;
using WebApiDemo.CommonLib.Tools.TypeTools;
using WebApiDemo.IBll.ICustomerMangerBll;
using WebApiDemo.IDal.ICustomerMangerDal;
using WebApiDemo.Model.CustomerManger;
using WebApiDemo.Model.EnumCommon;
using WebApiDemo.Model.ViewModel;

namespace WebApiDemo.Bll.CustomerMangerBll
{
    public class GerenxinxiBll : IGerenxinxiBll
    {
        public int expireSecond = 1400;
        private IGerenxinxiDal _iGerenxinxiDal;
     
        private RedisManager _redisManager;
        public GerenxinxiBll(IGerenxinxiDal iGerenxinxiDal,RedisManager redisManager)
        {
            _iGerenxinxiDal = iGerenxinxiDal;
            _redisManager = redisManager;

        }
        public GerenxinxiDto GetModel(string gerenxinxiZhanghuming)
        {
           
            return _iGerenxinxiDal.GetModel(gerenxinxiZhanghuming);
        }
        public GerenxinxiDto GetModelByToken(string token)
        {
            var viewModel = GetUserInCachen(token);
            if (viewModel != null) return GetModel(viewModel.gerenxinxi_zhanghuming);
            return null;

        }

        public bool ValidateToken(string token)
        {
            if (GetUserInCachen(token) != null) return true;
            return false;
        }
        public UserAndTokenView GetToken(string userName, string passWord, ClientType clientType)
        {
            GerenxinxiDto dto = GetModel(userName);
            if (dto != null)
            {
                if (dto.gerenxinxi_mima.ToUpper() == StringMd5.Md5Hash32Salt(passWord).ToUpper())
                {
                    return GetToken(dto, clientType);
                }
            }
            return null;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="gerenxinxiDto">用户</param>
        /// <returns></returns>
        public UserAndTokenView GetToken(GerenxinxiDto gerenxinxiDto, ClientType clientType)
        {
           
            SimpleTokenInfo tokenInfo = new SimpleTokenInfo();
            tokenInfo.ZhangHuMing = gerenxinxiDto.gerenxinxi_zhanghuming + "_" + ((int)clientType).ToString();
            string token = JwtUtil.Encode(tokenInfo);
            UserAndTokenView userAndTokenView = new UserAndTokenView();
            userAndTokenView.Token = token;
            ModelCopier.CopyModel(gerenxinxiDto, userAndTokenView);
            string userJson = JsonConvert.SerializeObject(userAndTokenView);
            try
            {
                _redisManager.Set(tokenInfo.ZhangHuMing, userJson, expireSecond);
            }
            catch
            {
                return null ;
            }

            return userAndTokenView;
        }
        /// <summary>
        /// 用token在缓存中获取用户,返回Null代表token无效
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public UserAndTokenView GetUserInCachen(string token)
        {
            SimpleTokenInfo tokenInfo = JwtUtil.Decode<SimpleTokenInfo>(token);
            if (tokenInfo == null) return null;
          
            string userJson = _redisManager.Get<string>(tokenInfo.ZhangHuMing);
            if (!string.IsNullOrEmpty(userJson))
            {

                UserAndTokenView userAndToken = JsonConvert.DeserializeObject<UserAndTokenView>(userJson);
                if (userAndToken.Token.Equals(token))
                {
                    _redisManager.Set(userAndToken.gerenxinxi_zhanghuming, userJson, expireSecond);
                    return userAndToken;
                }

                return null;
            }
            return null;
        }


        public bool Update(GerenxinxiDto userDto)
        {

            return _iGerenxinxiDal.Update(userDto);
        }

       
    }
}
