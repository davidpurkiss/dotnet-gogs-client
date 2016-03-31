using System.Collections;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;

namespace Gogs.Api
{
    public abstract class ApiBase
    {
        protected GogsClient _client;

        public ApiBase(GogsClient client)
        {
            _client = client;
        }

        internal string ApiUrl
        {
            get
            {
                return _client.ApiUrl;
            }
        }
    }

    internal static class Extensions
    {
        internal static void AddQueryParam(this Dictionary<string, object> queryParams, string name, object value)
        {
            if (value != null)
                queryParams.Add(name, value);
        }
    }
}