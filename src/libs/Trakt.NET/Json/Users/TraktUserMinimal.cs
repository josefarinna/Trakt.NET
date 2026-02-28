using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user.</summary>
    public record class TraktUserMinimal
    {
        /// <summary>The user's username.</summary>
        public string? Username { get; set; }

        /// <summary>The user's privacy status.</summary>
        public bool? Private { get; set; }

        /// <summary>The user's name.</summary>
        public string? Name { get; set; }

        /// <summary>The user's VIP status.</summary>
        [JsonPropertyName("vip")]
        public bool? VIP { get; set; }

        /// <summary>The user's VIP EP status.</summary>
        [JsonPropertyName("vip_ep")]
        public bool? VIPEP { get; set; }

        /// <summary>The collection of IDs for the user. See also <seealso cref="TraktUserIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktUserIDs? IDs { get; set; }
    }
}
