using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Models;
using System.Text.RegularExpressions;

namespace Shing.Scrapers
{
    public abstract class ScraperBase
    {
        private const string WishListRegex = "/dp/(.*?)/ref=wl_it_dp_";

        public virtual IEnumerable<Shing.Contracts.WishListItem> GetItems( string responseHtml )
        {
            var matches = Regex.Matches( responseHtml, WishListRegex );
            var results = new List<Shing.Contracts.WishListItem>();
            var uniqueMatches = matches.Cast<Match>().Select( m => m.Groups[ 1 ].Value ).Distinct();
            foreach ( var match in uniqueMatches )
            {
                yield return new WishListItem { ProductId = match };
            }
        }
    }
}
