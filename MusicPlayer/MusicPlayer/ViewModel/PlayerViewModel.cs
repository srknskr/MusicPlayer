using MediaManager;
using MusicPlayer.Models;
using MusicPlayer.Services.Account;
using MusicPlayer.Services.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MusicPlayer.ViewModel
{

    public class PlayerViewModel : BaseViewModel
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
        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public PlayerViewModel(IProviderService providerService, IAccountService accountService, Track selectedTrack, IList<Track> Track)
        {
            _providerService = providerService;
            _accountService = accountService;

            this.selectedTrack = selectedTrack;
            this.Track = Track;
            // Task.Run(GetTrack);
            PlayMusic(selectedTrack);
            isPlaying = true;
        }

        public async Task GetTrack()
        {
            var tracks = await _providerService.Get<Track>($"https://api.spotify.com/v1/tracks/{selectedTrack.Id}");

            selectedTrack = tracks;
            //   Track.Add(tracks);


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

        #region Properties
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

        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan position;
        public TimeSpan Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        double maximum = 100f;
        public double Maximum
        {
            get { return maximum; }
            set
            {
                if (value > 0)
                {
                    maximum = value;
                    OnPropertyChanged();
                }
            }
        }



        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayIcon));
            }
        }

        public string PlayIcon { get => isPlaying ? "pause.png" : "play.png"; }

        private bool isMute;
        public bool IsMute
        {
            get { return isMute; }
            set
            {
                isMute = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MuteIcon));
            }
        }

        public string MuteIcon { get => isMute ? "mute.png" : "volume.png"; }

        #endregion

        public ICommand PlayCommand => new Command(Play);
        public ICommand ChangeCommand => new Command(ChangeMusic);
        //public ICommand BackCommand => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
        public ICommand MuteCommand => new Command(Mute);
        public ICommand ShareCommand => new Command(() => Share.RequestAsync(selectedTrack.PreviewUrl));


        private async void Play()
        {
            if (isPlaying)
            {
                await CrossMediaManager.Current.Pause();
                IsPlaying = false; ;
            }
            else
            {
                await CrossMediaManager.Current.Play();
                IsPlaying = true; ;
            }
        }
        private  void Mute()
        {
            if (isMute)
            {
                CrossMediaManager.Current.Volume.Muted = false;
                IsMute = false; ;
            }
            else
            {
                CrossMediaManager.Current.Volume.Muted = true;
                IsMute = true; ;
            }
        }

        private void ChangeMusic(object obj)
        {
            if ((string)obj == "P")
                PreviousMusic();
            else if ((string)obj == "N")
                NextMusic();
        }

        private async void PlayMusic(Track music)
        {
            var mediaInfo = CrossMediaManager.Current;
            await mediaInfo.Play(music?.PreviewUrl);
            IsPlaying = true;

            mediaInfo.MediaItemFinished += (sender, args) =>
            {
                IsPlaying = false;
                NextMusic();
            };

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Duration = mediaInfo.Duration;
                Maximum = duration.TotalSeconds;
                Position = mediaInfo.Position;
                return true;
            });
        }

        private void NextMusic()
        {
            var currentIndex = Track.IndexOf(selectedTrack);

            if (currentIndex < Track.Count - 1)
            {
                SelectedTrack = Track[currentIndex + 1];
                PlayMusic(selectedTrack);
            }
        }

        private void PreviousMusic()
        {
            var currentIndex = Track.IndexOf(selectedTrack);

            if (currentIndex > 0)
            {
                SelectedTrack = Track[currentIndex - 1];
                PlayMusic(selectedTrack);
            }
        }
    }
}


