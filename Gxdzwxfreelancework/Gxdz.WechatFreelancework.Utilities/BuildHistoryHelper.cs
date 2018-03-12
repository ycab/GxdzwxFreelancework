using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Gxdz.WechatFreelancework.Utilities
{
    public class BuildHistoryHelper
    {

        private static string cookieName = "goods_history";//商品浏览历史cookie 的key

        public static string CookieName
        {
            get { return BuildHistoryHelper.cookieName; }
            //set { BuildHistoryHelper.cookieName = value; }
        }

        private static int count = 6;//浏览历史最大数目
        public static void SetHistory(string productId)
        {
            string history = string.Empty;

            if (productId == null || productId == "")
            {
                return;
            }
            //判断是否存在cookie
            if (CookieHelper.GetCookieValue(cookieName) == null) //cookie 不存在
            {
                //创建新的cookie,保存浏览记录
                CookieHelper.SetCookie(cookieName, productId, DateTime.Now.AddHours(1));
            }
            else //cookies已经存在
            {
                //获取浏览过的商品编号ID
                history = CookieHelper.GetCookieValue(cookieName);
            };
            //分解字符串为数组
            LinkedList<string> list = new LinkedList<string>(history.Split(','));

            if (list.Contains(productId))//如果当前商品id已经存在cookie中  
            {
                list.Remove(productId);
            }
            else
            {
                if (list.Count >= count)
                {
                    list.RemoveLast();//如果个数已经达到最大值，则删除最后一个  
                }
            }
            list.AddFirst(productId);//最新的商品置顶  

            StringBuilder sb = new StringBuilder();
            foreach (string proId in list)
            {

                sb.Append(proId + ",");
            }

            CookieHelper.SetCookie(cookieName, sb.ToString(0, sb.Length - 1).ToString());


        }

        /// <summary>
        /// 获取浏览历史
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static string BuildHistory()
        {
            string history = string.Empty;
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;//获取cookie集合  
            for (int i = 0; cookies != null && i < cookies.Count; i++)
            {
                if (cookies[i].Name == cookieName)
                {
                    history = HttpUtility.UrlDecode(cookies[i].Value);
                }
            }
            if (history == null)
            {
                return HttpUtility.UrlDecode("false");
            }
            LinkedList<string> list = new LinkedList<string>(history.Split(','));
            //if (list.Contains(productId))//如果当前商品id已经存在cookie中  
            //{
            //    list.Remove(productId);
            //}
            //else
            //{
            //    if (list.Count >= 5)
            //    {
            //        list.RemoveLast();//如果个数已经达到最大值，则删除最后一个  
            //    }
            //}
            //list.AddFirst(productId);//最新的商品置顶  

            StringBuilder sb = new StringBuilder();
            foreach (string proId in list)
            {
                sb.Append(proId + ",");
            }
            return sb.ToString(0, sb.Length - 1).ToString();//返回cookie值  
        }
    }

}
