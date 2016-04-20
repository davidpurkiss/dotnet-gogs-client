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
    public class Repos : ApiBase
    {
        public Repos(GogsClient client) : base(client)
        {
        }

        public IEnumerable<Repository> SearchRespositories(string q, int? uid = null, int? limit = null)
        {
            var t = SearchRespositoriesAsync(q, uid, limit);
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<Repository>> SearchRespositoriesAsync(string q, int? uid = null, int? limit = null)
        {
            var url = ApiUrl
                .AppendPathSegment($"/repos/search")
                .SetQueryParam("q", q);

            if (uid != null)
                url = url.SetQueryParam("uid", uid);

            if (limit != null)
                url = url.SetQueryParam("limit", limit);

            var result = url
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<Repository>>();

            return await result;
        }

        public IEnumerable<Repository> ListRepositories()
        {
            var t = ListRepositoriesAsync();
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<Repository>> ListRepositoriesAsync()
        {
            var result = ApiUrl
                .AppendPathSegment($"user/repos")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<Repository>>();

            return await result;
        }

        public Repository CreateRepository(RepositoryCreateInfo createInfo, string organization = null)
        {
            var t = CreateRepositoryAsync(createInfo, organization);
            t.Wait();
            return t.Result;
        }

        public async Task<Repository> CreateRepositoryAsync(RepositoryCreateInfo createInfo, string organization = null)
        {
            string resource = null;

            if (organization != null)
                resource = $"/user/repos";
            else
                resource = $"org/{organization}/repos";

            var result = ApiUrl
                .AppendPathSegment(resource)
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PostJsonAsync(createInfo.GetRequestBody())
                .ReceiveJson<Repository>();

            return await result;
        }

        public Repository MigrateRepository(RepositoryMigrateInfo migrateInfo)
        {
            var t = MigrateRepositoryAsync(migrateInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<Repository> MigrateRepositoryAsync(RepositoryMigrateInfo migrateInfo)
        {
            var result = ApiUrl
                .AppendPathSegment("/repos/migrate")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PostJsonAsync(migrateInfo.GetRequestBody())
                .ReceiveJson<Repository>();

            return await result;
        }

        public Repository GetRepository(string owner, string repo)
        {
            var t = GetRepositoryAsync(owner, repo);
            t.Wait();
            return t.Result;
        }

        public async Task<Repository> GetRepositoryAsync(string owner, string repo)
        {
            var result = ApiUrl
                .AppendPathSegment($"/repos/{owner}/{repo}")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<Repository>();

            return await result;
        }

        public bool DeleteRepository(string owner, string repo)
        {
            var t = DeleteRepositoryAsync(owner, repo);
            t.Wait();
            return t.Result;
        }

        public async Task<bool> DeleteRepositoryAsync(string owner, string repo)
        {
            var result = await ApiUrl
              .AppendPathSegment($"/repos/{owner}/{repo}")
              .WithHeader("Accept", "application/json")
              .WithHeader("Authorization", $"token {_client.AccessToken}")
              .DeleteAsync();

            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public IEnumerable<Branch> ListBranches(string owner, string repo)
        {
            var t = ListBranchesAsync(owner, repo);
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<Branch>> ListBranchesAsync(string owner, string repo)
        {
            var result = ApiUrl
                .AppendPathSegment($"/repos/{owner}/{repo}/branches")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<Branch>>();

            return await result;
        }

        public Branch GetBranch(string owner, string repo, string branch)
        {
            var t = GetBranchAsync(owner, repo, branch);
            t.Wait();
            return t.Result;
        }

        public async Task<Branch> GetBranchAsync(string owner, string repo, string branch)
        {
            var result = ApiUrl
                .AppendPathSegment($"/repos/{owner}/{repo}/branches/{branch}")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<Branch>();

            return await result;
        }
    }
}
