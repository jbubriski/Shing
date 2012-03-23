using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Parsers
{
    public abstract class ParserBase
    {
        protected const string _wishListItemRegex = "/dp/(.*?)/ref=wl_it_dp_";
        protected string _src;

        public void SetSource(string htmlResponse)
        {
            _src = htmlResponse;
        }
    }
}
