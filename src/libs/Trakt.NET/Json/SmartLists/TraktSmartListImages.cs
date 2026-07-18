namespace TraktNET
{
    /// <summary>A collection of Trakt smart list image URLs.</summary>
    public record class TraktSmartListImages
    {
        /// <summary>A list of poster image URLs.</summary>
        public List<string>? Posters { get; set; }
    }
}
