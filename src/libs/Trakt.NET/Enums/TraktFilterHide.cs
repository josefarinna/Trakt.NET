namespace TraktNET
{
    /// <summary>Determines the items to hide in a filter.</summary>
    [TraktEnum(HasQuerySupport = true, QueryName = "hide")]
    public enum TraktFilterHide
    {
        /// <summary>An invalid filter.</summary>
        Unspecified,

        /// <summary>The filter to hide unwatched items.</summary>
        Unwatched,

        /// <summary>The filter to hide collected items.</summary>
        Collected,

        /// <summary>The filter to hide uncollected items.</summary>
        Uncollected,

        /// <summary>The filter to hide rated items.</summary>
        Rated,

        /// <summary>The filter to hide unrated items.</summary>
        Unrated,

        /// <summary>The filter to hide unreleased items.</summary>
        Unreleased,

        /// <summary>The filter to hide items with no release date.</summary>
        [TraktEnumMember(JsonValue = "noreleasedate", DisplayName = "No Release Date")]
        NoReleaseDate,

        /// <summary>The filter to hide ended items.</summary>
        Ended,

        /// <summary>The filter to hide airing items.</summary>
        Airing,

        /// <summary>The filter to hide unwatchlisted items.</summary>
        Unwatchlisted,

        /// <summary>The filter to hide listed items.</summary>
        Listed,

        /// <summary>The filter to hide items with notes.</summary>
        Notes,

        /// <summary>The filter to hide items with no notes.</summary>
        [TraktEnumMember(JsonValue = "nonotes", DisplayName = "No Notes")]
        NoNotes
    }
}
