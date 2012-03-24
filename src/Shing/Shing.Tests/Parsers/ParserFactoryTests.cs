using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Shing.Tests.Properties;
using Shing.Parsers;
using Should;
using Should.Fluent;

namespace Shing.Tests.Parsers
{
    public class ParserFactoryTests
    {
        [Fact]
        public void GetParser_GivenSourceForCompact_ReturnsCompactParser()
        {
            var source = Resources.Compact_17_items;
            var parser = ParserFactory.GetParser(source);

            parser.ShouldBeType<CompactParser>();
        }

        [Fact]
        public void GetParser_GivenSourceForFull_ReturnsFullParser()
        {
            var source = Resources.Full_25_items;
            var parser = ParserFactory.GetParser(source);

            parser.ShouldBeType<FullParser>();
        }
    }
}
