using System;

namespace MusicPlayer.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public string AlbumImageUri { get; set; } = "https://usercontent2.hubstatic.com/14548043_f1024.jpg";
        public object Image { get; set; }
        public string ImageUri { get; set; }
        public bool IsRecent { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }





    }
}

