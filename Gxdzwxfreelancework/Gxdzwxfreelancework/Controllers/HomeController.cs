using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Model;
using Gxdz.WechatFreelancework.Utilities;
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


                //openid = "oXx_Mw-hx0yNF3wIELsf_RP6cJoA";
                //string user_id = getuserinfodal.GetUserID(openid);
                //string username = getuserinfodal.GetUserName(user_id);
                //Session["user_id"] = user_id;
                //Session["user_name"] = username;
                //string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                //string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                //Session["RegisterUrl"] = url2;
                //string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                //string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;
                //Session["FinishRegisterUrl"] = url4;
                //ViewBag.openid = openid;
            }
            else
            {
                ViewBag.openid = openid;
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                Session["RegisterUrl"] = url2;
                string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;
                Session["FinishRegisterUrl"] = url4;
                string user_id = getuserinfodal.GetUserID(openid);
                string username = getuserinfodal.GetUserName(user_id);
                if (user_id == "none")//如果没有注册
                {
                    Session["user_id"] = user_id;
                    Session["user_name"] = user_id;
                }
                else
                {
                    Session["user_id"] = user_id;
                    Session["user_name"] = getuserinfodal.GetUserName(user_id);
                }


                //Session["user_id"] = "70";
                //Session["user_name"] = "70";
            }
            return View();
        }
        public ActionResult GxFreelanceWxLogin()
        {
            return View();
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
            //Session["user_id"] = "none";
            //string openid = "dd";
            //string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
            //string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
            //Session["RegisterUrl"] = url2;
            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            string user_id = Session["user_id"].ToString();
            string user_name = Session["user_name"].ToString();
            if(getuserinfodal.IsRegister(user_id)=="yes")
            {
                return Content("registered");
            }
            else
            {
                if (user_id == "none")
                {
                    return Content("none");
                }
                else if (user_name == "")
                {
                    return Content("nousername");
                }
                else
                {
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
            }

          
        }
        public ActionResult RedirectToRegisterUser()
        {
            string url = Session["RegisterUrl"].ToString();
            System.Web.HttpContext.Current.Response.Redirect(url);
            return View();
        }
        public ActionResult RedirectToFinishRegisterUser()
        {
            string url = Session["FinishRegisterUrl"].ToString();
            System.Web.HttpContext.Current.Response.Redirect(url);
            return View();
        }

    }
}
