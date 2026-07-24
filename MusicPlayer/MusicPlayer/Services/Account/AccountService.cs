using MusicPlayer.Helper;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MusicPlayer.Models;

namespace MusicPlayer.Services.Account
{
    public class AccountService : HttpHelper, IAccountService
    {
        public async Task<AccessToken> GetAccessToken()
        {
            Client.DefaultRequestHeaders.Authorization = GetHeader();
            var result = await Client.PostAsync(
                "https://accounts.spotify.com/api/token",
                new StringContent(
                    "grant_type=client_credentials",
                    Encoding.UTF8,
                    "application/x-www-form-urlencoded"));
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AccessToken>(response);
            GlobalSetting.Instance.token = token.Token;
            return token;
        }

        private static AuthenticationHeaderValue GetHeader()
        {
            var clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
            var clientSecret =
                Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");

            if (string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new InvalidOperationException(
                    "Set SPOTIFY_CLIENT_ID and SPOTIFY_CLIENT_SECRET outside source control.");
            }

            var credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
            return new AuthenticationHeaderValue("Basic", credentials);
        }
    }
}
