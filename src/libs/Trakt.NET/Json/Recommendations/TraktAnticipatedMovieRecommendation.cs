namespace TraktNET
{
    /// <summary>An anticipated Trakt movie recommendation.</summary>
    public record class TraktAnticipatedMovieRecommendation
    {
        /// <summary>The movie. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>The recommendation score for the movie.</summary>
        public float? Score { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The release date of the movie.</summary>
        public DateOnly? Released { get; set; }
#else
        /// <summary>The UTC datetime when the movie was released.</summary>
        public DateTime? Released { get; set; }
#endif

        /// <summary>Gets a string representation of the movie recommendation.</summary>
        /// <returns>A string representation of the movie recommendation.</returns>
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
