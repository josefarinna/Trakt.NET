using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt rating or multi-provider ratings.</summary>
    public record class TraktRating
    {
        /// <summary>The rating value.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes for this rating.</summary>
        public uint? Votes { get; set; }

        /// <summary>The rating distribution.</summary>
        public Dictionary<string, uint>? Distribution { get; set; }

        /// <summary>The Trakt rating details.</summary>
        public TraktRating? Trakt { get; set; }

        /// <summary>The TMDb rating details.</summary>
        public TraktRatingItem? TMDB { get; set; }

        /// <summary>The IMDb rating details.</summary>
        public TraktRatingItem? IMDB { get; set; }

        /// <summary>The Metascore rating details.</summary>
        public TraktMetascoreRatingItem? Metascore { get; set; }

        /// <summary>The Rotten Tomatoes rating details.</summary>
        [JsonPropertyName("rotten_tomatoes")]
        public TraktRottenTomatoesRatingItem? RottenTomatoes { get; set; }

        /// <summary>The Letterboxd rating details.</summary>
        public TraktRatingItem? Letterboxd { get; set; }

        /// <summary>The MyAnimeList (MAL) rating details.</summary>
        public TraktRatingItem? MAL { get; set; }

        /// <summary>Gets a string representation of the rating, showing the rating value and the vote count.</summary>
        /// <returns>A string representation of the rating, showing the rating value and the vote count.</returns>
        public override string ToString()
        {
            if (Rating.HasValue && Votes.HasValue)
            {
                return $"{Rating.Value.ToInvariantCultureString()}, {Votes.Value.ToInvariantCultureString()}";
            }

            if (Trakt != null && Trakt.Rating.HasValue && Trakt.Votes.HasValue)
            {
                return $"{Trakt.Rating.Value.ToInvariantCultureString()}, {Trakt.Votes.Value.ToInvariantCultureString()}";
            }

            return "Empty";
        }
    }
}
