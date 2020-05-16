using MusicPlayer.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services.Provider
{
    public class ProviderService : HttpHelper, IProviderService
    {
        public async Task<T> Get<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url));
        }

        public Task<T> Post<T, K>(K request, string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
