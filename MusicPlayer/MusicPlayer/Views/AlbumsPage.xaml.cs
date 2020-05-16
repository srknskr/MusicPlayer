using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using MusicPlayer.ViewModel;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumsPage : ContentPage
    {
        public AlbumsPage()
        {
            InitializeComponent();
            this.BindingContext = new AlbumViewModel(App._container.Resolve<IProviderService>(),
            App._container.Resolve<IAccountService>());
        }
    }
}