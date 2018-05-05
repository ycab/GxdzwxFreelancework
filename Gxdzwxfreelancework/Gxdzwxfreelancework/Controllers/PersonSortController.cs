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
            responseText = responseText.Replace("\n", " ");
            responseText = responseText.Replace("\r", " ");
            responseText = responseText.Replace("\\", "/");
            return Content(responseText);
        }
        public ActionResult PersonInfo(string search_id)
        {
            Session.Clear();
            user user1 = new user();
            user1 = SortInfoBll.GetPersonInfo(search_id);
            Session["user_id"] = user1.UserID;
            Session["user_name"] =user1.UserName;
            Session["sex"] = user1.Sex;
            Session["profession"] = user1.Profession;
            Session["function"] = user1.Function;
            Session["education"] = user1.Education;
            Session["field"] = user1.Field;
            Session["selfintroduction"] = user1.Selfintroduction;
            Session["chathead"] = user1.ChatHead;
            return View();
        }
        public ActionResult GetPersonList()
        {
            string profession = Request["profession"];
            string responseText=SortInfoBll.GetPersonListByProfession(profession);
            responseText = responseText.Replace("\n", " ");
            responseText = responseText.Replace("\r", " ");
            responseText = responseText.Replace("\\", "/");
            return Content(responseText);
        }

    }
}
