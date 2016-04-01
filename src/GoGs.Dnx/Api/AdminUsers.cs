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

        public UserResponse CreateUser(UserCreateInfo createInfo)
        {
            var t = CreateUserAsync(createInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<UserResponse> CreateUserAsync(UserCreateInfo createInfo)
        {
            var result = ApiUrl
               .AppendPathSegment($"/admin/users")
               .WithHeader("Accept", "application/json")
               .WithHeader("Authorization", $"token {_client.AccessToken}")
               .PostJsonAsync(createInfo.GetRequestBody())
               .ReceiveJson<UserResponse>();

            return await result;
        }

        public UserResponse EditUser(string username, UserEditInfo editInfo)
        {
            var t = EditUserAsync(username, editInfo);
            t.Wait();
            return t.Result;
        }

        public async Task<UserResponse> EditUserAsync(string username, UserEditInfo editInfo)
        {
            var result = ApiUrl
              .AppendPathSegment($"/admin/users/{username}")
              .WithHeader("Accept", "application/json")
              .WithHeader("Authorization", $"token {_client.AccessToken}")
              .PatchJsonAsync(editInfo.GetRequestBody())
              .ReceiveJson<UserResponse>();

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
