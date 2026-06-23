using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of IDs, including the Trakt ID and Slug, for a <see cref="TraktList" />.</summary>
    public record class TraktListIDs : ITraktIDs
    {
        /// <summary>The Trakt numeric ID.</summary>
        public uint? Trakt { get; set; }

        /// <summary>The Trakt slug.</summary>
        public string? Slug { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool HasAnyID => (Trakt.HasValue && Trakt.Value > 0) || !string.IsNullOrWhiteSpace(Slug);

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

                return Trakt!.Value.ToInvariantCultureString();
            }
        }
    }
}
