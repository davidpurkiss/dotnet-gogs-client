using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class UserEditInfo : UserCommon
    {
        public string Full_Name { get; set; }

        public string Website { get; set; }

        public string Location { get; set; }

        public bool? Active { get; set; }

        public bool? Admin { get; set; }

        public bool? Allow_Git_Hook { get; set; }

        public bool? Allow_Import_Local { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = base.GetRequestBody();

            if (Full_Name != null) body.full_name = Full_Name;
            if (Website!= null) body.website = Website;
            if (Location != null) body.location = Location;
            if (Active != null) body.active = Active;
            if (Admin != null) body.admin = Admin;
            if (Allow_Git_Hook != null) body.allow_git_hook = Allow_Git_Hook;
            if (Allow_Import_Local != null) body.allow_import_local = Allow_Import_Local;

            return body;
        }
    }
}
