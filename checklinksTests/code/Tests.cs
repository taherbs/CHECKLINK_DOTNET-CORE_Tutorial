using System;
using System.Linq;
using Xunit;
using checklinksconsole;

namespace checklinksTests
{
    public class Tests
    {
        [Fact]
        public void WithoutHTTPAtTheStartOfTheLink_NoLinks()
        {
            var links = LinkChecker.GetLinks("<a href=\"google.com\" />");
            Assert.Equal(links.Count(),0);
        }

        [Fact]
        public void WithHTTPAtTheStartOfTheLink_LinkParses()
        {
            var links = LinkChecker.GetLinks("<a href=\"http://google.com\" />");
            Assert.Equal(links.Count(),1);
            Assert.Equal(links.First(), "http://google.com");
        }
    }
}
