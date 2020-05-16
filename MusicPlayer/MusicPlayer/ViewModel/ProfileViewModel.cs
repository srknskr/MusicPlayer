using MusicPlayer.Models;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModel
{
    public class ProfileViewModel :BaseViewModel
    {
        private string userid = "jdhiu9bzgphap19lmuxbpxot1";

        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public ProfileViewModel(IProviderService providerService, IAccountService accountService)
        {
            _providerService = providerService;
            _accountService = accountService;

            Task.Run(GetProfile);
        }
        public async Task GetProfile()
        {
            await GetToken();
            var user = await _providerService.Get<User>($"https://api.spotify.com/v1/users/{userid}");
            UserList.Add(user);
        }
        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
        }

        private IList<User> _userList;
        public IList<User> UserList
        {
            get
            {
                if (_userList == null)
                    _userList = new ObservableCollection<User>();
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }
    }
}
