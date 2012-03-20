using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Should;
using Shing;

namespace Shing.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Between_SourceDoesNotContainStart_ReturnsEmptyString()
        {
            "This is a test".Between( "cat", "test" ).ShouldEqual( "" );
        }

        [Fact]
        public void Between_SourceDoesNotContainEnd_ReturnsEmptyString()
        {
            "This is a test".Between( "This", "dog" ).ShouldEqual( "" );
        }

        [Fact]
        public void Between_SourceIsGood_ReturnsExpectedString()
        {
            "This is a test".Between( "This", "test" ).ShouldEqual( " is a " );
        }
    }
}
