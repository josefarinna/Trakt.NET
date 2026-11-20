using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt show, which was not found.</summary>
    public record class TraktPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the optional title of the not found show.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional release year of the not found show.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>Gets or sets the optional list of not found seasons under this show.</summary>
        public List<TraktPostResponseNotFoundShowSeason>? Seasons { get; set; }
    }
}
