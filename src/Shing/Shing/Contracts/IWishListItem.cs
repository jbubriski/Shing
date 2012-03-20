using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Contracts
{
    public interface IWishListItem
    {
        string FriendlyName { get; }
        string ProductId { get; }
        decimal Price { get; }
        Uri MoreInfoUrl { get; }
    }
}
