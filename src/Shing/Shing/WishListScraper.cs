using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Models;
using System.Text.RegularExpressions;
using Shing.Proxies;

namespace Shing
{
    public class WishListScraper : Contracts.IScraper
    {
        private WebClientProxy _client;
        private Uri _endpoint;

        public WishListScraper( Uri endpoint, WebClientProxy client = null )
        {
            _client = client ?? new WebClientProxy();
            _endpoint = endpoint;
        }

        public string Scrape()
        {
            var content = _client.DownloadString( _endpoint );

            return content;
        }
    }
}
