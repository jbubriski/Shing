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
        private const string _rawItemSplit = "class=\"itemWrapper\">";

        public string[] GetRawItems()
        {
            var results = _src.Split(new string[] { _rawItemSplit }, StringSplitOptions.None);
            return results.Skip(1).ToArray();
        }

        public ICreator GetCreator()
        {
            return new CompactCreator();
        }

        public void Dispose()
        {
            
        }
    }
}
