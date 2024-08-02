namespace TraktNET
{
    public record class TraktPersonMinimal
    {
        public string? Name { get; set; }

        public TraktPersonIds? Ids { get; set; }
    }
}
