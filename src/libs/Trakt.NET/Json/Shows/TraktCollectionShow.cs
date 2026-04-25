using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktCollectionShow
    {
        /// <summary>The Trakt show. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>The show title.</summary>
        [JsonIgnore]
        public string? Title
        {
            get => Show?.Title;
            set
            {
                if (Show != null)
                {
                    Show.Title = value;
                }
            }
        }

        /// <summary>The show release year.</summary>
        [JsonIgnore]
        public uint? Year
        {
            get => Show?.Year;
            set
            {
                if (Show != null)
                {
                    Show.Year = value;
                }
            }
        }

        /// <summary>
        /// The collection of IDs of the show for various web services.
        /// See also <seealso cref="TraktShowIDs" />.
        /// </summary>
        [JsonIgnore]
        public TraktShowIDs? IDs
        {
            get => Show?.IDs;
            set
            {
                if (Show != null)
                {
                    Show.IDs = value;
                }
            }
        }

        /// <summary>The show tagline.</summary>
        [JsonIgnore]
        public string? Tagline
        {
            get => Show?.Tagline;
            set
            {
                if (Show != null)
                {
                    Show.Tagline = value;
                }
            }
        }

        /// <summary>The synopsis of the show.</summary>
        [JsonIgnore]
        public string? Overview
        {
            get => Show?.Overview;
            set
            {
                if (Show != null)
                {
                    Show.Overview = value;
                }
            }
        }

        /// <summary>The UTC datetime when the first episode of the first season was aired.</summary>
        [JsonIgnore]
        public DateTime? FirstAired
        {
            get => Show?.FirstAired;
            set
            {
                if (Show != null)
                {
                    Show.FirstAired = value;
                }
            }
        }

        /// <summary>The air time of the show. See also <seealso cref="TraktShowAirs" />.</summary>
        [JsonIgnore]
        public TraktShowAirs? Airs
        {
            get => Show?.Airs;
            set
            {
                if (Show != null)
                {
                    Show.Airs = value;
                }
            }
        }

        /// <summary>The runtime of an episode in minutes.</summary>
        [JsonIgnore]
        public uint? Runtime
        {
            get => Show?.Runtime;
            set
            {
                if (Show != null)
                {
                    Show.Runtime = value;
                }
            }
        }

        /// <summary>The content certification of the show.</summary>
        [JsonIgnore]
        public string? Certification
        {
            get => Show?.Certification;
            set
            {
                if (Show != null)
                {
                    Show.Certification = value;
                }
            }
        }

        /// <summary>The producing network name of the show.</summary>
        [JsonIgnore]
        public string? Network
        {
            get => Show?.Network;
            set
            {
                if (Show != null)
                {
                    Show.Network = value;
                }
            }
        }

        /// <summary>The country code in which the show is produced.</summary>
        [JsonIgnore]
        public string? Country
        {
            get => Show?.Country;
            set
            {
                if (Show != null)
                {
                    Show.Country = value;
                }
            }
        }

        /// <summary>The web address of a trailer for the show.</summary>
        [JsonIgnore]
        public string? Trailer
        {
            get => Show?.Trailer;
            set
            {
                if (Show != null)
                {
                    Show.Trailer = value;
                }
            }
        }

        /// <summary>The web address of the homepage of the show.</summary>
        [JsonIgnore]
        public string? Homepage
        {
            get => Show?.Homepage;
            set
            {
                if (Show != null)
                {
                    Show.Homepage = value;
                }
            }
        }

        /// <summary>The show's current status. See also <seealso cref="TraktShowStatus" />.</summary>
        [JsonIgnore]
        public TraktShowStatus? Status
        {
            get => Show?.Status;
            set
            {
                if (Show != null)
                {
                    Show.Status = value;
                }
            }
        }

        /// <summary>The average user rating of the show.</summary>
        [JsonIgnore]
        public float? Rating
        {
            get => Show?.Rating;
            set
            {
                if (Show != null)
                {
                    Show.Rating = value;
                }
            }
        }

        /// <summary>The number of votes for the show.</summary>
        [JsonIgnore]
        public uint? Votes
        {
            get => Show?.Votes;
            set
            {
                if (Show != null)
                {
                    Show.Votes = value;
                }
            }
        }

        /// <summary>The show colors. See also <seealso cref="TraktColors" />.</summary>
        [JsonIgnore]
        public TraktColors? Colors
        {
            get => Show?.Colors;
            set
            {
                if (Show != null)
                {
                    Show.Colors = value;
                }
            }
        }

        /// <summary>The comment count of the show.</summary>
        [JsonIgnore]
        public uint? CommentCount
        {
            get => Show?.CommentCount;
            set
            {
                if (Show != null)
                {
                    Show.CommentCount = value;
                }
            }
        }

        /// <summary>The UTC datetime when the show was last updated.</summary>
        [JsonIgnore]
        public DateTime? UpdatedAt
        {
            get => Show?.UpdatedAt;
            set
            {
                if (Show != null)
                {
                    Show.UpdatedAt = value;
                }
            }
        }

        /// <summary>The language code of the show.</summary>
        [JsonIgnore]
        public string? Language
        {
            get => Show?.Language;
            set
            {
                if (Show != null)
                {
                    Show.Language = value;
                }
            }
        }

        /// <summary>The list of language codes of the show.</summary>
        [JsonIgnore]
        public List<string>? Languages
        {
            get => Show?.Languages;
            set
            {
                if (Show != null)
                {
                    Show.Languages = value;
                }
            }
        }

        /// <summary>The list of translation language codes for the show.</summary>
        [JsonIgnore]
        public List<string>? AvailableTranslations
        {
            get => Show?.AvailableTranslations;
            set
            {
                if (Show != null)
                {
                    Show.AvailableTranslations = value;
                }
            }
        }

        /// <summary>The collection of Trakt genre slugs for the show.</summary>
        [JsonIgnore]
        public List<string>? Genres
        {
            get => Show?.Genres;
            set
            {
                if (Show != null)
                {
                    Show.Genres = value;
                }
            }
        }

        /// <summary>The collection of Trakt subgenre slugs for the show.</summary>
        [JsonIgnore]
        public List<string>? Subgenres
        {
            get => Show?.Subgenres;
            set
            {
                if (Show != null)
                {
                    Show.Subgenres = value;
                }
            }
        }

        /// <summary>
        /// The collection of image URLs for the show.
        /// See also <seealso cref="TraktShowImages" />.
        /// </summary>
        [JsonIgnore]
        public TraktShowImages? Images {
            get => Show?.Images;
            set
            {
                if (Show != null)
                {
                    Show.Images = value;
                }
            }
        }

        /// <summary>The absolute number of already aired episodes.</summary>
        [JsonIgnore]
        public uint? AiredEpisodes
        {
            get => Show?.AiredEpisodes;
            set
            {
                if (Show != null)
                {
                    Show.AiredEpisodes = value;
                }
            }
        }

        /// <summary>The show original title.</summary>
        [JsonIgnore]
        public string? OriginalTitle
        {
            get => Show?.OriginalTitle;
            set
            {
                if (Show != null)
                {
                    Show.OriginalTitle = value;
                }
            }
        }

        /// <summary>A collection of social IDs for various web services for the show.</summary>
        public TraktShowSocialIDs? SocialIDs
        {
            get => Show?.SocialIDs;
            set
            {
                if (Show != null)
                {
                    Show.SocialIDs = value;
                }
            }
        }

        /// <summary>Gets a string representation of the show.</summary>
        /// <returns>A string representation of the show.</returns>
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
