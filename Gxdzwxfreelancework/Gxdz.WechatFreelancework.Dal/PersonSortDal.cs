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
                    string sql1 = string.Format("select * from GXFW_INFO t where PROFESSION='{0}' and SUCCESS='{1}' ", profession_name,"1");
                    DataTable dt1 = OracleHelper.GetTable(sql1, null);
                    for (int j = 0; j < dt1.Rows.Count; j++)//查询用户姓名和图片
                    {
                        string sql2 = string.Format("select * from GX_USER_MEMBER_PERSONAL t where USER_ID='{0}' ", dt1.Rows[j]["USER_ID"]);
                        DataTable dt2 = OracleHelper.GetTable(sql2, null);
                        if (dt2.Rows.Count != 0)
                        {
                            dt1.Rows[j]["USER_NAME"] = dt2.Rows[0]["NICK_NAME"];
                            string jpg = dt2.Rows[0]["CHAT_HEAD"].ToString();
                            if (dt2.Rows[0]["CHAT_HEAD"].ToString()=="")
                            {
                                dt1.Rows[j]["CHAT_HEAD"] = "avatar.jpg";
                            }
                            else
                            {
                                
                                dt1.Rows[j]["CHAT_HEAD"] = dt2.Rows[0]["CHAT_HEAD"];
                            }
                          
                        }
                        
                    }
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
        public user GetPersonInfo(string search_id)//获取单个人员的整体信息
        {
            string sql = string.Format("select * from GXFW_INFO t where SEARCH_ID='{0}' ", search_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            user user1=new user();
            user1.UserID = dt.Rows[0]["USER_ID"].ToString();
           // user1.UserName = dt.Rows[0]["USER_NAME"].ToString();
            user1.Profession = dt.Rows[0]["PROFESSION"].ToString();
            user1.Sex = dt.Rows[0]["SEX"].ToString();
            user1.Selfintroduction = dt.Rows[0]["SELFINTRODUCTION"].ToString();
            user1.Field = dt.Rows[0]["FIELD"].ToString();
            user1.Education = dt.Rows[0]["EDUCATION"].ToString();
            user1.Function = dt.Rows[0]["FUNCTION"].ToString();
            string sql2 = string.Format("select * from GX_USER_MEMBER_PERSONAL t where USER_ID='{0}' ", dt.Rows[0]["USER_ID"]);
            DataTable dt2 = OracleHelper.GetTable(sql2, null);
           if (dt2.Rows.Count != 0)
            {
                 user1.UserName = dt2.Rows[0]["NICK_NAME"].ToString();
                 string jpg = dt2.Rows[0]["CHAT_HEAD"].ToString();
                 if (dt2.Rows[0]["CHAT_HEAD"].ToString()=="")
                {
                    user1.ChatHead = "avatar.jpg";
                 }
                 else
                 {
                                
                   user1.ChatHead = dt2.Rows[0]["CHAT_HEAD"].ToString();
                  }
                          
           }
            return user1;
        }
    }

}
