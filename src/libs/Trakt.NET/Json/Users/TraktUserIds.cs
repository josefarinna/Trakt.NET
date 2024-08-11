using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of IDs for a Trakt user.</summary>
    public record class TraktUserIds : ITraktIds
    {
        /// <summary>The Trakt slug.</summary>
        public string? Slug { get; set; }

        /// <summary>The globally unique UUID.</summary>
        public string? UUID { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool HasAnyID => !string.IsNullOrWhiteSpace(Slug) || !string.IsNullOrWhiteSpace(UUID);

        /// <inheritdoc />
        [JsonIgnore]
        public string BestID
        {
            get
            {
                if (!HasAnyID)
                    return string.Empty;

                if (!string.IsNullOrWhiteSpace(Slug))
                    return Slug!;

                if (!string.IsNullOrWhiteSpace(UUID))
                    return UUID!;

                return string.Empty;
            }
        }
    }
}
