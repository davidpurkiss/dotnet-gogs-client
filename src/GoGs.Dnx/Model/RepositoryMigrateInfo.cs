using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class RepositoryMigrateInfo : RequestInfoBase
    {
        public string Clone_Addr { get; set; }

        public string Auth_Username { get; set; }

        public string Auth_Password { get; set; }

        public int Uid { get; set; }

        public string Repo_Name { get; set; }

        public bool? Mirror { get; set; }

        public bool? Private { get; set; }

        public string Description { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = new ExpandoObject();
            body.clone_addr = Clone_Addr;
            if (Auth_Username != null) body.auth_username = Auth_Username;
            if (Auth_Password != null) body.auth_password = Auth_Password;
            body.uid = Uid;
            body.repo_name = Repo_Name;
            if (Mirror != null) body.mirror = Mirror;
            if (Private != null) body.@private = Private;
            if (Description != null) body.description = Description;

            return body;
        }
    }
}
