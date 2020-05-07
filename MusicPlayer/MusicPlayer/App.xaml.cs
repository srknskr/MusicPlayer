
using MusicPlayer.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPlayer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            // MainPage =new AppShell();
            MainPage =  new AppShell();

        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
