using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>An anticipated Trakt media recommendation (movie or show).</summary>
    public record class TraktAnticipatedMediaRecommendation
    {
        /// <summary>The movie. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>The show. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>The recommendation score for the media item.</summary>
        public float? Score { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The release date of the media item.</summary>
        public DateOnly? Released { get; set; }
#else
        /// <summary>The UTC datetime when the media item was released.</summary>
        public DateTime? Released { get; set; }
#endif

        /// <summary>Gets the media item type. See also <seealso cref="TraktSearchResultType" />.</summary>
        [JsonIgnore]
        public TraktSearchResultType? Type => Movie != null ? TraktSearchResultType.Movie : (Show != null ? TraktSearchResultType.Show : null);

        /// <summary>Gets a string representation of the media recommendation.</summary>
        /// <returns>A string representation of the media recommendation.</returns>
        public override string ToString()
        {
            if (Movie != null)
            {
                return Movie.ToString();
            }

            if (Show != null)
            {
                return Show.ToString();
            }

            return string.Empty;
        }
    }
}
