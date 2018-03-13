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
            LoginBll name = new LoginBll();
            name.CartIsBlank("8");
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

    }
}
