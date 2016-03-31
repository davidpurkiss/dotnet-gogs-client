using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gogs.Model;
using Flurl;
using Flurl.Http;
using System.Dynamic;

namespace Gogs.Api
{
    public class AdminRepos : ApiBase
    {
        public AdminRepos(GogsClient client) : base(client)
        {
        }

        public Repository CreateRepository(string username, string name, string description = null, bool? @private = null, bool? autoInit = null, string gitIgnores = null, string license = null, string readme = null)
        {
            var t = CreateRepositoryAsync(username, name, description, @private, autoInit, gitIgnores, license, readme);
            t.Wait();
            return t.Result;
        }

        public async Task<Repository> CreateRepositoryAsync(string username, string name, string description = null, bool? @private = null, bool? autoInit = null, string gitIgnores = null, string license = null, string readme = null)
        {
            dynamic body = new ExpandoObject();
            body.name = name;
            if (description != null) body.description = description;
            if (@private != null) body.@private = @private;
            if (autoInit != null) body.auto_init = autoInit;
            if (gitIgnores != null) body.gitignores = gitIgnores;
            if (license != null) body.license = license;
            if (readme != null) body.readme = readme;

            var result = ApiUrl
                .AppendPathSegment($"/admin/users/{username}/repos")
                .WithHeader("Accept", "application/json")
                .WithOAuthBearerToken(_client.AccessToken)
                .PostJsonAsync(new { name = name })
                .ReceiveJson<Repository>();

            return await result;
        }
    }
}
