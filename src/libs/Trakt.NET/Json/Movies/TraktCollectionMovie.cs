using System.Text.Json.Serialization;

namespace TraktNET
{
    public abstract record class TraktCollectionMovie
    {
        /// <summary>The Trakt movie. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>The movie title.</summary>
        [JsonIgnore]
        public string? Title
        {
            get => Movie?.Title;

            set
            {
                if (Movie != null)
                {
                    Movie.Title = value;
                }
            }
        }

        /// <summary>The movie release year.</summary>
        [JsonIgnore]
        public uint? Year
        {
            get => Movie?.Year;

            set
            {
                if (Movie != null)
                {
                    Movie.Year = value;
                }
            }
        }

        /// <summary>
        /// The collection of IDs of the movie for various web services.
        /// See also <seealso cref="TraktMovieIds" />.
        /// </summary>
        [JsonIgnore]
        public TraktMovieIds? Ids
        {
            get => Movie?.Ids;

            set
            {
                if (Movie != null)
                {
                    Movie.Ids = value;
                }
            }
        }

        /// <summary>The movie tagline.</summary>
        [JsonIgnore]
        public string? Tagline
        {
            get => Movie?.Tagline;

            set
            {
                if (Movie != null)
                {
                    Movie.Tagline = value;
                }
            }
        }

        /// <summary>The synopsis of the movie.</summary>
        [JsonIgnore]
        public string? Overview
        {
            get => Movie?.Overview;

            set
            {
                if (Movie != null)
                {
                    Movie.Overview = value;
                }
            }
        }

#if NET7_0_OR_GREATER
        /// <summary>The date when the movie was released.</summary>
        [JsonIgnore]
        public DateOnly? Released
        {
            get => Movie?.Released;

            set
            {
                if (Movie != null)
                {
                    Movie.Released = value;
                }
            }
        }
#else
        /// <summary>The UTC datetime when the movie was released.</summary>
        [JsonIgnore]
        public DateTime? Released
        {
            get => Movie?.Released;

            set
            {
                if (Movie != null)
                {
                    Movie.Released = value;
                }
            }
        }
#endif

        /// <summary>The runtime of the movie.</summary>
        [JsonIgnore]
        public uint? Runtime
        {
            get => Movie?.Runtime;

            set
            {
                if (Movie != null)
                {
                    Movie.Runtime = value;
                }
            }
        }

        /// <summary>The country code of the movie.</summary>
        [JsonIgnore]
        public string? Country
        {
            get => Movie?.Country;

            set
            {
                if (Movie != null)
                {
                    Movie.Country = value;
                }
            }
        }

        /// <summary>The web address of a trailer of the movie.</summary>
        [JsonIgnore]
        public string? Trailer
        {
            get => Movie?.Trailer;

            set
            {
                if (Movie != null)
                {
                    Movie.Trailer = value;
                }
            }
        }

        /// <summary>The web address of the homepage of the movie.</summary>
        [JsonIgnore]
        public string? Homepage
        {
            get => Movie?.Homepage;

            set
            {
                if (Movie != null)
                {
                    Movie.Homepage = value;
                }
            }
        }

        /// <summary>The movie's current status. See also <seealso cref="TraktMovieStatus" />.</summary>
        [JsonIgnore]
        public TraktMovieStatus? Status
        {
            get => Movie?.Status;

            set
            {
                if (Movie != null)
                {
                    Movie.Status = value;
                }
            }
        }

        /// <summary>The average user rating of the movie.</summary>
        [JsonIgnore]
        public float? Rating
        {
            get => Movie?.Rating;

            set
            {
                if (Movie != null)
                {
                    Movie.Rating = value;
                }
            }
        }

        /// <summary>The number of votes of the movie.</summary>
        [JsonIgnore]
        public uint? Votes
        {
            get => Movie?.Votes;

            set
            {
                if (Movie != null)
                {
                    Movie.Votes = value;
                }
            }
        }

        /// <summary>The comment count of the movie.</summary>
        [JsonIgnore]
        public uint? CommentCount
        {
            get => Movie?.CommentCount;

            set
            {
                if (Movie != null)
                {
                    Movie.CommentCount = value;
                }
            }
        }

        /// <summary>The UTC datetime when the movie was last updated.</summary>
        [JsonIgnore]
        public DateTime? UpdatedAt
        {
            get => Movie?.UpdatedAt;

            set
            {
                if (Movie != null)
                {
                    Movie.UpdatedAt = value;
                }
            }
        }

        /// <summary>The language code of the movie.</summary>
        [JsonIgnore]
        public string? Language
        {
            get => Movie?.Language;

            set
            {
                if (Movie != null)
                {
                    Movie.Language = value;
                }
            }
        }

        /// <summary>The list of language codes of the movie.</summary>
        [JsonIgnore]
        public List<string>? Languages
        {
            get => Movie?.Languages;

            set
            {
                if (Movie != null)
                {
                    Movie.Languages = value;
                }
            }
        }

        /// <summary>The list of translation language codes of the movie.</summary>
        [JsonIgnore]
        public List<string>? AvailableTranslations
        {
            get => Movie?.AvailableTranslations;

            set
            {
                if (Movie != null)
                {
                    Movie.AvailableTranslations = value;
                }
            }
        }

        /// <summary>The collection of Trakt genre slugs of the movie.</summary>
        [JsonIgnore]
        public List<string>? Genres
        {
            get => Movie?.Genres;

            set
            {
                if (Movie != null)
                {
                    Movie.Genres = value;
                }
            }
        }

        /// <summary>The content certification of the movie.</summary>
        [JsonIgnore]
        public string? Certification
        {
            get => Movie?.Certification;

            set
            {
                if (Movie != null)
                {
                    Movie.Certification = value;
                }
            }
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
