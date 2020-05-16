using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
      //  [JsonProperty("expires_in")]
        public DateTime? Expires { get; set; }
        //[JsonProperty("token_type")]
        //public string TokenType { get; set; }
    }
}
