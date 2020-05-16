using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services.Provider
{
    public interface IProviderService : IServiceBase
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T, K>(K request, string url);
    }
}
