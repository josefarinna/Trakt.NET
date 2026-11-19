namespace TraktNET
{
    /// <summary>An user hidden items post season, containing the required season number.</summary>
    public record class TraktUserHiddenItemsPostShowSeason : TraktUserRemovePostShowSeason
    {
        /// <summary>Gets or sets the optional UTC datetime when the season was hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
