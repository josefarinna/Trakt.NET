using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktMovie : TraktMovieMinimal
    {
        /// <summary>The movie tagline.</summary>
        public string? Tagline { get; set; }

        /// <summary>The synopsis of the movie.</summary>
        public string? Overview { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>The date when the movie was released.</summary>
        public DateOnly? Released { get; set; }
#else
        /// <summary>The UTC datetime when the movie was released.</summary>
        public DateTime? Released { get; set; }
#endif

        /// <summary>The runtime of the movie.</summary>
        public uint? Runtime { get; set; }

        /// <summary>The country code of the movie.</summary>
        public string? Country { get; set; }

        /// <summary>The web address of a trailer of the movie.</summary>
        public string? Trailer { get; set; }

        /// <summary>The web address of the homepage of the movie.</summary>
        public string? Homepage { get; set; }

        /// <summary>The movie's current status. See also <seealso cref="TraktMovieStatus" />.</summary>
        public TraktMovieStatus? Status { get; set; }

        /// <summary>The average user rating of the movie.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes of the movie.</summary>
        public uint? Votes { get; set; }

        /// <summary>The movie colors. See also <seealso cref="TraktColors" />.</summary>
        public TraktColors? Colors { get; set; }

        /// <summary>The comment count of the movie.</summary>
        public uint? CommentCount { get; set; }

        /// <summary>The UTC datetime when the movie was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The language code of the movie.</summary>
        public string? Language { get; set; }

        /// <summary>The list of language codes of the movie.</summary>
        public List<string>? Languages { get; set; }

        /// <summary>The list of translation language codes of the movie.</summary>
        public List<string>? AvailableTranslations { get; set; }

        /// <summary>The collection of Trakt genre slugs of the movie.</summary>
        public List<string>? Genres { get; set; }

        /// <summary>The list of Trakt subgenre slugs of the movie.</summary>
        public List<string>? Subgenres { get; set; }

        /// <summary>The content certification of the movie.</summary>
        public string? Certification { get; set; }

        /// <summary>Extra scene after the credits.</summary>
        public bool? AfterCredits { get; set; }

        /// <summary>Extra scene during the credits.</summary>
        public bool? DuringCredits { get; set; }

        /// <summary>The movie original title.</summary>
        public string? OriginalTitle { get; set; }

        /// <summary>A collection of social IDs for various web services for the movie.</summary>
        [JsonPropertyName("social_ids")]
        public TraktMovieSocialIDs? SocialIDs { get; set; }

        /// <summary>Gets a string representation of the movie.</summary>
        /// <returns>A string representation of the movie.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Year.HasValue)
            {
                title = $"{title} ({Year.Value})";
            }

            return title;
        }
    }
}
