namespace TraktNET
{
    public record class TraktMovieMinimal
    {
        public string? Title { get; set; }

        public uint? Year { get; set; }

        public TraktMovieIds? Ids { get; set; }
    }
}
