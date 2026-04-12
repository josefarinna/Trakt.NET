using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents Trakt user account settings.</summary>
    public record class TraktAccountSettings
    {
        /// <summary>Gets or sets the user's timezone.</summary>
        public string? Timezone { get; set; }

        /// <summary>Gets or sets the user's date format.</summary>
        public TraktDateFormat? DateFormat { get; set; }

        /// <summary>Gets or sets, whether an user uses the 24h time format.</summary>
        [JsonPropertyName("time_24hr")]
        public bool? Time24Hr { get; set; }

        /// <summary>Gets or sets the user's cover image url.</summary>
        public string? CoverImage { get; set; }

        /// <summary>Gets or sets the user's token.</summary>
        public string? Token { get; set; }

        /// <summary>Gets or sets if the user's should see ads.</summary>
        public bool? DisplayAds { get; set; }
    }
}
