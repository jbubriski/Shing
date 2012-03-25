using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Models;
using System.Text.RegularExpressions;
using Shing.Proxies;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

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
            var url = _endpoint.GetLeftPart(UriPartial.Path) + "?items_per_page=300";
            var content = _client.DownloadString(new Uri(url));

            return content;
        }
    }
}
