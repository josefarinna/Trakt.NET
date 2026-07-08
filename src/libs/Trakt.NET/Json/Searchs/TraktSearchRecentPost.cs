namespace TraktNET
{
    /// <summary>A Trakt search recent post body.</summary>
    public record class TraktSearchRecentPost
    {
        /// <summary>Gets or sets the search query.</summary>
        public string? Query { get; set; }

        /// <summary>Gets or sets the Trakt ID of the item.</summary>
        public uint Id { get; set; }

        /// <summary>Gets or sets the search recent type. See also <seealso cref="TraktSearchRecentType" />.</summary>
        public TraktSearchRecentType? Type { get; set; }

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(Query, "search query is not valid");

            if (Id == 0)
                throw new TraktRequestValidationException(nameof(Id), "item id not valid");

            if (Type == TraktSearchRecentType.Unspecified)
                throw new TraktRequestValidationException(nameof(Type), "type not valid");
        }
    }
}
