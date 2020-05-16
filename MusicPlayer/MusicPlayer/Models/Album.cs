using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class Album
    {
        //public string Title { get; set; }

        //public string Description { get; set; }
        //public string Artist { get; set; }
        //public string Tags { get; set; }

        //public string Genre { get; set; }

        //public object Image { get; set; }

        //public string ImageUri { get; set; }

        //public object Rating { get; set; }

        //public DateTime ReleaseDate { get; set; }

        //public TimeSpan Duration { get; set; }

        //public string LabelName { get; set; }

        //public IList<Artist> Artists { get; set; }

        //public IList<Song> SongList { get; set; }

        public bool IsRecent { get; set; }
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class ExternalUrls4
    {
        public string spotify { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class ExternalUrls2
    {
        public string spotify { get; set; }
    }

    public class Owner
    {
        public string display_name { get; set; }
        public ExternalUrls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Tracks
    {
        public string href { get; set; }
        public int total { get; set; }
    }

    public class Item
    {
        public bool collaborative { get; set; }
        public string description { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public object primary_color { get; set; }
        public bool @public { get; set; }
        public string snapshot_id { get; set; }
        public Tracks tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
}
