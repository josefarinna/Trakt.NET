namespace TraktNET
{
    /// <summary>An user personal list items post episode, containing the required episode ids.</summary>
    public record class TraktUserPersonalListItemsPostEpisode : TraktUserRemovePostEpisode
    {
        /// <summary>Gets or sets the episode notes.</summary>
        public string? Notes { get; set; }
    }
}
