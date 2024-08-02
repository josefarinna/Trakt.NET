namespace TraktNET
{
    public record class TraktShowMinimal
    {
        public string? Title { get; set; }

        public uint? Year { get; set; }

        public TraktShowIds? Ids { get; set; }
    }
}
