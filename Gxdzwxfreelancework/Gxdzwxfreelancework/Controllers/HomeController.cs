using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Model;
using Gxdz.WechatFreelancework.Utilities;
using Gxdzwxfreelancework.Filter;
namespace Gxdzwxfreelancework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GxFreelanceWxIndex(string openid)
        {
            return View();
        }
        public ActionResult GxFreelanceWxClassification(string openid)
        {
            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            if (openid == null)
            {


                openid = "oXx_Mw-hx0yNF3wIELsf_RP6cJoA";
                string user_id = getuserinfodal.GetUserID(openid);
                string username = getuserinfodal.GetUserName(user_id);
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                Session["user_id"] = user_id;
                Session["user_name"] = username;
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                Session["RegisterUrl"] = url2;
                string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;
                Session["FinishRegisterUrl"] = url4;
                ViewBag.openid = openid;
            }
            else
            {
                ViewBag.openid = openid;
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
            }
            return View();
        }
        [IsUser]
        public ActionResult GxFreelanceWxLogin()
        {
            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            string user_name = getuserinfodal.GetUserName(user_id);
            string membership = getuserinfodal.GetMemberType(user_id);
            if (getuserinfodal.IsRegister(user_id) == "yes")//注册过
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"您已注册，无需重复注册\")" + "</script>");
                return View("GxFreelanceWxClassification");
            }
            else
            {
                    if (membership == "个人会员")
                    {
                        if (user_name == "")//信息未完善
                        {
                            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"请先完善会员信息\")" + "</script>");
                            return View("GxFreelanceWxClassification");
                        }

                        else
                        {
                            return View();
                        }
 
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"企业会员，无法注册\")" + "</script>");
                        return View("GxFreelanceWxClassification");
                    }


            }

        }
        public ActionResult GxFreelanceWxExample()
        {
            return View();
        }
        public ActionResult GxFreelanceWxCheck()
        {
            return View();
        }
        public string GxFreelanceWxRegister()   //用户注册
        {
            user user1 = new user();
            user1.UserID = Guid.NewGuid().ToString("N");
            user1.Profession = Request["zhiye"];
            user1.Function = Request["zhineng"];
            user1.Education = Request["xueli"];
            user1.Field = Request["zhuanzhulingyu"];
            user1.Sex = Request["sex"];
            user1.Selfintroduction = Request["user_desc"];
            LoginBll login = new LoginBll();
            login.Register(user1);
            return "ok";
        }
        public ActionResult Register()   //用户注册2.0测试版本
        {

            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            user user1 = new user();
            user1.UserID = user_id;
            user1.Profession = Request["profession"];
            user1.Function = Request["function"];
            user1.Education = Request["education"];
            user1.Field = Request["field"];
            user1.Sex = Request["sex"];
            user1.Selfintroduction = Request["selfintroduction"];
            LoginBll login = new LoginBll();
            login.Register(user1);
            return Content("ok");


          
        }
        public ActionResult RedirectToRegisterUser()
        {
            string url = Session["RegisterUrl"].ToString();
            System.Web.HttpContext.Current.Response.Redirect(url);
            return View();
        }
        public ActionResult RedirectToFinishRegisterUser()
        {
            string openid = CookieHelper.GetCookieValue("openid");
            string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
            string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;
            System.Web.HttpContext.Current.Response.Redirect(url4);
            return View();
        }

    }
}
