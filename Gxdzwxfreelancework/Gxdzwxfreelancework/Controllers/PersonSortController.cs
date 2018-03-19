using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    public class PersonSortController : Controller
    {
       PersonSortBll SortInfoBll = new PersonSortBll();
        //
        // GET: /PersonSort/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SortNameInfo()
        {
            string responseText = "";

            responseText = SortInfoBll.SortNameInfo();
            return Content(responseText);
        }
        public ActionResult MiddleSortNameInfo()
        {
            string responseText = "";

            responseText = SortInfoBll.MiddleSortNameInfo();
            return Content(responseText);
        }

    }
}
