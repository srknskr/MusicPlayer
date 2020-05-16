using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class VideoThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
