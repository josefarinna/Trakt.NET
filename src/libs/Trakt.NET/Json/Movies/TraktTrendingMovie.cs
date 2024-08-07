using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktTrendingMovie
    {
        public uint? Watchers { get; set; }

        public TraktMovie? Movie { get; set; }

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

#if NET6_0_OR_GREATER
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
        [JsonIgnore]
        public string? Released
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

        [JsonIgnore]
        public IList<string>? Languages
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

        [JsonIgnore]
        public IList<string>? AvailableTranslations
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

        [JsonIgnore]
        public IList<string>? Genres
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
    }
}
