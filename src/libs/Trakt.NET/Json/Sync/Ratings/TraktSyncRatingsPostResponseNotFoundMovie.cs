using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A rated Trakt movie, which was not found.</summary>
    public record class TraktSyncRatingsPostResponseNotFoundMovie
    {
        /// <summary>Gets or sets the rating of the not found movie.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found movie. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }
    }
}
