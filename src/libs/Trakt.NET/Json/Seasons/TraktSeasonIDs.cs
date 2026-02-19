using System.Globalization;
using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of IDs for various web services, including the Trakt ID, for a Trakt season.</summary>
    public record class TraktSeasonIDs : ITraktIDs
    {
        /// <summary>The Trakt numeric ID.</summary>
        public uint? Trakt { get; set; }

        /// <summary>The numeric ID from thetvdb.com</summary>
        public uint? TVDB { get; set; }

        /// <summary>The numeric ID from themoviedb.org</summary>
        public uint? TMDB { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool HasAnyID => (Trakt.HasValue && Trakt.Value > 0) || (TVDB.HasValue && TVDB.Value > 0) || (TMDB.HasValue && TMDB.Value > 0);

        /// <inheritdoc />
        [JsonIgnore]
        public string BestID
        {
            get
            {
                if (!HasAnyID)
                    return string.Empty;

                if (Trakt.HasValue && Trakt.Value > 0)
                    return Trakt.Value.ToString(CultureInfo.InvariantCulture);

                if (TVDB.HasValue && TVDB.Value > 0)
                    return TVDB.Value.ToString(CultureInfo.InvariantCulture);

                if (TMDB.HasValue && TMDB.Value > 0)
                    return TMDB.Value.ToString(CultureInfo.InvariantCulture);

                return string.Empty;
            }
        }
    }
}
