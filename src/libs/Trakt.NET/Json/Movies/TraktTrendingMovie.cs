namespace TraktNET
{
    /// <summary>A trending Trakt movie.</summary>
    public record class TraktTrendingMovie : TraktCollectionMovie
    {
        /// <summary>The watcher count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets a string representation of the movie.</summary>
        /// <returns>A string representation of the movie.</returns>
        public override string ToString()
        {
            if (Movie != null)
            {
                return Movie.ToString();
            }

            return string.Empty;
        }
    }
}
