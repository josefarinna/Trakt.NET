using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktUser : TraktUserMinimal
    {
        /// <summary>The user's deleted status.</summary>
        public bool? Deleted { get; set; }

        /// <summary>The UTC datetime when the user joined Trakt.</summary>
        public DateTime? JoinedAt { get; set; }

        /// <summary>The user's location.</summary>
        public string? Location { get; set; }

        /// <summary>The user's about information.</summary>
        public string? About { get; set; }

        /// <summary>The user's gender.</summary>
        public TraktGender? Gender { get; set; }

        /// <summary>The user's age.</summary>
        public uint? Age { get; set; }

        /// <summary>The collection of images for the user. See also <seealso cref="TraktUserImages" />.</summary>
        public TraktUserImages? Images { get; set; }

        /// <summary>The user's VIP OG status.</summary>
        [JsonPropertyName("vip_og")]
        public bool? VIPOG { get; set; }

        /// <summary>The user's VIP years.</summary>
        [JsonPropertyName("vip_years")]
        public uint? VIPYears { get; set; }

        /// <summary>The user's VIP cover image.</summary>
        [JsonPropertyName("vip_cover_image")]
        public string? VIPCoverImage { get; set; }

        /// <summary>The UTC datetime when the user's unbroken paid VIP status started.</summary>
        [JsonPropertyName("vip_veteran_since")]
        public DateTime? VIPVeteranSince { get; set; }

        /// <summary>The whole years since the user's unbroken paid VIP status started.</summary>
        [JsonPropertyName("vip_veteran_years")]
        public uint? VIPVeteranYears { get; set; }

        /// <summary>The highest reached rung of the 1 / 3 / 5 / 7 / 10 year ladder for the user's VIP status.</summary>
        [JsonPropertyName("vip_veteran_tier")]
        public uint? VIPVeteranTier { get; set; }

        /// <summary>The VIP veteran title for the user. See also <seealso cref="TraktVIPVeteranTitle" />.</summary>
        [JsonPropertyName("vip_veteran_title")]
        public TraktVIPVeteranTitle? VIPVeteranTitle { get; set; }

        /// <summary>The UTC datetime when the user's VIP grace period ends.</summary>
        [JsonPropertyName("vip_grace_ends_at")]
        public DateTime? VIPGraceEndsAt { get; set; }

        /// <summary>The user's email address.</summary>
        public string? Email { get; set; }
    }
}
