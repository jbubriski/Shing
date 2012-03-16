﻿namespace WishlistScraper.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WishlistScraper.Scraper;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var amazonBaseShortLink = "http://amzn.com/";

            var wishlistUrl = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/";
            var wishlistUrlCompact = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/?layout=compact";

            var scraper = new CompactScraper();

            var productIds = scraper.Scrape(wishlistUrlCompact);

            foreach (var productId in productIds)
            {
                Console.WriteLine(string.Format("{0}:\t{1}{0}", productId, amazonBaseShortLink));
            }

            Console.ReadKey();
        }
    }
}
