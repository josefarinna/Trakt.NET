namespace TraktNET
{
    /// <summary>Determines the type of an object in a playback progress item.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSyncType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The playback progress item contains a movie.</summary>
        [TraktEnumMember(UriValue = "movies")]
        Movie,

        /// <summary>The playback progress item contains an episode.</summary>
        [TraktEnumMember(UriValue = "episodes")]
        Episode
    }
}
