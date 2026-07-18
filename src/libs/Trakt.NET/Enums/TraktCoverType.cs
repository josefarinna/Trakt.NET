namespace TraktNET
{
    /// <summary>The type of a user cover image.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktCoverType
    {
        /// <summary>An unspecified cover type.</summary>
        Unspecified,

        /// <summary>The cover image is for a movie.</summary>
        [TraktEnumMember(UriValue = "movie")]
        Movie,

        /// <summary>The cover image is for a show.</summary>
        [TraktEnumMember(UriValue = "show")]
        Show,

        /// <summary>The cover image is for an episode.</summary>
        [TraktEnumMember(UriValue = "episode")]
        Episode
    }
}
