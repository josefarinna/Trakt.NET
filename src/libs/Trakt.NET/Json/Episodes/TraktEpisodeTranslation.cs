namespace TraktNET
{
    public record class TraktEpisodeTranslation
    {
        public string? Title { get; set; }

        public string? Overview { get; set; }

        public string? Language { get; set; }

        public string? Country { get; set; }
    }
}
