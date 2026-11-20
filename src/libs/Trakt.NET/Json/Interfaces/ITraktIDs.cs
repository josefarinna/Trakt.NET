namespace TraktNET
{
    /// <summary>A collection of IDs for various web services.</summary>
    public interface ITraktIDs
    {
        /// <summary>Returns, whether any ID has been set.</summary>
        bool HasAnyID { get; }

        /// <summary>Gets the ID used to identify the object in request URLs.</summary>
        /// <remarks>
        /// Only IDs that the Trakt API accepts in request URLs are considered (Trakt slug, Trakt ID and, where available, IMDB ID).
        /// IDs from other services, such as TMDB or TVDB, are never returned.
        /// </remarks>
        /// <returns>The ID as a string or an empty string, if no usable ID is set.</returns>
        string BestID { get; }
    }
}
