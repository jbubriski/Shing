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
    public class FullCreatorTests
    {
        private IParser _parser;
        public FullCreatorTests()
        {
            _parser = new FullParser();
            _parser.SetSource(Resources.Full_25_items);
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectPrice()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.Price.ShouldEqual(15.60m);
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectTitle()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.FriendlyName.ShouldEqual("Defending Jacob: A Novel");
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectMoreInfoUrl()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.MoreInfoUrl.OriginalString.ShouldEqual("http://www.amazon.com/Defending-Jacob-Novel-William-Landay/dp/0385344228/ref=wl_it_dp_v/186-1571468-1782915?ie=UTF8&coliid=ILUKZM2I137XH&colid=3ON5W8HBTKUOI");
        }

        [Fact]
        public void Create_GivenProperHTML_ReturnsWishListItemWithCorrectProductId()
        {
            var items = _parser.GetRawItems();

            var item = _parser.GetCreator().Create(items.First());

            item.ProductId.ShouldEqual("0385344228");
        }
    }
}
