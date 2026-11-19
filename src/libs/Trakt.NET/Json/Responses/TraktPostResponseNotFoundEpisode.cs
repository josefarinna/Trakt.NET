using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt episode, which was not found.</summary>
    public record class TraktPostResponseNotFoundEpisode
    {
        /// <summary>Gets or sets the optional title of the show when echoed as a show-shaped entry.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional release year of the show when echoed as a show-shaped entry.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the ids of the not found episode. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }

        /// <summary>Gets or sets the optional list of not found seasons and episodes when echoed as a show-shaped entry.</summary>
        public List<TraktPostResponseNotFoundShowSeason>? Seasons { get; set; }
    }
}
