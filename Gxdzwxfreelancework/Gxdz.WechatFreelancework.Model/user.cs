using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdz.WechatFreelancework.Model
{
    public class user
    {
        public virtual string UserID { get; set; }
        public virtual string UserNumber { get; set; }

        public virtual string UserName { get; set; }

        public virtual string NickName { get; set; }

        public virtual string Sex { get; set; }

        public virtual string Profession { get; set; }

        public virtual string Function { get; set; }

        public virtual string Education { get; set; }

        public virtual string Field { get; set; }

        public virtual string Selfintroduction { get; set; }
        public virtual string ChatHead { get; set; }

        public virtual string SearchID { get; set; }

        public virtual string Success { get; set; }

        public virtual string Address { get; set; }
    }
}
