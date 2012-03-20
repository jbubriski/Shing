using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shing;
using Shing.Models;
using Shing.Proxies;

namespace Shing.Scrapers
{
    public class GenericScraper : ScraperBase, Shing.Contracts.Scraper
    {
        private WebClientProxy _client;
        private Uri _endpoint;

        public GenericScraper( Uri endpoint, WebClientProxy client = null )
        {
            _client = client ?? new WebClientProxy();
            _endpoint = endpoint;
        }
         
        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shing.Contracts.WishListItem> Scrape()
        {
            var content = _client.DownloadString( _endpoint );

            // trim out the stuff we don't care about
            //content = content.Between("wlrdZeroTable", "</form>");

            return GetItems( content );
        }
    }
}
