using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Shing.Scrapers;

namespace Shing
{
    public class WishlistScrapers
    {
        public static Shing.Contracts.Scraper For( Uri url )
        {
            var isCompact = url.OriginalString.IndexOf( "layout=compact" ) > -1;
            return isCompact ? new GenericScraper( url ) : new GenericScraper( url ) as Shing.Contracts.Scraper;
        }
    }
}
