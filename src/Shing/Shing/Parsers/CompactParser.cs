using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shing.Contracts;
using Shing.Creators;

namespace Shing.Parsers
{
    public class CompactParser : ParserBase, IParser
    {

        public ICreator GetCreator()
        {
            return new DefaultCreator();
        }

        public void Dispose()
        {
            
        }
    }
}
