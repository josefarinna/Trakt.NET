using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of social IDs for various web services for a Trakt person.</summary>
    public record class TraktPersonSocialIDs
    {
        /// <summary>The Twitter ID of a person.</summary>
        public string? Twitter { get; set; }

        /// <summary>The Facebook ID of a person.</summary>
        public string? Facebook { get; set; }

        /// <summary>The Instagram ID of a person.</summary>
        public string? Instagram { get; set; }

        /// <summary>The TikTok handle of a person without the leading @.</summary>
        [JsonPropertyName("tiktok")]
        public string? TikTok { get; set; }

        /// <summary>The YouTube channel ID of a person, starting with UC.</summary>
        [JsonPropertyName("youtube")]
        public string? YouTube { get; set; }

        /// <summary>The Wikidata entity ID of a person, like Q43416.</summary>
        [JsonPropertyName("wikidata")]
        public string? Wikidata { get; set; }

        /// <summary>The Wikipedia link of a person.</summary>
        public string? Wikipedia { get; set; }

        /// <summary>The language code of the Wikipedia page in <see cref="Wikipedia" />.</summary>
        [JsonPropertyName("wikipedia_language")]
        public string? WikipediaLanguage { get; set; }
    }
}
