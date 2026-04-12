namespace TraktNET
{
    /// <summary>An user personal list items post movie, containing the required movie ids.</summary>
    public record class TraktUserPersonalListItemsPostMovie : TraktUserRemovePostMovie
    {
        /// <summary>Gets or sets the movie notes.</summary>
        public string? Notes { get; set; }
    }
}
