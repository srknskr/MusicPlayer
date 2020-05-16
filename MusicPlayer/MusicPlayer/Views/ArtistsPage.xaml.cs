using Autofac;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using MusicPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPlayer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistsPage : ContentPage
    {
        public ArtistsPage()
        {
            InitializeComponent();
            this.BindingContext = new ArtistsViewModel(App._container.Resolve<IProviderService>(),
                       App._container.Resolve<IAccountService>());
        }
    }
}