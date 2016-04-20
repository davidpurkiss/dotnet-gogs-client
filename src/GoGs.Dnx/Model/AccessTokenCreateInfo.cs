using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gogs.Model
{
    public class AccessTokenCreateInfo : RequestInfoBase
    {
        public string Name { get; set; }

        internal override object GetRequestBody()
        {
            dynamic body = new ExpandoObject();

            body.name = Name;

            return body;
        }
    }
}
