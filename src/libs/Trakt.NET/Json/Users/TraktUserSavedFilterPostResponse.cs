namespace TraktNET
{
    /// <summary>Represents the response of adding saved filters.</summary>
    public record class TraktUserSavedFilterPostResponse
    {
        /// <summary>Gets or sets the list of added saved filters.</summary>
        public IReadOnlyList<TraktUserSavedFilter>? Added { get; set; }

        /// <summary>Gets or sets the list of skipped saved filters.</summary>
        public IReadOnlyList<TraktUserSavedFilterPost>? Skipped { get; set; }
    }
}
