namespace TraktNET
{
    /// <summary>A trending Trakt movie.</summary>
    public record class TraktTrendingMovie : TraktCollectionMovie
    {
        /// <summary>The watcher count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? Watchers { get; set; }
    }
}
