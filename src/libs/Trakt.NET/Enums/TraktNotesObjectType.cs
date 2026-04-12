namespace TraktNET
{
    /// <summary>Determines the type of an media object to which a note is attached.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktNotesObjectType
    {
        /// <summary>An invalid media object type.</summary>
        Unspecified,

        /// <summary>A note is attached to any kind of media object.</summary>
        All,

        /// <summary>A note is attached to a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>A note is attached to a show.</summary>
        [TraktEnumMember(UriValue = "shows")]
        Show,

        /// <summary>A note is attached to a season.</summary>
        [TraktEnumMember(UriValue = "seasons")]
        Season,

        /// <summary>A note is attached to an episode.</summary>
        [TraktEnumMember(UriValue = "episodes")]
        Episode,

        /// <summary>A note is attached to a person.</summary>
        [TraktEnumMember(UriValue = "people")]
        Person,

        /// <summary>A note is attached to an history item.</summary>
        History,

        /// <summary>A note is attached to a collection.</summary>
        Collection,

        /// <summary>A note is attached to a rating.</summary>
        [TraktEnumMember(UriValue = "ratings")]
        Rating
    }
}
