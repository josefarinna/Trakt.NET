namespace TraktNET
{
    /// <summary>Determines the type of an object in a favorite item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktFavoriteObjectType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The recommendation contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The recommendation contains a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show
    }
}
