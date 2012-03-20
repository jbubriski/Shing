using System;
using System.Net;

namespace Shing.Proxies
{
    public class WebClientProxy
    {
        private WebClient _client;

        public WebClientProxy()
        {
            _client = new WebClient();
        }

        public virtual string DownloadString( Uri address )
        {
            return _client.DownloadString( address );
        }

        public virtual string DownloadString( string address )
        {
            return DownloadString( new Uri( address ) );
        }
    }
}
