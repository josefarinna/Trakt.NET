namespace TraktNET
{
    /// <summary>A collection of Trakt user notes limits.</summary>
    public record class TraktUserNotesLimits
    {
        /// <summary>Gets or sets the maximum number of notes items.</summary>
        public uint? ItemCount { get; set; }
    }
}
