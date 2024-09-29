namespace TraktNET
{
    /// <summary>A box office Trakt movie.</summary>
    public record class TraktBoxOfficeMovie : TraktCollectionMovie
    {
        /// <summary>The revenue for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public uint? Revenue { get; set; }

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
