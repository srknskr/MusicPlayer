using Autofac;
using MusicPlayer.Models;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using MusicPlayer.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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
        //public async Task GetArtists()
        //{
        //    await GetToken();
        //    var artists = await _providerService.Get<Artist>($"https://api.spotify.com/v1/artists/{id}");
        //    ArtistsList.Add(artists);
        //}
        public async Task GetArtists()
        {
            await GetToken();
            var artists = await _providerService.Get<SeveralArtist>($"https://api.spotify.com/v1/artists?ids=4li4dx5mFgZlMVeHlARBHP%2C2yMN0IP20GOaN6q0p0zL5k%2C0oSGxfWSnnOXhD2fKuz2Gy%2C3dBVyJ7JuOMt4GE9607Qin");
            foreach (var item in artists.artists)
                ArtistsList.Add(item);
            
        }
        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
        }

        private IList<SevArtist> _artistsList;
        public IList<SevArtist> ArtistsList
        {
            get
            {
                if (_artistsList == null)
                    _artistsList = new ObservableCollection<SevArtist>();
                return _artistsList;
            }
            set
            {
                _artistsList = value;
            }
        }
        private SevArtist selectedArtist;
        public SevArtist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                selectedArtist = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(GoToArtistsDetailsAsync);

        private async void GoToArtistsDetailsAsync(object obj)
        {
            if (selectedArtist != null)
            {
                var viewModel = new ArtistDetailsViewModel(App._container.Resolve<IProviderService>(),
            App._container.Resolve<IAccountService>(), selectedArtist);
                var albumDetaisPage = new ArtistDetailsPage { BindingContext = viewModel };

                await Shell.Current.Navigation.PushAsync(albumDetaisPage);
            }
        }

    }
}
