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
    public class GetUserInfoDal
    {
        public string GetUserID(string openid) //根据openid得到userid
        {
            string sql = string.Format("select * from GX_USER  where open_id='{0}' ", openid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string userid;
            if (dt.Rows.Count != 0)
            {
                userid = dt.Rows[0]["USER_ID"].ToString();
            }
            else
            {
                userid = "none";
            }
            return userid;
        }
        public string GetUserName(string userid)//根据userid得到个人会员表中的用户名
        {
            string sql = string.Format("select * from GX_USER_MEMBER_PERSONAL  where USER_ID='{0}' ", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string username = "";
            if (dt.Rows.Count != 0)
            {
                username = dt.Rows[0]["NAME"].ToString();
            }
            else
            {
                username = "none";
            }
            return username;

        }
        public string IsRegister(string userid)
        {
            string sql = string.Format("select * from GXFW_INFO  where USER_ID='{0}' ", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string response = "";
            if (dt.Rows.Count != 0)
            {
                response = "yes";
            }
            else
            {
                response = "no";
            }
            return response;

        }

    }
}
