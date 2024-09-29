namespace TraktNET
{
    /// <summary>An updated Trakt movie.</summary>
    public record class TraktUpdatedMovie : TraktCollectionMovie
    {
        /// <summary>The UTC datetime, when the <see cref="TraktCollectionMovie.Movie" /> was updated.</summary>
        public new DateTime? UpdatedAt { get; set; }

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
