using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Contracts;

namespace Shing.Parsers
{
    public abstract class ParserFactory
    {
        public static IParser GetParser(string htmlResponse)
        {
            var isCompactSource = htmlResponse.IndexOf("<table class=\"compact-items wlrdZeroTable\" id=\"compact-items\">") > -1;
            IParser parser = null;

            if(isCompactSource)
                parser = new CompactParser();
            else
                parser = new FullParser();
            
            parser.SetSource(htmlResponse);
            return parser;
        }
    }
}
