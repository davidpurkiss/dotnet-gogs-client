using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Gogs.Api;

namespace Gogs
{
    public class GogsClient
    {
        public string AccessToken { get; internal set; }
        public string BaseUrl { get; internal set; }

        #region Apis

        public AdminRepos AdminRepos { get; private set; }

        #endregion

        public GogsClient(string baseUrl)
        {
            this.BaseUrl = baseUrl;

            AdminRepos = new AdminRepos(this);
        }

        public string ApiUrl
        {
            get
            {
                return $"{BaseUrl}/api/v1";
            }
        }

        public string Authenticate(string username, string password)
        {
            var t = AuthenticateAsync(username, password);
            t.Wait();
            return t.Result;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            string token = null;

            try
            {
                dynamic response = await ApiUrl
                .AppendPathSegment($"/users/{username}/tokens")
                .WithHeader("Accept", "application/json")
                .WithBasicAuth(username, password)
                .PostJsonAsync(new { name = username }).ReceiveJson();

                token = response.sha1;
                this.AccessToken = token;
                return token;
            }
            catch (FlurlHttpException ex)
            {
                return null;
            }

        }
    }
}
