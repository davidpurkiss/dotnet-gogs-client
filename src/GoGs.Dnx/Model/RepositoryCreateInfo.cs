using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class RepositoryCreateInfo : RequestInfoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool? Private { get; set; }

        public bool? Auto_Init { get; set; }

        public string GitIgnores { get; set; }

        public string License { get; set; }

        public string Readme { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = new ExpandoObject();
            body.name = Name;
            if (Description != null) body.description = Description;
            if (Private != null) body.@private = Private;
            if (Auto_Init != null) body.auto_init = Auto_Init;
            if (GitIgnores != null) body.gitignores = GitIgnores;
            if (License != null) body.license = License;
            if (Readme != null) body.readme = Readme;

            return body;
        }
    }
}
