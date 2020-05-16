using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MusicPlayer.Helper
{
    public class HttpHelper
    {
        private static HttpClient _client;
        protected static HttpClient Client
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient();

                if (!String.IsNullOrEmpty(GlobalSetting.Instance.token))
                {
                    _client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", GlobalSetting.Instance.token);
                }

                return _client;
            }
        }
    }
}
