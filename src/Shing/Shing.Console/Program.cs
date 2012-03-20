namespace WishlistScraper.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Shing;

    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                var amazonBaseShortLink = "http://amzn.com/";

                var wishlistUrl = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/";
                var wishlistUrlCompact = "http://www.amazon.com/gp/registry/wishlist/28B0NJ50RIV34/?layout=compact";

<<<<<<< HEAD
            var scraper = new WishListScraper(new Uri(wishlistUrl));
=======
                var scraper = new GenericScraper(new Uri(wishlistUrl));
>>>>>>> 0fcda79076a87c78c0894546db264298f2129c51

                var productIds = scraper.Scrape();

<<<<<<< HEAD
            Console.WriteLine();
            Console.WriteLine("Regular");
            Console.WriteLine();
            PrintResults(amazonBaseShortLink, productIds);

            scraper = new WishListScraper(new Uri(wishlistUrlCompact));
=======
                Console.WriteLine();
                Console.WriteLine("Regular");
                Console.WriteLine();
                PrintResults(amazonBaseShortLink, productIds);

                scraper = new GenericScraper(new Uri(wishlistUrlCompact));
>>>>>>> 0fcda79076a87c78c0894546db264298f2129c51

                productIds = scraper.Scrape();

<<<<<<< HEAD
            Console.WriteLine();
            Console.WriteLine("Compact");
            Console.WriteLine();
            PrintResults(amazonBaseShortLink, productIds);
=======
                Console.WriteLine();
                Console.WriteLine("Compact");
                Console.WriteLine();
                PrintResults(amazonBaseShortLink, productIds);
>>>>>>> 0fcda79076a87c78c0894546db264298f2129c51

                Console.WriteLine("Done. Press any key to run again, or 'x' to exit");
            } while (Console.ReadKey().KeyChar != 'x');
        }

<<<<<<< HEAD
        private static void PrintResults(string amazonBaseShortLink, IEnumerable<Shing.Contracts.IWishListItem> products)
        {
            foreach(var p in products)
            {
                Console.WriteLine(string.Format("{0}:\t{1}{0}", p.ProductId, amazonBaseShortLink));
=======
        private static void PrintResults(string amazonBaseShortLink, IEnumerable<Shing.Contracts.WishListItem> products)
        {
            var i = 0;

            foreach (var p in products)
            {
                Console.WriteLine(string.Format("{0}:\t{1}:\t{2}{1}", ++i, p.ProductId, amazonBaseShortLink));
>>>>>>> 0fcda79076a87c78c0894546db264298f2129c51
            }
        }
    }
}
