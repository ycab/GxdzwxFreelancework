using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Utilities;
using Gxdz.WechatFreelancework.Model;
namespace Gxdz.WechatFreelancework.Dal
{
    public class PersonSortDal
    {
        public string SortNameInfo()
        {
            string responseText = "";
            string sql = "select * from GXFW_PROFESSION_CATEGORY";
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"sortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            }



            return responseText;
        }
        public string MiddleSortNameInfo()
        {
            string responseText = "";
            string sql = "select * from GXFW_INFO";
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"middlesortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            }



            return responseText;
        }
    }

}
