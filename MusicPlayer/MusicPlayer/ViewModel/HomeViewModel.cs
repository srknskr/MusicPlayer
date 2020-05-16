using MusicPlayer.Models;
using MusicPlayer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPlayer.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

       
        public HomeViewModel()
        {
            musicList = GetMusics();
            recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        ObservableCollection<Song> musicList;
        public ObservableCollection<Song> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Song recentMusic;
        public Song RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Song selectedMusic;
        public Song SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);

        private async void PlayMusic()
        {
            //if (selectedMusic != null)
            //{
            //    var viewModel = new PlayerViewModel(selectedMusic, musicList);
            //    var playerPage = new PlayerPage { BindingContext = viewModel };

            //    var infoPage = new InfoPage();

            //    //var navigation = Application.Current.MainPage as NavigationPage;
            //    //navigation.PushAsync(playerPage, true);

            //    await Shell.Current.Navigation.PushAsync(playerPage);
            //    //Shell.Current.GoToAsync("//");

            //    //ShellNavigationState state = Shell.Current.CurrentState;
            //    //Shell.Current.GoToAsync(state);

            //}
        }




        public ObservableCollection<Song> GetMusics()
        {
            return new ObservableCollection<Song>
            {
                new Song { Title = "Beach Walk", Artist = "Unicorn Heads", Url = "https://devcrux.com/wp-content/uploads/Beach_Walk.mp3", AlbumImageUri = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRU6FVly4jMTD3AKB_sHxqPofJVQwqqUj5peEvgA1H4XegM3uJ7&usqp=CAU", IsRecent = true},
                new Song { Title = "I'll Follow You", Artist = "Density & Time", Url = "https://devcrux.com/wp-content/uploads/I_ll_Follow_You.mp3", AlbumImageUri = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRm-su97lHFGZrbR6BkgL32qbzZBj2f3gKGrFR0Pn66ih01SyGj&usqp=CAU"},
                new Song { Title = "Ancient", Artist = "Density & Time", Url = "https://devcrux.com/wp-content/uploads/Ancient.mp3"},
                new Song { Title = "News Room News", Artist = "Spence", Url = "https://devcrux.com/wp-content/uploads/Cats_Searching_for_the_Truth.mp3"},
                new Song { Title = "Bro Time", Artist = "Nat Keefe & BeatMowe", Url = "https://devcrux.com/wp-content/uploads/Bro_Time.mp3"},
                new Song { Title = "Cats Searching for the Truth", Artist = "Nat Keefe & Hot Buttered Rum", Url = "https://devcrux.com/wp-content/uploads/Cats_Searching_for_the_Truth.mp3"}
            };
        }

       
    }
}
