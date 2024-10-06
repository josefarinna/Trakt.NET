namespace TraktNET
{
    /// <summary>A collection of optional filters for refining results.</summary>
    public sealed partial class TraktFilter
    {
        /// <summary>Search titles and descriptions.</summary>
        public string? Query { get; set; }

        /// <summary>4 digit year.</summary>
        public uint? Year { get; set; }

        /// <summary>Range of 4 digit years.</summary>
        public Range<uint>? Years { get; set; }

        /// <summary>Genre slugs.</summary>
        public string[]? Genres { get; set; }

        /// <summary>2 character language codes.</summary>
        public string[]? Languages { get; set; }

        /// <summary>2 character country codes.</summary>
        public string[]? Countries { get; set; }

        /// <summary>Range in minutes.</summary>
        public Range<uint>? Runtimes { get; set; }

        /// <summary>Trakt studio IDs.</summary>
        public uint[]? StudioIDs { get; set; }

        /// <summary>Trakt rating range between 0 and 100.</summary>
        public Range<uint>? Ratings { get; set; }

        /// <summary>Trakt vote count between 0 and 100000.</summary>
        public Range<uint>? Votes { get; set; }

        /// <summary>TMDB rating range between 0.0 and 10.0.</summary>
        public Range<float>? TMDBRatings { get; set; }

        /// <summary>TMDB vote count between 0 and 100000.</summary>
        public Range<uint>? TMDBVotes { get; set; }

        /// <summary>IMDB rating range between 0.0 and 10.0.</summary>
        public Range<float>? IMDBRatings { get; set; }

        /// <summary>IMDB vote count between 0 and 3000000.</summary>
        public Range<uint>? IMDBVotes { get; set; }

        /// <summary>Rotten Tomatoes tomatometer range between 0 and 100.</summary>
        public Range<uint>? RottenTomatoesMeters { get; set; }

        /// <summary>Rotten Tomatoes audience score range between 0 and 100.</summary>
        public Range<uint>? RottenTomatoesUserMeters { get; set; }

        /// <summary>Metacritic score range between 0 and 100.</summary>
        public Range<float>? Metascores { get; set; }

        /// <summary>US content certifications.</summary>
        public string[]? Certifications { get; set; }

        /// <summary>Trakt network IDs.</summary>
        public uint[]? NetworkIDs { get; set; }

        /// <summary>Collection of show status.</summary>
        public TraktShowStatus[]? Status { get; set; }

        /// <summary>Collection of episode types.</summary>
        public TraktEpisodeType[]? EpisodeTypes { get; set; }
    }
}
