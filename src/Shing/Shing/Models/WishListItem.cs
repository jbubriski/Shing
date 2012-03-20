using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Models
{
    public class WishListItem : Contracts.IWishListItem
    {
        public string FriendlyName
        {
            get;
            set;
        }

        public string ProductId
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public Uri MoreInfoUrl
        {
            get;
            set;
        }
    }
}
