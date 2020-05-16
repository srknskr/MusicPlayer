using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class ExternalUrls3
    {
        public string spotify { get; set; }
    }

    public class Followers
    {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class Image2
    {
        public object height { get; set; }
        public string url { get; set; }
        public object width { get; set; }
    }

    public class User
    {
        public string display_name { get; set; }
        public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public IList<Image2> images { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

}
