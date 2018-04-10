using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gxdz.WechatFreelancework.Bll;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Model;
namespace Gxdzwxfreelancework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GxFreelanceWxIndex()
        {
            return View();
        }
        public ActionResult GxFreelanceWxClassification()
        {
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
        public string Register()   //用户注册2.0测试版本
        {
            user user1 = new user();
            user1.UserID = Guid.NewGuid().ToString("N");
            user1.Profession = Request["profession"];
            user1.Function = Request["function"];
            user1.Education = Request["education"];
            user1.Field = Request["field"];
            user1.Sex = Request["sex"];
            user1.Selfintroduction = Request["selfintroduction"];
            LoginBll login = new LoginBll();
            login.Register(user1);
            return "ok";
        }

    }
}
