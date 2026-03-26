namespace TraktNET
{
    /// <summary>A collection of Trakt list image URLs.</summary>
    public record class TraktListImages
    {
        /// <summary>A list of Poster image URLs.</summary>
        public List<string>? Poster { get; set; }
    }
}
