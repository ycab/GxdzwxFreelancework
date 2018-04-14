using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdz.WechatFreelancework.Model
{
    public class PersonalInfoModel
    {
        private string _nick_name;//会员昵称
        public string nick_name
        {
            get { return _nick_name; }
            set { _nick_name = value; }
        }
        //private string _chat_head;//会员头像
        //public string chat_head
        //{
        //    get { return _chat_head; }
        //    set { _chat_head = value; }
        //}
        private string _signature;//会员签名
        public string signature
        {
            get { return _signature; }
            set { _signature = value; }
        }
        private string _name;//会员姓名
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _id_number;//身份证号
        public string id_number
        {
            get { return _id_number; }
            set { _id_number = value; }
        }
        private string _sex;//性别
        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _industry_involved;//所属行业
        public string industry_involved
        {
            get { return _industry_involved; }
            set { _industry_involved = value; }
        }
        private string _company;//公司
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        private string _profession;//职业
        public string profession
        {
            get { return _profession; }
            set { _profession = value; }
        }
        private string _tel;//电话
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        private string _fax;//传真
        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;//邮箱
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        //private string _id_card;//身份证照
        //public string id_card
        //{
        //    get { return _id_card; }
        //    set { _id_card = value; }
        //}
    }
}
