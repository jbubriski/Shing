using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Should;
using Should.Fluent;
using Shing.Parsers;
using Shing.Creators;
using Shing.Tests.Properties;

namespace Shing.Tests.Parsers
{
    public class CompactParserTests
    {

        [Fact]
        public void GetRawItems_GivenSourceHas17_Returns17Items()
        {
            var parser = new CompactParser();
            parser.SetSource(Resources.Compact_17_items);
            var items = parser.GetRawItems();
            items.Count().ShouldEqual(17);
        }

        [Fact]
        public void GetCreator_ReturnsCompactCreator()
        {
            var parser = new CompactParser();
            var creator = parser.GetCreator();

            creator.ShouldBeType<DefaultCreator>();
        }
    }
}
