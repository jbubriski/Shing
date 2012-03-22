using System;
using System.Linq;
using Moq;
using Shing.Proxies;
using Shing.Tests.Properties;
using Should;
using Xunit;
using Shing;

namespace WishlistScraper.Tests
{
    public class WishlistScraperTests
    {

        [Fact]
        public void Scrape_HtmlContains28Items_Returns28ItemsInCollection()
        {
            var client = new Mock<WebClientProxy>(MockBehavior.Strict);
            client.Setup(c => c.DownloadString(It.IsAny<Uri>()))
                .Returns(Resources.Full_25_items);

            var scraper = new WishListScraper(new Uri("http://www.google.com"), client.Object);
            var results = scraper.Scrape();

            results.ShouldNotBeEmpty();
            Assert.Equal(25, results.Count());
        }

        [Fact]
        public void Scrape_Url404s_ScrapeThrowsWebException()
        {
            var client = new Mock<WebClientProxy>(MockBehavior.Strict);
            client.Setup(c => c.DownloadString(It.IsAny<Uri>()))
                    .Throws<System.Net.WebException>();

            var scraper = new WishListScraper(new Uri("http://www.google.com"), client.Object);
            Assert.Throws<System.Net.WebException>(() => scraper.Scrape());
        }

        [Fact]
        public void Scrape_HtmlContainsNoMatchingProducts_ReturnsEmptyCollection()
        {
            var client = new Mock<WebClientProxy>(MockBehavior.Strict);
            client.Setup(c => c.DownloadString(It.IsAny<Uri>()))
                .Returns(Resources.Compact_No_Items);

            var scraper = new WishListScraper(new Uri("http://www.google.com"), client.Object);
            var results = scraper.Scrape();

            results.ShouldBeEmpty();
        }

        [Fact]
        public void Scrape_HtmlContains17Items_Returns17ItemsInCollection()
        {
            var client = new Mock<WebClientProxy>(MockBehavior.Strict);
            client.Setup(c => c.DownloadString(It.IsAny<Uri>()))
                .Returns(Resources.Compact_17_items);

            var scraper = new WishListScraper(new Uri("http://www.google.com"), client.Object);
            var results = scraper.Scrape();

            results.ShouldNotBeEmpty();
            Assert.Equal(17, results.Count());
        }
    }
}
