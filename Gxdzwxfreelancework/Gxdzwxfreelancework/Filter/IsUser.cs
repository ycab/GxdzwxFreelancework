using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Model;
using Gxdz.WechatFreelancework.Utilities;
namespace Gxdzwxfreelancework.Filter
{
    public class IsUser : ActionFilterAttribute
    {
        //判断是否会员登录
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        //public string isOrNotUser()
        {
            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            //string responseText = "";
            try
            {
                string openid = CookieHelper.GetCookieValue("openid");

                if (openid == null)
                {
                    //未取到openid
                }
                else
                {
                    string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                    string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;//登录界面
                    string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                    string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;//完善信息界面
                    string user_id = getuserinfodal.GetUserID(openid);
                    string username = getuserinfodal.GetUserName(user_id);
                    if (user_id == "none")//如果没有注册
                    {
                        //System.Web.HttpContext.Current.Response.Write("<script language=javascript>location.replace("+url2+")" + "</script>");
                        //System.Web.HttpContext.Current.Response.Write("window.parent.location.href=" + url2 + "</script>");
                        System.Web.HttpContext.Current.Response.Redirect(url2);
                    }
                    else
                    {
                        string login_flag = CookieHelper.GetCookieValue("login_flag");
                        if (login_flag != "1")
                        {
                            //非会员，跳转登陆页面
                            System.Web.HttpContext.Current.Response.Redirect(url2);
                        }


                    }

                }
            }
            catch
            {

            }
        }
    }
}