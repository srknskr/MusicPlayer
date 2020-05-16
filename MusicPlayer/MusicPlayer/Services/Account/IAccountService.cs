using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services.Account
{
    public interface IAccountService : IServiceBase
    {
        Task<AccessToken> GetAccessToken();
    }
}
