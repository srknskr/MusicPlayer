using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class Artist
    {
        //public string Name { get; set; }

        //public string Biography { get; set; }

        //public string Tags { get; set; }

        //public string Genre { get; set; }

        //public object Image { get; set; }

        //public string ImageUri { get; set; }

        //public object Rating { get; set; }

        //public IList<Album> Albums { get; set; }

        //public IList<Song> TopTracks { get; set; }

        //public IList<Song> AllTracks { get; }


        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }
        [JsonProperty("followers")]
        public Followers2 Followers { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
    public class ArtistList
    {
        public IList<Artist> artists { get; set; }
    }
    public class ExternalUrls
    {
        public string spotify { get; set; }
    }

    public class Followers2
    {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class Image3
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }
}
