﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Utilities;
using Gxdz.WechatFreelancework.Dal;
namespace Gxdz.WechatFreelancework.Bll
{
    public class LoginBll
    {
        LoginDal name = new LoginDal();
        public string CartIsBlank(string user_id)
        {
            string responseText = "";
            responseText = name.CartIsBlank(user_id);
            return responseText;
        }
    }
}