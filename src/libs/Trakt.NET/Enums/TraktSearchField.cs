namespace TraktNET
{
    /// <summary>Determines the field hint in a search query.</summary>
    [TraktEnum(QueryName = "fields", HasQuerySupport = true)]
    public enum TraktSearchField
    {
        /// <summary>An invalid field hint.</summary>
        Unspecified,

        /// <summary>The hint to search in movie, show or episode titles.</summary>
        Title,

        /// <summary>The hint to search in movie taglines.</summary>
        Tagline,

        /// <summary>The hint to search in movie, show or episode overviews.</summary>
        Overview,

        /// <summary>The hint to search in movie or show people.</summary>
        People,

        /// <summary>The hint to search in movie or show translations.</summary>
        Translations,

        /// <summary>The hint to search in movie or show aliases.</summary>
        Aliases,

        /// <summary>The hint to search in person or list names.</summary>
        Name,

        /// <summary>The hint to search in person biographies.</summary>
        Biography,

        /// <summary>The hint to search in list descriptions.</summary>
        Description
    }
}
