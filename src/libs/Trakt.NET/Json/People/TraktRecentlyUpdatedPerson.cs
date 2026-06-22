using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>An updated Trakt person.</summary>
    public record class TraktRecentlyUpdatedPerson
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Person" /> was updated.</summary>
        [JsonPropertyName("updated_at")]
        public DateTime? RecentlyUpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt person. See also <seealso cref="TraktPerson" />.<para>Nullable</para></summary>
        public TraktPerson? Person { get; set; }

        [JsonIgnore]
        public string? Name
        {
            get => Person?.Name;

            set
            {
                if (Person != null)
                    Person.Name = value;
            }
        }

        [JsonIgnore]
        public TraktPersonIDs? IDs
        {
            get => Person?.IDs;

            set
            {
                if (Person != null)
                    Person.IDs = value;
            }
        }

        [JsonIgnore]
        public string? Biography
        {
            get => Person?.Biography;

            set
            {
                if (Person != null)
                    Person.Biography = value;
            }
        }

#if NET7_0_OR_GREATER
        [JsonIgnore]
        public DateOnly? Birthday
        {
            get => Person?.Birthday;

            set
            {
                if (Person != null)
                    Person.Birthday = value;
            }
        }
#else
        [JsonIgnore]
        public DateTime? Birthday
        {
            get => Person?.Birthday;

            set
            {
                if (Person != null)
                    Person.Birthday = value;
            }
        }
#endif

#if NET7_0_OR_GREATER
        [JsonIgnore]
        public DateOnly? Death
        {
            get => Person?.Death;

            set
            {
                if (Person != null)
                    Person.Death = value;
            }
        }
#else
        [JsonIgnore]
        public DateTime? Death
        {
            get => Person?.Death;

            set
            {
                if (Person != null)
                    Person.Death = value;
            }
        }
#endif

        [JsonIgnore]
        public int Age => Person != null ? Person.Age : 0;

        [JsonIgnore]
        public string? Birthplace
        {
            get => Person?.Birthplace;

            set
            {
                if (Person != null)
                    Person.Birthplace = value;
            }
        }

        [JsonIgnore]
        public string? Homepage
        {
            get => Person?.Homepage;

            set
            {
                if (Person != null)
                    Person.Homepage = value;
            }
        }

        [JsonIgnore]
        public TraktGender? Gender
        {
            get => Person?.Gender;

            set
            {
                if (Person != null)
                    Person.Gender = value;
            }
        }

        [JsonIgnore]
        public TraktKnownForDepartment? KnownForDepartment
        {
            get => Person?.KnownForDepartment;

            set
            {
                if (Person != null)
                    Person.KnownForDepartment = value;
            }
        }

        [JsonIgnore]
        public TraktPersonSocialIDs? SocialIds
        {
            get => Person?.SocialIDs;

            set
            {
                if (Person != null)
                    Person.SocialIDs = value;
            }
        }

        [JsonIgnore]
        public DateTime? UpdatedAt
        {
            get => Person?.UpdatedAt;

            set
            {
                if (Person != null)
                    Person.UpdatedAt = value;
            }
        }

        [JsonIgnore]
        public TraktPersonImages? Images
        {
            get => Person?.Images;

            set
            {
                if (Person != null)
                    Person.Images = value;
            }
        }
    }
}
