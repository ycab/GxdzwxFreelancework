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
            string sql = "select * from GXFW_PROFESSION_CATEGORY";
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string profession_name = dt.Rows[i]["PROFESSION_NAME"].ToString();
                    string profession_id = dt.Rows[i]["PROFESSION_ID"].ToString();
                    string sql1 = string.Format("select * from GXFW_INFO t where PROFESSION='{0}' ", profession_name);
                    DataTable dt1 = OracleHelper.GetTable(sql1, null);
                    string response = JsonHelper.getRecordJson(dt1);
                    if (i == dt.Rows.Count - 1)
                    {
                        responseText += "{\"profession_name\":\"" + profession_name + "\",\"profession_id\":\"" + profession_id + "\",\"info\":[" + response + "]}";
                    }
                    else
                    {
                        responseText += "{\"profession_name\":\"" + profession_name + "\",\"profession_id\":\"" + profession_id + "\",\"info\":[" + response + "]},";
                    }
                }
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
