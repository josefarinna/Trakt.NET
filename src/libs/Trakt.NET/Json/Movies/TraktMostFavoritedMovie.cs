namespace TraktNET
{
    /// <summary>A favorited Trakt movie.</summary>
    public record class TraktMostFavoritedMovie : TraktCollectionMovie
    {
        /// <summary>The user count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? UserCount { get; set; }
    }
}
