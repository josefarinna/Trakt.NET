namespace TraktNET
{
    /// <summary>An user hidden items post movie, containing the required movie ids.</summary>
    public record class TraktUserHiddenItemsPostMovie : TraktUserRemovePostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime when the movie was hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
