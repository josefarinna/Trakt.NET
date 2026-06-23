using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktCollectionMovie
    {
        /// <summary>The Trakt movie. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>The movie title.</summary>
        [JsonIgnore]
        public string? Title
        {
            get => Movie?.Title;
            set => Movie?.Title = value;
        }

        /// <summary>The movie release year.</summary>
        [JsonIgnore]
        public uint? Year
        {
            get => Movie?.Year;
            set => Movie?.Year = value;
        }

        /// <summary>
        /// The collection of IDs of the movie for various web services.
        /// See also <seealso cref="TraktMovieIDs" />.
        /// </summary>
        [JsonIgnore]
        public TraktMovieIDs? IDs
        {
            get => Movie?.IDs;
            set => Movie?.IDs = value;
        }

        /// <summary>The movie tagline.</summary>
        [JsonIgnore]
        public string? Tagline
        {
            get => Movie?.Tagline;
            set => Movie?.Tagline = value;
        }

        /// <summary>The synopsis of the movie.</summary>
        [JsonIgnore]
        public string? Overview
        {
            get => Movie?.Overview;
            set => Movie?.Overview = value;
        }

#if NET7_0_OR_GREATER
        /// <summary>The date when the movie was released.</summary>
        [JsonIgnore]
        public DateOnly? Released
        {
            get => Movie?.Released;
            set => Movie?.Released = value;
        }
#else
        /// <summary>The UTC datetime when the movie was released.</summary>
        [JsonIgnore]
        public DateTime? Released
        {
            get => Movie?.Released;
            set => Movie?.Released = value;
        }
#endif

        /// <summary>The runtime of the movie.</summary>
        [JsonIgnore]
        public uint? Runtime
        {
            get => Movie?.Runtime;
            set => Movie?.Runtime = value;
        }

        /// <summary>The country code of the movie.</summary>
        [JsonIgnore]
        public string? Country
        {
            get => Movie?.Country;
            set => Movie?.Country = value;
        }

        /// <summary>The web address of a trailer of the movie.</summary>
        [JsonIgnore]
        public string? Trailer
        {
            get => Movie?.Trailer;
            set => Movie?.Trailer = value;
        }

        /// <summary>The web address of the homepage of the movie.</summary>
        [JsonIgnore]
        public string? Homepage
        {
            get => Movie?.Homepage;
            set => Movie?.Homepage = value;
        }

        /// <summary>The movie's current status. See also <seealso cref="TraktMovieStatus" />.</summary>
        [JsonIgnore]
        public TraktMovieStatus? Status
        {
            get => Movie?.Status;
            set => Movie?.Status = value;
        }

        /// <summary>The average user rating of the movie.</summary>
        [JsonIgnore]
        public float? Rating
        {
            get => Movie?.Rating;
            set => Movie?.Rating = value;
        }

        /// <summary>The number of votes of the movie.</summary>
        [JsonIgnore]
        public uint? Votes
        {
            get => Movie?.Votes;
            set => Movie?.Votes = value;
        }

        /// <summary>The movie colors. See also <seealso cref="TraktColors" />.</summary>
        public TraktColors? Colors
        {
            get => Movie?.Colors;
            set => Movie?.Colors = value;
        }

        /// <summary>The comment count of the movie.</summary>
        [JsonIgnore]
        public uint? CommentCount
        {
            get => Movie?.CommentCount;
            set => Movie?.CommentCount = value;
        }

        /// <summary>The UTC datetime when the movie was last updated.</summary>
        [JsonIgnore]
        public DateTime? UpdatedAt
        {
            get => Movie?.UpdatedAt;
            set => Movie?.UpdatedAt = value;
        }

        /// <summary>The language code of the movie.</summary>
        [JsonIgnore]
        public string? Language
        {
            get => Movie?.Language;
            set => Movie?.Language = value;
        }

        /// <summary>The list of language codes of the movie.</summary>
        [JsonIgnore]
        public List<string>? Languages
        {
            get => Movie?.Languages;
            set => Movie?.Languages = value;
        }

        /// <summary>The list of translation language codes of the movie.</summary>
        [JsonIgnore]
        public List<string>? AvailableTranslations
        {
            get => Movie?.AvailableTranslations;
            set => Movie?.AvailableTranslations = value;
        }

        /// <summary>The collection of Trakt genre slugs of the movie.</summary>
        [JsonIgnore]
        public List<string>? Genres
        {
            get => Movie?.Genres;
            set => Movie?.Genres = value;
        }

        /// <summary>The list of Trakt subgenre slugs of the movie.</summary>
        public List<string>? Subgenres
        {
            get => Movie?.Subgenres;
            set => Movie?.Subgenres = value;
        }

        /// <summary>The content certification of the movie.</summary>
        [JsonIgnore]
        public string? Certification
        {
            get => Movie?.Certification;
            set => Movie?.Certification = value;
        }

        /// <summary>Extra scene after the credits.</summary>
        public bool? AfterCredits
        {
            get => Movie?.AfterCredits;
            set => Movie?.AfterCredits = value;
        }

        /// <summary>Extra scene during the credits.</summary>
        public bool? DuringCredits
        {
            get => Movie?.DuringCredits;
            set => Movie?.DuringCredits = value;
        }

        /// <summary>The collection of image URLs for the movie.</summary>
        [JsonIgnore]
        public TraktMovieImages? Images
        {
            get => Movie?.Images;
            set => Movie?.Images = value;
        }

        /// <summary>The movie original title.</summary>
        public string? OriginalTitle
        {
            get => Movie?.OriginalTitle;
            set => Movie?.OriginalTitle = value;
        }

        /// <summary>A collection of social IDs for various web services for the movie.</summary>
        public TraktMovieSocialIDs? SocialIDs
        {
            get => Movie?.SocialIDs;
            set => Movie?.SocialIDs = value;
        }

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
