using System.Globalization;
using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of IDs for various web services, including the Trakt ID, for a Trakt movie.</summary>
    public record class TraktMovieIds : ITraktIds
    {
        /// <summary>The Trakt numeric ID.</summary>
        public uint? Trakt { get; set; }

        /// <summary>The Trakt slug.</summary>
        public string? Slug { get; set; }

        /// <summary>The ID from imdb.com</summary>
        public string? IMDB { get; set; }

        /// <summary>The numeric ID from themoviedb.org</summary>
        public uint? TMDB { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public bool HasAnyID => Trakt.HasValue && Trakt.Value > 0 || !string.IsNullOrWhiteSpace(Slug)
            || !string.IsNullOrWhiteSpace(IMDB) || TMDB.HasValue && TMDB.Value > 0;

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

                if (Trakt.HasValue && Trakt.Value > 0)
                    return Trakt.Value.ToString(CultureInfo.InvariantCulture);

                if (!string.IsNullOrWhiteSpace(IMDB))
                    return IMDB!;

                if (TMDB.HasValue && TMDB.Value > 0)
                    return TMDB.Value.ToString(CultureInfo.InvariantCulture);

                return string.Empty;
            }
        }
    }
}
