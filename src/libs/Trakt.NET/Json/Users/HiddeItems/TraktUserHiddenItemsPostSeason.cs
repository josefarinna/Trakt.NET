namespace TraktNET
{
    /// <summary>An user hidden items post season, containing the required season ids.</summary>
    public record class TraktUserHiddenItemsPostSeason : TraktUserRemovePostSeason
    {
        /// <summary>Gets or sets the optional UTC datetime when the season was hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
