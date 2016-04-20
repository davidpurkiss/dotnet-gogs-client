using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Gogs.Model;

namespace Gogs.Api
{
    public class AdminUsers : ApiBase
    {
        public AdminUsers(GogsClient client) : base(client)
        {

        }

        public User CreateUser(UserCreateInfo createInfo)
        {
            var t = CreateUserAsync(createInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<User> CreateUserAsync(UserCreateInfo createInfo)
        {
            var result = ApiUrl
               .AppendPathSegment($"/admin/users")
               .WithHeader("Accept", "application/json")
               .WithHeader("Authorization", $"token {_client.AccessToken}")
               .PostJsonAsync(createInfo.GetRequestBody())
               .ReceiveJson<User>();

            return await result;
        }

        public User EditUser(string username, UserEditInfo editInfo)
        {
            var t = EditUserAsync(username, editInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<User> EditUserAsync(string username, UserEditInfo editInfo)
        {
            var result = ApiUrl
              .AppendPathSegment($"/admin/users/{username}")
              .WithHeader("Accept", "application/json")
              .WithHeader("Authorization", $"token {_client.AccessToken}")
              .PatchJsonAsync(editInfo.GetRequestBody())
              .ReceiveJson<User>();

            return await result;
        }

        public bool DeleteUser(string username)
        {
            var t = DeleteUserAsync(username);
            t.Wait();
            return t.Result;
        }

        public async Task<bool> DeleteUserAsync(string username)
        {
            var result = await ApiUrl
              .AppendPathSegment($"/admin/users/{username}")
              .WithHeader("Accept", "application/json")
              .WithHeader("Authorization", $"token {_client.AccessToken}")
              .DeleteAsync();

            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public void CreatePublicKey(string username, string title, string key)
        {
            throw new NotImplementedException();
        }
    }
}
