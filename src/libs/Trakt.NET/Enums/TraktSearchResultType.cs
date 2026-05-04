namespace TraktNET
{
    /// <summary>Determines the type of an object in a search result.</summary>
    [TraktEnum(QueryName = "type", HasQuerySupport = true, HasPathSupport = true)]
    [Flags]
    public enum TraktSearchResultType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified = 0,

        /// <summary>The search result contains a movie.</summary>
        Movie = 1,

        /// <summary>The search result contains a show.</summary>
        Show = 2,

        /// <summary>The search result contains an episode.</summary>
        Episode = 4,

        /// <summary>The search result contains a person.</summary>
        Person = 8,

        /// <summary>The search result contains a list.</summary>
        List = 16
    }
}
