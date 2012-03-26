using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shing.Contracts
{
    public interface IParser : IDisposable
    {
        IEnumerable<HtmlAgilityPack.HtmlNode> GetRawItems();
        ICreator GetCreator();
        void SetSource(string htmlResponse);
    }
}
