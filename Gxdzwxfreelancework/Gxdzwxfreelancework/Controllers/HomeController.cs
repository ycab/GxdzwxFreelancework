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
            user user1 =new user();
            user1.UserID = Guid.NewGuid().ToString("N");
            user1.Profession = Request["zhiye"];
            user1.Function = Request["zhineng"];
            user1.Education = Request["xueli"];
            user1.Field= Request["zhuanzhulingyu"];
            user1.Sex = Request["sex"];
            user1.Selfintroduction = Request["user_desc"];
            LoginDal login = new LoginDal();
            login.Register(user1);
            return View();
        }

    }
}
