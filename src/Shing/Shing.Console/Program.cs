namespace WishlistScraper.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Shing.Scrapers;

    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                var amazonBaseShortLink = "http://amzn.com/";

                var wishlistUrl = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/";
                var wishlistUrlCompact = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/?layout=compact";

                var scraper = new GenericScraper(new Uri(wishlistUrl));

                var productIds = scraper.Scrape();

                Console.WriteLine();
                Console.WriteLine("Regular");
                Console.WriteLine();
                PrintResults(amazonBaseShortLink, productIds);

                scraper = new GenericScraper(new Uri(wishlistUrlCompact));

                productIds = scraper.Scrape();

                Console.WriteLine();
                Console.WriteLine("Compact");
                Console.WriteLine();
                PrintResults(amazonBaseShortLink, productIds);

                Console.WriteLine("Done. Press any key to run again, or 'x' to exit");
            } while (Console.ReadKey().KeyChar != 'x');
        }

        private static void PrintResults(string amazonBaseShortLink, IEnumerable<Shing.Contracts.WishListItem> products)
        {
            var i = 0;

            foreach (var p in products)
            {
                Console.WriteLine(string.Format("{0}:\t{1}:\t{2}{1}", ++i, p.ProductId, amazonBaseShortLink));
            }
        }
    }
}
