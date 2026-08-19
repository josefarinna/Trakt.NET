namespace TraktNET
{
    /// <summary>A hot Trakt movie.</summary>
    public record class TraktHotMovie : TraktCollectionMovie
    {
        /// <summary>The list count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? ListCount { get; set; }
    }
}
