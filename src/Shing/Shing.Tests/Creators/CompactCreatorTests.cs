using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Tests.Properties;
using Shing.Parsers;
using Should;
using Should.Fluent;
using Xunit;
using Shing.Contracts;

namespace Shing.Tests.Creators
{
    public class CompactCreatorTests
    {
        private IParser _parser;
        public CompactCreatorTests()
        {
            _parser = new CompactParser();
            _parser.SetSource(Resources.Compact_17_items);
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectPrice()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.Price.ShouldEqual(31.35m);
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectTitle()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.FriendlyName.ShouldEqual("Dependency Injection in .NET");
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectMoreInfoUrl()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.MoreInfoUrl.OriginalString.ShouldEqual("http://www.amazon.com/Dependency-Injection-NET-Mark-Seemann/dp/1935182501/ref=wl_it_dp_o_npd?ie=UTF8&coliid=ILBDGEAVM59LC&colid=28B0NJ50RIV34");
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectProductId()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.ProductId.ShouldEqual("1935182501");
        }
    }
}
