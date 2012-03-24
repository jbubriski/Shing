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

                Console.WriteLine();
                Console.WriteLine("Regular");
                Console.WriteLine();

                var items = WishList.ScrapeUrl(new Uri(wishlistUrl));

                foreach(var item in items)
                {
                    Console.WriteLine(item.FriendlyName + " - " + item.Price.ToString("C"));
                }

                Console.WriteLine();
                Console.WriteLine("Compact");
                Console.WriteLine();

                items = WishList.ScrapeUrl(new Uri(wishlistUrlCompact));

                foreach(var item in items)
                {
                    Console.WriteLine(item.FriendlyName + " - " + item.Price.ToString("C"));
                }

                Console.WriteLine("Done. Press any key to run again, or 'x' to exit");
            } while (Console.ReadKey().KeyChar != 'x');
        }
    }
}
