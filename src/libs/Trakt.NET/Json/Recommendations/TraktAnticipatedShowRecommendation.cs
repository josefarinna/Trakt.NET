namespace TraktNET
{
    /// <summary>An anticipated Trakt show recommendation.</summary>
    public record class TraktAnticipatedShowRecommendation
    {
        /// <summary>The show. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>The recommendation score for the show.</summary>
        public float? Score { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The release date of the show.</summary>
        public DateOnly? Released { get; set; }
#else
        /// <summary>The UTC datetime when the show was released.</summary>
        public DateTime? Released { get; set; }
#endif

        /// <summary>Gets a string representation of the show recommendation.</summary>
        /// <returns>A string representation of the show recommendation.</returns>
        public override string ToString()
        {
            if (Show != null)
            {
                return Show.ToString();
            }

            return string.Empty;
        }
    }
}
