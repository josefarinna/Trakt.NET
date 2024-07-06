namespace TraktNET
{
    /// <summary>Determines the type of an object in a playback progress item.</summary>
    [TraktEnum]
    public enum TraktSyncType
    {
        /// <summary>An invalid object type.</summary>
        Unspecified,

        /// <summary>The playback progress item contains a movie.</summary>
        [TraktEnumMember("movie", UriValue = "movies")]
        Movie,

        /// <summary>The playback progress item contains an episode.</summary>
        [TraktEnumMember("episode", UriValue = "episodes")]
        Episode
    }
}
