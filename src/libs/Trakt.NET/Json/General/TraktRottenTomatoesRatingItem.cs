using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents a Rotten Tomatoes rating item with critics rating, audience rating, states, and link.</summary>
    public record class TraktRottenTomatoesRatingItem
    {
        /// <summary>Gets or sets the critics rating value (tomatometer).</summary>
        public float? Rating { get; set; }

        /// <summary>Gets or sets the audience rating score.</summary>
        [JsonPropertyName("user_rating")]
        public uint? UserRating { get; set; }

        /// <summary>Gets or sets the critics consensus state (e.g., "fresh", "certified_fresh", "rotten").</summary>
        public string? State { get; set; }

        /// <summary>Gets or sets the audience score state (e.g., "upright", "spilled").</summary>
        [JsonPropertyName("user_state")]
        public string? UserState { get; set; }

        /// <summary>Gets or sets the external link to the Rotten Tomatoes page.</summary>
        public string? Link { get; set; }
    }
}
