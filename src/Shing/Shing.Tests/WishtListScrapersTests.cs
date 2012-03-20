using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Should;
using Should.Fluent;

using Xunit;
using Shing.Scrapers;

namespace Shing.Tests
{
    public class WishtListScrapersTests
    {
        private const string Full_WishList_Url = "http://www.amazon.com/gp/registry/wishlist/ref=wish_list";
        private const string Compact_WishList_Url = "http://www.amazon.com/gp/registry/wishlist/ref=wish_list?layout=compact";

        [Fact]
        public void WishListScrapers_GivenFullURL_ReturnsFullScraper()
        {
            var scraper = WishlistScrapers.For( new Uri(Full_WishList_Url) );

            scraper.ShouldBeType<FullScraper>();
        }

        [Fact]
        public void WishListScrapers_GivenCompactURL_ReturnsFullScraper()
        {
            var scraper = WishlistScrapers.For( new Uri( Compact_WishList_Url ) );

            scraper.ShouldBeType<CompactScraper>();
        }
    }
}
