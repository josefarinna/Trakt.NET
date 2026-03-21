namespace TraktNET
{
    /// <summary>A Trakt user comment.</summary>
    public record class TraktUserComment : TraktCommentItem
    {
        /// <summary>Gets or sets the comment's content.<para>Nullable</para></summary>
        public TraktComment? Comment { get; set; }
    }
}
