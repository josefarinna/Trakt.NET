namespace TraktNET
{
    public sealed partial class TraktFilter
    {
        public string? Query { get; set; }

        public uint? Year { get; set; }

        public Range<uint>? Years { get; set; }

        public string[]? Genres { get; set; }

        public string[]? Languages { get; set; }

        public string[]? Countries { get; set; }

        public Range<uint>? Runtimes { get; set; }

        public uint[]? StudioIds { get; set; }

        public Range<uint>? Ratings { get; set; }

        public Range<uint>? Votes { get; set; }

        public Range<float>? TMDBRatings { get; set; }

        public Range<uint>? TMDBVotes { get; set; }

        public Range<float>? IMDBRatings { get; set; }

        public Range<uint>? IMDBVotes { get; set; }

        public Range<uint>? RottenTomatoesMeters { get; set; }

        public Range<uint>? RottenTomatoesUserMeters { get; set; }

        public Range<float>? Metascores { get; set; }

        public string[]? Certifications { get; set; }

        public uint[]? NetworkIds { get; set; }

        public TraktShowStatus[]? Status { get; set; }

        public TraktEpisodeType[]? EpisodeTypes { get; set; }
    }
}
