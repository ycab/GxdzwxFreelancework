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
            responseText = SortInfoDal.SortNameInfo();
            return responseText;
        }
        public string MiddleSortNameInfo()
        {
            string guid = Guid.NewGuid().ToString();
            string responseText = "";
            return responseText;
        }
        public user GetPersonInfo(string search_id)
        {
            string guid = Guid.NewGuid().ToString();
            user user1 = new user();
            user1 = SortInfoDal.GetPersonInfo(search_id);
            return user1;
        }
          public string GetPersonListByProfession(string profession)
        {
            string responseText = "";
            responseText = SortInfoDal.GetPersonListByProfession(profession);
            return responseText;
        }
    }
}
