using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Shing.Models;

namespace WishlistScraper.Scraper
{
    public class CompactScraper : Shing.Contracts.Scraper
    {
        private const string WishListRegex = "/dp/(.*?)/";

        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shing.Contracts.WishListItem> Scrape( Uri endpoint )
        {
            using ( var webClient = new WebClient() )
            {
                var content = webClient.DownloadString( endpoint );

                var matches = Regex.Matches( content, WishListRegex );

                foreach ( Match match in matches )
                {
                    yield return new WishListItem
                    {
                        ProductId = match.Groups[ 1 ].Value
                    };
                }
            }
        }
    }
}
