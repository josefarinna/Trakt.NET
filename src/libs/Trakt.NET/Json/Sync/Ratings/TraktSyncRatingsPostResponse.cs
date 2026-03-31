namespace TraktNET
{
    /// <summary>
    /// Represents the response for a ratings post. See also <see cref="TraktSyncRatingsPost" />.
    /// <para>Contains the number of added and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public record class TraktSyncRatingsPostResponse
    {
        /// <summary>A collection containing the number of added movies, shows, seasons and episodes.</summary>
        public TraktSyncPostResponseGroup? Added { get; set; }

        /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
        public TraktSyncRatingsPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
