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
    }
}
