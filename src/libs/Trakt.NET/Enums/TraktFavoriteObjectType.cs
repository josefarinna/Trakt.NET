namespace TraktNET
{
    /// <summary>Determines the type of an object in a favorite item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktFavoriteObjectType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The recommendation contains a movie.</summary>
        Movie,

        /// <summary>The recommendation contains a show.</summary>
        Show
    }
}
