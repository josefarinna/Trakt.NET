namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktPerson : TraktPersonMinimal
    {
        /// <summary>
        /// The collection of social IDs for the person for various web services.
        /// See also <seealso cref="TraktPersonSocialIds" />.
        /// </summary>
        public TraktPersonSocialIds? SocialIds { get; set; }

        /// <summary>The biography of the person.</summary>
        public string? Biography { get; set; }

#if NET6_0_OR_GREATER
        /// <summary>The date when the person was born.</summary>
        public DateOnly? Birthday { get; set; }
#else
        /// <summary>The UTC datetime when the person was born.</summary>
        public DateTime? Birthday { get; set; }
#endif

#if NET6_0_OR_GREATER
        /// <summary>The date when the person died.</summary>
        public DateOnly? Death { get; set; }
#else
        /// <summary>The UTC datetime when the person died.</summary>
        public DateTime? Death { get; set; }
#endif

        /// <summary>The birthplace of the person.</summary>
        public string? Birthplace { get; set; }

        /// <summary>The web address of the homepage of the person.</summary>
        public string? Homepage { get; set; }

        /// <summary>The known department of the person. See also <seealso cref="TraktKnownForDepartment" />.</summary>
        public TraktKnownForDepartment? KnownForDepartment { get; set; }

        /// <summary>The gender of the person. See also <seealso cref="TraktGender" />.</summary>
        public TraktGender? Gender { get; set; }

        /// <summary>Gets or sets when the person was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
