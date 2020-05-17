using MusicPlayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class ExternalUrls55
    {
        public string spotify { get; set; }
    }

    public class Artist55
    {
        public ExternalUrls55 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Image55
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Album55
    {
        public string album_type { get; set; }
        public IList<Artist55> artists { get; set; }
        public ExternalUrls55 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public IList<Image55> images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    //public class Artist55
    //{
    //    public ExternalUrls55 external_urls { get; set; }
    //public string href { get; set; }
    //public string id { get; set; }
    //public string name { get; set; }
    //public string type { get; set; }
    //public string uri { get; set; }
    //    }

    public class ExternalIds55
    {
        public string isrc { get; set; }
    }

    public class Track55
    {
        public Album55 album { get; set; }
        public IList<Artist55> artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }
        public ExternalIds55 external_ids { get; set; }

        public ExternalUrls55 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TopTracks
    {
        public IList<Track> tracks { get; set; }
    }
}



