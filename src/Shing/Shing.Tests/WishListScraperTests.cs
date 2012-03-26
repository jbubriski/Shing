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
        public void Scrape_HtmlContains28Items_ReturnsResponseFromWebRequest()
        {
            var client = new Mock<WebClientProxy>(MockBehavior.Strict);
            client.Setup(c => c.DownloadString(It.IsAny<Uri>()))
                .Returns(Resources.Full_25_items);

            var scraper = new WishListScraper(new Uri("http://www.google.com"), client.Object);
            var results = scraper.Scrape();

            results.ShouldNotBeEmpty();
            results.ShouldEqual(Resources.Full_25_items);
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
    }
}
