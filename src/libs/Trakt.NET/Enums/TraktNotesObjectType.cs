namespace TraktNET
{
    /// <summary>Determines the type of an media object to which a note is attached.</summary>
    [TraktEnum]
    public enum TraktNotesObjectType
    {
        /// <summary>An invalid media object type.</summary>
        Unspecified,

        /// <summary>A note is attached to any kind of media object.</summary>
        All,

        /// <summary>A note is attached to a movie.</summary>
        Movie,

        /// <summary>A note is attached to a show.</summary>
        Show,

        /// <summary>A note is attached to a season.</summary>
        Season,

        /// <summary>A note is attached to an episode.</summary>
        Episode,

        /// <summary>A note is attached to a person.</summary>
        Person,

        /// <summary>A note is attached to an history item.</summary>
        History,

        /// <summary>A note is attached to a collection.</summary>
        Collection,

        /// <summary>A note is attached to a rating.</summary>
        Rating
    }
}
