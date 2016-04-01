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

        public Repository CreateRepository(string username, RepositoryCreateInfo createInfo)
        {
            var t = CreateRepositoryAsync(username, createInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<Repository> CreateRepositoryAsync(string username, RepositoryCreateInfo createInfo)
        {
            var result = ApiUrl
                .AppendPathSegment($"/admin/users/{username}/repos")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PostJsonAsync(createInfo.GetRequestBody())
                .ReceiveJson<Repository>();

            return await result;
        }
    }
}
