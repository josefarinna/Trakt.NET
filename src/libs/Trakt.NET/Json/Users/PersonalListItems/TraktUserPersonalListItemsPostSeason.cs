namespace TraktNET
{
    /// <summary>An user personal list items post season, containing the required season ids.</summary>
    public record class TraktUserPersonalListItemsPostSeason : TraktUserRemovePostSeason
    {
        /// <summary>Gets or sets the season notes.</summary>
        public string? Notes { get; set; }
    }
}
