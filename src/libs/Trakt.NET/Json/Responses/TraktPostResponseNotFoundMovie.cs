using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt movie, which was not found.</summary>
    public record class TraktPostResponseNotFoundMovie
    {
        /// <summary>Gets or sets the ids of the not found movie. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }
    }
}
