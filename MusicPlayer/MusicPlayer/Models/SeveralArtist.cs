using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class SeveralArtist
    {
        public IList<SevArtist> artists { get; set; }
    }
    public class SeveralExternalUrls
    {
        public string spotify { get; set; }
    }

    public class SeveralFollowers
    {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class SeveralImage
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class SevArtist
    {
        public ExternalUrls external_urls { get; set; }
        public SeveralFollowers followers { get; set; }
        public IList<string> genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public IList<SeveralImage> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

}
