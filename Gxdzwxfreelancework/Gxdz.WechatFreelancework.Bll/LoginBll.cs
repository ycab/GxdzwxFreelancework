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
    }
}
