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
    public class Users : ApiBase
    {
        public Users(GogsClient client) : base(client)
        {
        }

        public IEnumerable<User> SearchUsers(string q, int? limit = null)
        {
            var t = SearchUsersAsync(q, limit);
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string q, int? limit = null)
        {
            var url = ApiUrl
                .AppendPathSegment($"/users/search")
                .SetQueryParam("q", q);

            if (limit != null)
                url = url.SetQueryParam("limit", limit);

            var result = url
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<User>>();

            return await result;
        }

        public User GetUser(string username)
        {
            var t = GetRepositoryAsync(username);
            t.Wait();
            return t.Result;
        }

        public async Task<User> GetRepositoryAsync(string username)
        {
            var result = ApiUrl
                .AppendPathSegment($"/users/{username}")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<User>();

            return await result;
        }

        public IEnumerable<AccessToken> ListAccessTokens(string username)
        {
            var t = ListAccessTokensAsync(username);
            t.Wait();
            return t.Result;
        }

        public async Task<IEnumerable<AccessToken>> ListAccessTokensAsync(string username)
        {
            var result = ApiUrl
                .AppendPathSegment($"/users/{username}/tokens")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .GetJsonAsync<IEnumerable<AccessToken>>();

            return await result;
        }

        public AccessToken CreateAccessToken(string username, AccessTokenCreateInfo createInfo)
        {
            var t = CreateAccessTokenAsync(username, createInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<AccessToken> CreateAccessTokenAsync(string username, AccessTokenCreateInfo createInfo)
        {
            var result = ApiUrl
                .AppendPathSegment($"/users/{username}/tokens")
                .WithHeader("Accept", "application/json")
                .WithHeader("Authorization", $"token {_client.AccessToken}")
                .PostJsonAsync(createInfo.GetRequestBody())
                .ReceiveJson<AccessToken>();

            return await result;
        }
    }
}
