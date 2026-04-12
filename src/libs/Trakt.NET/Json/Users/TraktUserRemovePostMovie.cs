using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user post movie, containing the required movie ids.</summary>
    public record class TraktUserRemovePostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }
    }
}
