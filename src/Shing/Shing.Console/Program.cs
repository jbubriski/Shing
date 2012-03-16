namespace WishlistScraper.Console
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

            var productIds = scraper.Scrape(wishlistUrl);

            Console.WriteLine();
            Console.WriteLine("Regular");
            Console.WriteLine();
            PrintResults(amazonBaseShortLink, productIds);

            productIds = scraper.Scrape(wishlistUrlCompact);

            Console.WriteLine();
            Console.WriteLine("Compact");
            Console.WriteLine();
            PrintResults(amazonBaseShortLink, productIds);

            Console.ReadKey();
        }

        private static void PrintResults(string amazonBaseShortLink, List<string> productIds)
        {
            foreach (var productId in productIds)
            {
                Console.WriteLine(string.Format("{0}:\t{1}{0}", productId, amazonBaseShortLink));
            }
        }
    }
}
