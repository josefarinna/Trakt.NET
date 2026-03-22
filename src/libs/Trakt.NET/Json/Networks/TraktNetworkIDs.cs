using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of ids for various web services, including the Trakt id.</summary>
    public record class TraktNetworkIDs : ITraktIDs
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        public uint? Trakt { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        public uint? TMDB { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool HasAnyID => (Trakt.HasValue && Trakt.Value > 0) ||  (TMDB.HasValue && TMDB.Value > 0);

        /// <inheritdoc />
        [JsonIgnore]
        public string BestID
        {
            get
            {
                if (!HasAnyID)
                    return string.Empty;

                if (Trakt.HasValue && Trakt.Value > 0)
                    return Trakt.Value.ToInvariantCultureString();

                if (TMDB.HasValue && TMDB.Value > 0)
                    return TMDB.Value.ToInvariantCultureString();

                return string.Empty;
            }
        }
    }
}
