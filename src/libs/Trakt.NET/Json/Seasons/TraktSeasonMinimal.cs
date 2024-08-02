namespace TraktNET
{
    public record class TraktSeasonMinimal
    {
        public uint? Number { get; set; }

        public TraktSeasonIds? Ids { get; set; }
    }
}
