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
            return source.Substring( startPos, endPos - startPos );
        }
    }
}
