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
    public class PersonSortBll
    {
        PersonSortDal SortInfoDal = new PersonSortDal();
        public string SortNameInfo()
        {
            string guid = Guid.NewGuid().ToString();
            string responseText = "";
           // int sortnamelast = Convert.ToInt32(sortname_last);//对于null不会报异常,使用int.Parse报异常
           // int sortnameamount = Convert.ToInt32(sortname_amount);
            responseText = SortInfoDal.SortNameInfo();
            return responseText;
        }
        public string MiddleSortNameInfo()
        {
            string guid = Guid.NewGuid().ToString();
            string responseText = "";
            // int sortnamelast = Convert.ToInt32(sortname_last);//对于null不会报异常,使用int.Parse报异常
            // int sortnameamount = Convert.ToInt32(sortname_amount);
            responseText = SortInfoDal.MiddleSortNameInfo();
            return responseText;
        }
        public user GetPersonInfo(string user_id)
        {
            string guid = Guid.NewGuid().ToString();
            user user1 = new user();
            // int sortnamelast = Convert.ToInt32(sortname_last);//对于null不会报异常,使用int.Parse报异常
            // int sortnameamount = Convert.ToInt32(sortname_amount);
            user1 = SortInfoDal.GetPersonInfo(user_id);
            return user1;
        }
    }
}
