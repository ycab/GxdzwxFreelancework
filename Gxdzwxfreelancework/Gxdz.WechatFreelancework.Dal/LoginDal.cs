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
            
            var sql = string.Format("insert into GX_ZYZY_USER(USERID,SEX,PROFESSION,FUNCTION,EDUCATION,FIELD,SELFINTRODUCTION) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",  user1.UserID, user1.Sex, user1.Profession,user1.Function,user1.Education,user1.Field,user1.Selfintroduction);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            return flag.ToString();
        }
    }
}
