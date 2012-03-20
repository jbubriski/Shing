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
        private const string _wishListItemRegex = "/dp/(.*?)/ref=wl_it_dp_";

        private WebClientProxy _client;
        private Uri _endpoint;

        public WishListScraper( Uri endpoint, WebClientProxy client = null )
        {
            _client = client ?? new WebClientProxy();
            _endpoint = endpoint;
        }
         
        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Shing.Contracts.IWishListItem> Scrape()
        {
            var content = _client.DownloadString( _endpoint );

            return GetItems( content );
        }

        private IEnumerable<Shing.Contracts.IWishListItem> GetItems(string responseHtml)
        {
            var matches = Regex.Matches(responseHtml, _wishListItemRegex);
            var results = new List<Shing.Contracts.IWishListItem>();
            var uniqueMatches = matches.Cast<Match>().Select(m => m.Groups[1].Value).Distinct();
            foreach(var match in uniqueMatches)
            {
                yield return new WishListItem { ProductId = match };
            }
        }
    }
}
