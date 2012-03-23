using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Contracts;
using Shing.Models;

namespace Shing.Creators
{
    public class CompactCreator : ICreator
    {
        public IWishListItem Create(string html)
        {
            var split = html.Split(new string[] { "<tr" }, StringSplitOptions.None);
            if(split.Count() > 2)
            {
                // first item, grab the second TR
                // the first TR is the header row
                html = split[2];
            }
            var properties = html.Split(new string[] { "<td" }, StringSplitOptions.None);
            return new WishListItem
            {
                ProductId = ExtractProductId(properties[2]),
                MoreInfoUrl = ExtractProductUrl(properties[2]),
                FriendlyName = ExtractFriendlyName(properties[2]),
                Price = ExtractPrice(properties[4])
            };
        }

        private string ExtractProductId(string input)
        {
            var start = input.IndexOf("/dp/", input.IndexOf("<a")) + 4;
            var end = input.IndexOf("/", start);
            var result = input.Substring(start, end - start);
            return result;
        }

        private Uri ExtractProductUrl(string input)
        {
            var start = input.IndexOf("href=\"", input.IndexOf("<a")) + 6;
            var end = input.IndexOf("\"", start);
            var result = input.Substring(start, end - start);
            return new Uri(result);
        }

        private decimal ExtractPrice(string input)
        {
            var start = input.IndexOf("$", input.IndexOf("<span")) + 1;
            var end = input.IndexOf(".", start) + 3;
            var result = input.Substring(start, end - start);
            return Convert.ToDecimal(result.Trim());
        }

        private string ExtractFriendlyName(string input)
        {
            var start = input.IndexOf(">", input.IndexOf("<a")) + 1;
            var end = input.IndexOf("</a", start);
            var result = input.Substring(start, end - start);
            return result.Trim();
        }
    }
}
