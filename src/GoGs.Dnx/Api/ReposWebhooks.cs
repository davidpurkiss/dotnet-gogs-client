using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Gogs.Model;

namespace Gogs.Api
{
    public class ReposWebhooks : ApiBase
    {
        public ReposWebhooks(GogsClient client) : base(client)
        {

        }

        public IEnumerable<RepositoryWebhook> ListHooks(string repoName, string username = null)
        {
            var t = ListHooksAsync(repoName, username);
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<RepositoryWebhook>> ListHooksAsync(string repoName, string username = null)
        {
            if (string.IsNullOrWhiteSpace(username))
                username = _client.Username;

            var result = ApiUrl
                .AppendPathSegment($"/repos/{username}/{repoName}/hooks")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<RepositoryWebhook>>();

            return await result;
        }

        public RepositoryWebhook CreateHook(RepositoryWebhook repoWebHook, string repoName, string username = null)
        {
            var t = CreateHookAsync(repoWebHook, repoName, username);
            t.Wait();
            return t.Result;
        }

        public async Task<RepositoryWebhook> CreateHookAsync(RepositoryWebhook repoWebHook, string repoName, string username = null)
        {
            if (string.IsNullOrWhiteSpace(username))
                username = _client.Username;

            var result = ApiUrl
                .AppendPathSegment($"/repos/{username}/{repoName}/hooks")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PostJsonAsync(repoWebHook.GetRequestBody())
                .ReceiveJson<RepositoryWebhook>();

            return await result;
        }

        public RepositoryWebhook EditHook(RepositoryWebhook repoWebHook, string repoName, string username = null)
        {
            var t = EditHookAsync(repoWebHook, repoName, username);
            t.Wait();
            return t.Result;
        }

        public async Task<RepositoryWebhook> EditHookAsync(RepositoryWebhook repoWebHook, string repoName, string username = null)
        {
            if (string.IsNullOrWhiteSpace(username))
                username = _client.Username;

            var result = ApiUrl
                .AppendPathSegment($"/repos/{username}/{repoName}/hooks/{repoWebHook.Id}")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PatchJsonAsync(repoWebHook.GetRequestBody())
                .ReceiveJson<RepositoryWebhook>();

            return await result;
        }
    }
}
