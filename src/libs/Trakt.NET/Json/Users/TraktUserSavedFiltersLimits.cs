namespace TraktNET
{
    /// <summary>A collection of Trakt user saved filters limits.</summary>
    public record class TraktUserSavedFiltersLimits
    {
        /// <summary>Gets or sets the maximum number of saved filters.</summary>
        public uint? Count { get; set; }
    }
}
