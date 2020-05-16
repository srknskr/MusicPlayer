using MusicPlayer.Models;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModel
{
    public class ArtistsViewModel : BaseViewModel
    {
        string id = "2yMN0IP20GOaN6q0p0zL5k";
        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public ArtistsViewModel(IProviderService providerService, IAccountService accountService)
        {
            _providerService = providerService;
            _accountService = accountService;

            Task.Run(GetArtists);
        }
        public async Task GetArtists()
        {
            await GetToken();
            var artists = await _providerService.Get<Artist>($"https://api.spotify.com/v1/artists/{id}");
            ArtistsList.Add(artists);
        }
        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
        }

        private IList<Artist> _artistsList;
        public IList<Artist> ArtistsList
        {
            get
            {
                if (_artistsList == null)
                    _artistsList = new ObservableCollection<Artist>();
                return _artistsList;
            }
            set
            {
                _artistsList = value;
            }
        }
       
        
    }
}
