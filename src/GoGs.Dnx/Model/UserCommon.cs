using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class UserCommon : RequestInfoBase
    {
        public int? Source_Id { get; set; }

        public string Login_Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = new ExpandoObject();
            if (Source_Id != null) body.source_id = Source_Id;
            body.login_name = Login_Name;
            body.username = Username;
            body.email = Email;
            body.Password = Password;

            return body;
        }
    }
}
