using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using Gxdz.WechatFreelancework.Dal;
using Gxdz.WechatFreelancework.Utilities;
namespace Gxdz.WechatFreelancework.Dal
{
    public class LoginDal
    {
        public string CartIsBlank(string user_id)
        {
            string responseText = "";
            user_id = "8";
            //is_clear为1则购物车为空。
            string sql = "select cart_id,cart_date from GXSC_CART t where user_id='" + user_id + "' and is_clear='0'";
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"sortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failInfo\":\"没有查询到该会员对应的购物车，或者购物车为空！\"}";
            }

            return responseText;
        }
    }
}
