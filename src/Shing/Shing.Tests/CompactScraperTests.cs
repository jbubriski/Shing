﻿using System;
using System.Linq;
using Moq;
using Shing.Proxies;
using Shing.Tests.Properties;
using Should;
using WishlistScraper.Scraper;
using Xunit;

namespace WishlistScraper.Tests
{
    public class CompactScraperTests
    {

        [Fact]
        public void Scrape_Url404s_ScrapeThrowsWebException()
        {
            var client = new Mock<WebClientProxy>( MockBehavior.Strict );
            client.Setup( c => c.DownloadString( It.IsAny<Uri>() ) )
                    .Throws<System.Net.WebException>();

            var scraper = new CompactScraper( client.Object );
            Assert.Throws<System.Net.WebException>( () => scraper.Scrape( new Uri("http://www.google.com") ) );
        }

        [Fact]
        public void Scrape_HtmlContainsNoMatchingProducts_ReturnsEmptyCollection()
        {
            var client = new Mock<WebClientProxy>( MockBehavior.Strict );
            client.Setup( c => c.DownloadString( It.IsAny<Uri>() ) )
                .Returns( Resources.Compact_No_Items );

            var scraper = new CompactScraper( client.Object );
            var results = scraper.Scrape( new Uri( "http://www.google.com" ) );

            results.ShouldBeEmpty();
        }

        [Fact]
        public void Scrape_HtmlContains17Items_Returns17ItemsInCollection()
        {
            var client = new Mock<WebClientProxy>( MockBehavior.Strict );
            client.Setup( c => c.DownloadString( It.IsAny<Uri>() ) )
                .Returns( Resources.Compact_17_items );

            var scraper = new CompactScraper( client.Object );
            var results = scraper.Scrape( new Uri( "http://www.google.com" ) );

            results.ShouldNotBeEmpty();
            Assert.Equal( 17, results.Count() );
        }
    }
}
