using Acr.UserDialogs;
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

    public class AlbumViewModel : BaseViewModel
    {
        private string username = "jdhiu9bzgphap19lmuxbpxot1";


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
        private IList<Item> _items;
        public IList<Item> Items
        {
            get
            {
                if (_items == null)
                    _items = new ObservableCollection<Item>();
                return _items;
            }
            set
            {
                _items = value;
            }
        }


        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public AlbumViewModel(IProviderService providerService,
            IAccountService accountService)
        {
            _providerService = providerService;
            _accountService = accountService;

            Task.Run(GetAlbums);
        }

        public async Task GetAlbums()
        {
            await GetToken();
            var albums = await _providerService.Get<Album>($"https://api.spotify.com/v1/users/{username}/playlists");
            foreach (var item in albums.items)
                Items.Add(item);
        }

        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
        }
        public ICommand SelectionCommand => new Command(GoToAlbumAsync);

        public ICommand BackCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync());

        private async void GoToAlbumAsync(object obj)
        {
            if (selectedAlbum != null)
            {
                var viewModel = new AlbumDetailsViewModel(App._container.Resolve<IProviderService>(),
            App._container.Resolve<IAccountService>(),selectedAlbum);
                var albumDetaisPage = new AlbumDetailsPage { BindingContext = viewModel };

                await Shell.Current.Navigation.PushAsync(albumDetaisPage);
            }
        }
        
        public ICommand SelectCommand => new Command(async (o) =>
        {
            if (o != null && o is Item playlist)
            {
                var tracks = await _providerService.Get<Playlist>($"https://api.spotify.com/v1/playlists/{playlist.id}/tracks");
                string trackNames = "";
                foreach (var item in tracks.Items)
                    PlaylistTrack.Add(item);
               //     trackNames += item.Track.Name + "\n";

                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = trackNames,
                    Title = "Tracks",
                    OkText = "Ok"
                });

            }
        });
    }
}
