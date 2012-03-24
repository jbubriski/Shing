using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Contracts;
using Shing.Models;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace Shing.Creators
{
    public class DefaultCreator : ICreator
    {
        public IWishListItem Create(HtmlNode item)
        {
            return new WishListItem
            {
                ProductId = ExtractProductId(item),
                MoreInfoUrl = ExtractProductUrl(item),
                FriendlyName = ExtractFriendlyName(item),
                Price = ExtractPrice(item)
            };
        }

        private string ExtractProductId(HtmlNode input)
        {
            var href = ExtractProductUrl(input).OriginalString;
            var start = href.IndexOf("/dp/") + 4;
            var end = href.IndexOf("/", start);
            var result = href.Substring(start, end - start);
            return result;
        }

        private Uri ExtractProductUrl(HtmlNode input)
        {
            var href = input.QuerySelector(".productTitle a").Attributes["href"].Value;

            if(href.StartsWith("/"))
            {
                href = "http://amzn.com" + href;
            }
            return new Uri(href);
        }

        private decimal ExtractPrice(HtmlNode input)
        {
            var priceSpans = input.QuerySelectorAll(".wlPrice, .wlPriceBold, .price");
            foreach(var el in priceSpans)
            {
                // grab the first one that has text
                if(!String.IsNullOrWhiteSpace(el.InnerText))
                {
                    var price = el.InnerText.Trim().Replace("$", "");
                    return Convert.ToDecimal(price);
                }
            }
            return 0m;
        }

        private string ExtractFriendlyName(HtmlNode input)
        {
            return input.QuerySelector(".productTitle a").InnerText.Trim();
        }
    }
}
