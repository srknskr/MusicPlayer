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
            var result = await Client.PostAsync("https://accounts.spotify.com/api/token",
                new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded"));
            var response = await result.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AccessToken>(response);
            GlobalSetting.Instance.token = token.Token;
            return token;

        }
    
      

        private AuthenticationHeaderValue GetHeader()
        {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "df54bb6560c04ed5bfb254b95e1637f3", "192be3fa0bbc4774a4e37f43a70e2156")))
            );
        }
    }
}
