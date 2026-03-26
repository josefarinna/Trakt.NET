namespace TraktNET
{
    public record class TraktListItemsReorderPost
    {
        public List<uint>? Rank { get; set; }

        public void Validate()
        {
            if (Rank == null)
                throw new TraktPostValidationException(nameof(Rank), "rank must not be null");
        }
    }
}
