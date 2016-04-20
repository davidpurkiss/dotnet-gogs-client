using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Gogs.Model
{
    public class RepositoryWebhook : RequestInfoBase
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string[] Events { get; set; }

        public bool? Active { get;set; }

        public Dictionary<string, string> Config { get; set; }

        public DateTime Updated_At { get; set; }

        public DateTime Created_At { get; set; }

        public RepositoryWebhook()
        {
            Config = new Dictionary<string, string>();
            Config.Add("url", null);
            Config.Add("content_type", "json");
        }

        internal override object GetRequestBody()
        {
            dynamic body = new ExpandoObject();

            if (Type != null)
                body.type = Type;
            else 
                body.type = "gogs";
            
            body.config = new ExpandoObject();
            var dict = (IDictionary<string, object>)body.config;
            foreach (var key in Config.Keys)
            {
                dict.Add(key, Config[key]);
            }

            if (Events != null) body.events = this.Events;
            if (Active != null) body.active = Active;

            return body;
        }
    }
}