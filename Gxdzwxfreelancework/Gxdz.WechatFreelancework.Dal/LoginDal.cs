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
            
            var sql = string.Format("insert into GXFW_INFO(USER_ID,SEX,PROFESSION,FUNCTION,EDUCATION,FIELD,SELFINTRODUCTION) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",  user1.UserID, user1.Sex, user1.Profession,user1.Function,user1.Education,user1.Field,user1.Selfintroduction);
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

    }
}
