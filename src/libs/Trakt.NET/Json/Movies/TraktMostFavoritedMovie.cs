namespace TraktNET
{
    /// <summary>A favorited Trakt movie.</summary>
    public record class TraktMostFavoritedMovie : TraktCollectionMovie
    {
        /// <summary>The user count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? UserCount { get; set; }

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
