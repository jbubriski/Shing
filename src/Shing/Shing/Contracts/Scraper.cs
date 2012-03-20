using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Contracts
{
    public interface Scraper
    {
        IEnumerable<WishListItem> Scrape();
    }
}
