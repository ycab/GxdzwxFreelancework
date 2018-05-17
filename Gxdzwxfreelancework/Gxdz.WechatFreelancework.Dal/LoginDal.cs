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
    public class LoginDal
    {
        public string Register(user user1)
        {

            var sql = string.Format("insert into GXFW_INFO(USER_ID,SEX,PROFESSION,FUNCTION,EDUCATION,FIELD,SELFINTRODUCTION,SEARCH_ID,SUCCESS,USER_NUMBER,ADDRESS) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", user1.UserID, user1.Sex, user1.Profession, user1.Function, user1.Education, user1.Field, user1.Selfintroduction, user1.SearchID,user1.Success,user1.UserNumber,user1.Address);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            return flag.ToString();
        }
        /// <summary>
        /// 填写个人会员信息
        /// </summary>
        /// <returns></returns>
        public string SetPersonalInfo(PersonalInfoModel personal, List<string> filename, string user_id)
        {
            string responseText = "";
            string chat_headname = "";
            string id_cardname = "";
            int count = filename.Count;
            chat_headname = filename[0];
            id_cardname = filename[1];
            //            string sql = string.Format("insert into GX_USER_MEMBER_PERSONAL(USER_ID,CHAT_HEAD,NICK_NAME,SIGNATURE,NAME,ID_NUMBER,SEX,AGE,INDUSTRY_INVOLVED,COMPANY,PROFESSION,TEL,FAX,EMAIL,ID_CARD) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", user_id, chat_headname, personal.nick_name, personal.signature, personal.name, personal.id_number, personal.sex, personal.age, personal.industry_involved, personal.company, personal.profession, personal.tel, personal.fax, personal.email,id_cardname);
            string sql = string.Format("update GX_USER_MEMBER_PERSONAL set CHAT_HEAD='{0}',NICK_NAME='{1}',SIGNATURE='{2}',NAME='{3}',ID_NUMBER='{4}',SEX='{5}',INDUSTRY_INVOLVED='{6}',COMPANY='{7}',PROFESSION='{8}',TEL='{9}',FAX ='{10}',EMAIL='{11}',ID_CARD='{12}' where USER_ID = '{13}'", chat_headname, personal.nick_name, personal.signature, personal.name, personal.id_number, personal.sex, personal.industry_involved, personal.company, personal.profession, personal.tel, personal.fax, personal.email, id_cardname, user_id);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            if (flag > 0)
            {
                responseText = "success";
            }
            else
                responseText = "fail";

            return responseText;
        }
        public string IsRegistered(string userid,string profession)//该用户是否注册某个具体职业
        {
            string sql = string.Format("select * from GXFW_INFO where USER_ID='{0}' and PROFESSION='{1}' ", userid, profession);
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
        public string IsRegistered(string userid)//该用户是否注册过任意职业
        {
            string sql = string.Format("select * from GXFW_INFO where USER_ID='{0}'", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
        public int RegisterNumber(string userid)//该用户注册过的自由职业的数量
        {
            string sql = string.Format("select * from GXFW_INFO where USER_ID='{0}'", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            return dt.Rows.Count;
        }
        public string GetUserNumberByUserId(string userid)  //得到用户编号
        {
            string sql = string.Format("select * from GXFW_INFO where USER_ID='{0}'", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string response = "";
            if(dt.Rows.Count !=0)
            {
                response = dt.Rows[0]["USER_NUMBER"].ToString();
            }
            return response;
        }
             
        public string GetLastNumber() //得到当前最大的编号
        {
            string sql = "select * from GXFW_INFO_NUMBER";
            DataTable dt = OracleHelper.GetTable(sql, null);
            string response = "";
            if(dt.Rows.Count !=0)
            {
                response = dt.Rows[0]["USER_NUMBER"].ToString();
            }
            return response;
        }
        public string UpdateLastNumber(string number) //更新最新的编号
        {
            string sql = string.Format("update GXFW_INFO_NUMBER set USER_NUMBER='{0}'",number);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            string responseText;
            if (flag > 0)
            {
                responseText = "success";
            }
            else
                responseText = "fail";

            return responseText;
        }
    }
}
