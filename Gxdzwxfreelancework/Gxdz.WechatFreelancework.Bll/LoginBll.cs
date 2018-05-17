using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Utilities;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Model;
namespace Gxdz.WechatFreelancework.Bll
{
    public class LoginBll
    {
        LoginDal LoginInfoDal = new LoginDal();
        public string Register(user user1)
        {
            string responseText = "";
            responseText = LoginInfoDal.Register(user1);
            return responseText;
        }
        /// <summary>
        /// 填写个人会员信息
        /// </summary>
        /// <returns></returns>
        public string SetPersonalInfo(PersonalInfoModel personal, List<string> filename, string user_id)
        {
            string responText = "";
            responText = LoginInfoDal.SetPersonalInfo(personal, filename, user_id);
            return responText;
        }
         public string IsRegistered(string userid,string profession)
        {
            string responText = "";
            responText = LoginInfoDal.IsRegistered(userid, profession);
            return responText;
        }
         public string IsRegistered(string userid)
         {
             string responText = "";
             responText = LoginInfoDal.IsRegistered(userid);
             return responText;
         }
         public string GetUserNumberByUserId(string userid)  //得到用户编号
        {
            string responseText = "";
            responseText = LoginInfoDal.GetUserNumberByUserId(userid);
            return responseText;
        }

         public string GetLastNumber() //得到当前最大的编号
         {
             string responseText = "";
             responseText = LoginInfoDal.GetLastNumber();
             return responseText;
         }
         public string UpdateLastNumber(string number) //更新最新的编号
         {
             string responseText = "";
             responseText = LoginInfoDal.UpdateLastNumber(number);
             return responseText;
         }
         public int RegisterNumber(string userid)//该用户注册过的自由职业的数量
         { 
            return  LoginInfoDal.RegisterNumber(userid);    
         }
    }
}
