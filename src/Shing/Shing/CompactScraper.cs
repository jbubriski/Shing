using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shing;
using Shing.Models;
using Shing.Proxies;

namespace WishlistScraper.Scraper
{
    public class CompactScraper : Shing.Contracts.Scraper
    {
        private const string WishListRegex = "/dp/(.*?)/";
        private WebClientProxy _client;

        public CompactScraper( WebClientProxy client = null )
        {
            _client = client ?? new WebClientProxy();
        }
         
        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shing.Contracts.WishListItem> Scrape( Uri endpoint )
        {
            var content = _client.DownloadString( endpoint );

            // trim out the shit we don't care about
            content = content.Between( "<table class=\"compact-items wlrdZeroTable\" id=\"compact-items\">",
                                        "</form>" );

            var matches = Regex.Matches( content, WishListRegex );
            var results = new List<Shing.Contracts.WishListItem>();
            foreach ( Match match in matches )
            {
                results.Add( new WishListItem
                {
                    ProductId = match.Groups[ 1 ].Value
                });
            }
            return results;
        }
    }
}
