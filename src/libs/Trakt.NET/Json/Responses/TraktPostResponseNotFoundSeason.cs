using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt season, which was not found.</summary>
    public record class TraktPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the optional title of the show when echoed as a show-shaped entry.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional release year of the show when echoed as a show-shaped entry.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }

        /// <summary>Gets or sets the optional list of not found seasons when echoed as a show-shaped entry.</summary>
        public List<TraktPostResponseNotFoundShowSeason>? Seasons { get; set; }
    }
}
