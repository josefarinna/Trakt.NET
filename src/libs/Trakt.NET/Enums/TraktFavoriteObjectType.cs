namespace TraktNET
{
    /// <summary>Determines the type of an object in a favorite item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktFavoriteObjectType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The favorite contains media (movies and shows).</summary>
        [TraktEnumMember(UriValue = "media")]
        Media,

        /// <summary>The favorite contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The favorite contains a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show
    }
}
