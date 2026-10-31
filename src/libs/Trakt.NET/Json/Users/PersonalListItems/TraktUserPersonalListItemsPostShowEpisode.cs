namespace TraktNET
{
    /// <summary>An user personal list items post episode, containing the required episode number.</summary>
    public record class TraktUserPersonalListItemsPostShowEpisode : TraktUserRemovePostShowEpisode
    {
        /// <summary>Gets or sets the episode notes.</summary>
        public string? Notes { get; set; }
    }
}
