namespace TraktNET
{
    /// <summary>A box office Trakt movie.</summary>
    public record class TraktBoxOfficeMovie : TraktCollectionMovie
    {
        /// <summary>The revenue for the <see cref="Movie" />.</summary>
        public uint? Revenue { get; set; }
    }
}
