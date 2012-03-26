using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace Shing.Parsers
{
    public abstract class ParserBase
    {
        protected const string _wishListItemRegex = "/dp/(.*?)/ref=wl_it_dp_";
        private const string _rawItemSplit = "class=\"itemWrapper\">";
        protected string _src;
        protected HtmlDocument _dom;

        public void SetSource(string htmlResponse)
        {
            _src = htmlResponse;
            _dom = new HtmlDocument();
            _dom.LoadHtml(_src);
        } 

        public IEnumerable<HtmlNode> GetRawItems()
        {
            var matches = _dom.DocumentNode.QuerySelectorAll("tbody[name].itemWrapper");
            return matches.Where( n => {
                return n.QuerySelectorAll(".wlPrice, .wlPriceBold, .price")
                        .Any( match => !String.IsNullOrWhiteSpace( match.InnerText ));
            });
        }
    }
}
