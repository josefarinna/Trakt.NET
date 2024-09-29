namespace TraktNET
{
    /// <summary>A most played, watched or collected Trakt movie.</summary>
    public record class TraktMostPWCMovie : TraktCollectionMovie
    {
        /// <summary>The watcher count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? WatcherCount { get; set; }

        /// <summary>The play count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>The collected count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? CollectedCount { get; set; }

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
