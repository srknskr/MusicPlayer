using Autofac;
using MusicPlayer.Models;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using MusicPlayer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPlayer.ViewModel
{
    public class ArtistDetailsViewModel : BaseViewModel
    {
        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public ArtistDetailsViewModel(IProviderService providerService, IAccountService accountService, SevArtist selectedArtist)
        {
            _providerService = providerService;
            _accountService = accountService;

            this.selectedArtist = selectedArtist;
            Task.Run(GoToDetails);
        }
        private IList<Track> _track;
        public IList<Track> Track
        {
            get
            {
                if (_track == null)
                    _track = new ObservableCollection<Track>();
                return _track;
            }
            set
            {
                _track = value;
            }
        }

        public async Task GoToDetails()
        {
            var playlist = await _providerService.Get<TopTracks>($"https://api.spotify.com/v1/artists/{selectedArtist.id}/top-tracks?country=ES");
            foreach (var item in playlist.tracks)
            {
                Track.Add(item);
            }
        }
        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
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
        private Track selectedTrack;
        public Track SelectedTrack
        {
            get { return selectedTrack; }
            set
            {
                selectedTrack = value;
                OnPropertyChanged();
            }
        }

        

        public ICommand SelectionCommand => new Command(PlayMusic);

        private async void PlayMusic()
        {
            if (selectedTrack != null)
            {
                var viewModel = new PlayerViewModel(App._container.Resolve<IProviderService>(),
            App._container.Resolve<IAccountService>(), selectedTrack, Track);
                var playerPage = new PlayerPage { BindingContext = viewModel };

                //  var infoPage = new InfoPage();

                //var navigation = Application.Current.MainPage as NavigationPage;
                //navigation.PushAsync(playerPage, true);

                await Shell.Current.Navigation.PushAsync(playerPage);
                //Shell.Current.GoToAsync("//");

                //ShellNavigationState state = Shell.Current.CurrentState;
                //Shell.Current.GoToAsync(state);

            }
        }
    }
}
