namespace TraktNET
{
    /// <summary>A most anticipated Trakt movie.</summary>
    public record class TraktMostAnticipatedMovie : TraktCollectionMovie
    {
        /// <summary>The list count for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? ListCount { get; set; }

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
