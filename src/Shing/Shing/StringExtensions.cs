namespace Shing
{
    public static class StringExtensions
    {
        public static string Between( this string source, string start, string end )
        {
            var startPos = source.IndexOf( start );
            if ( startPos == -1 )
            {
                return string.Empty;
            }
            var endPos = source.IndexOf( end, startPos );
            return endPos == -1 ? string.Empty : source.Substring( startPos + start.Length, endPos - startPos - end.Length );
        }
    }
}
