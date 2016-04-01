using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class UserCreateInfo : UserCommon
    {
        public bool? Send_Notify { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = base.GetRequestBody();
            if (Send_Notify != null) body.send_notify = Send_Notify;

            return body;
        }
    }
}
