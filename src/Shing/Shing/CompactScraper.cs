using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WishlistScraper.Scraper
{
    public class CompactScraper
    {
        private const string WishListRegex = "/dp/(.*?)/";

        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Scrape(string urlToScrape)
        {
            var content = new WebClient().DownloadString(urlToScrape);

            var matches = Regex.Matches(content, WishListRegex);

            foreach (Match match in matches)
            {
                yield return match.Groups[1].Value;
            }
        }
    }
}
