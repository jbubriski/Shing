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
        string _regex = "/dp/(.*?)/";

        /// <summary>
        /// Returns a list of product ID's
        /// </summary>
        /// <returns></returns>
        public List<string> Scrape(string urlToScrape)
        {
            var webClient = new WebClient();

            var content = webClient.DownloadString(urlToScrape);

            var matches = Regex.Matches(content, _regex);

            var productIds = new List<string>();

            foreach (Match match in matches)
            {
                productIds.Add(match.Groups[1].Value);
            }

            return productIds;
        }
    }
}
