using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Contracts
{
    public interface ICreator
    {
        IWishListItem Create(HtmlAgilityPack.HtmlNode item);
    }
}
