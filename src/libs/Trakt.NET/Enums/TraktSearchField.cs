namespace TraktNET
{
    /// <summary>Determines the field hint in a search query.</summary>
    [TraktEnum(QueryName = "fields", HasQuerySupport = true)]
    [Flags]
    public enum TraktSearchField
    {
        /// <summary>An invalid field hint.</summary>
        Unspecified = 0,

        /// <summary>The hint to search in movie, show or episode titles.</summary>
        Title = 1,

        /// <summary>The hint to search in movie taglines.</summary>
        Tagline = 2,

        /// <summary>The hint to search in movie, show or episode overviews.</summary>
        Overview = 4,

        /// <summary>The hint to search in movie or show people.</summary>
        People = 8,

        /// <summary>The hint to search in movie or show translations.</summary>
        Translations = 16,

        /// <summary>The hint to search in movie or show aliases.</summary>
        Aliases = 32,

        /// <summary>The hint to search in person or list names.</summary>
        Name = 64,

        /// <summary>The hint to search in person biographies.</summary>
        Biography = 128,

        /// <summary>The hint to search in list descriptions.</summary>
        Description = 256
    }
}
