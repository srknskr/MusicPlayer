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
    public class AlbumDetailsViewModel : BaseViewModel
    {

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

        private Item selectedAlbum;
        public Item SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                selectedAlbum = value;
                OnPropertyChanged();
            }
        }
        private IList<PlaylistTrack> _playlisttrack;
        public IList<PlaylistTrack> PlaylistTrack
        {
            get
            {
                if (_playlisttrack == null)
                    _playlisttrack = new ObservableCollection<PlaylistTrack>();
                return _playlisttrack;
            }
            set
            {
                _playlisttrack = value;
            }
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
        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public AlbumDetailsViewModel(IProviderService providerService, IAccountService accountService, Item selectedAlbum)
        {
            _providerService = providerService;
            _accountService = accountService;

            this.selectedAlbum = selectedAlbum;
            Task.Run(GoToDetails);
        }
        public async Task GoToDetails()
        {
            string a = "";
            var playlist = await _providerService.Get<Playlist>($"https://api.spotify.com/v1/playlists/{selectedAlbum.id}/tracks");
            foreach (var item in playlist.Items)
            {
                Track.Add(item.Track);
               
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
