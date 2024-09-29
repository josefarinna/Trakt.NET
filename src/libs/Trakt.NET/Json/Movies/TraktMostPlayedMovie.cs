namespace TraktNET
{
    /// <summary>A most played Trakt movie.</summary>
    public record class TraktMostPlayedMovie : TraktMostPWCMovie
    {

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
