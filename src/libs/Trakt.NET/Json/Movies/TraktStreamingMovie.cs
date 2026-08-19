namespace TraktNET
{
    /// <summary>A streaming Trakt movie.</summary>
    public record class TraktStreamingMovie : TraktCollectionMovie
    {
        /// <summary>The rank for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public int? Rank { get; set; }

        /// <summary>The delta / change in ranking for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public int? Delta { get; set; }

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
