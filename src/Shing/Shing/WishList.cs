using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Contracts;
using Shing.Parsers;

namespace Shing
{
    public static class WishList
    {
        public static IEnumerable<IWishListItem> ScrapeUrl(Uri url)
        {
            var scraper = new WishListScraper(url);
            var source = scraper.Scrape();
            using(var parser = ParserFactory.GetParser(source))
            {
                var creator = parser.GetCreator();
                foreach(var rawItem in parser.GetRawItems())
                {
                    yield return creator.Create(rawItem);
                }
            }
        }
    }
}
