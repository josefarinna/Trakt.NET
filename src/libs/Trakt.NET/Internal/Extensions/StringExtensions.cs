namespace TraktNET
{
    internal static class StringExtensions
    {
        private static readonly char[] s_delimiterChars = { ' ', ',', '.', ':', ';', '\n', '\t' };

        internal static int WordCount(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            string[] words = value.Split(s_delimiterChars);
            IEnumerable<string> filteredWords = words.Where(s => !string.IsNullOrEmpty(s));
            return filteredWords.Count();
        }

        internal static bool ContainsSpace(this string value) => value.Contains(' ');
    }
}
