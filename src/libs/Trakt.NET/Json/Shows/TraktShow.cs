namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktShow : TraktShowMinimal
    {
        /// <summary>The show tagline.</summary>
        public string? Tagline { get; set; }

        /// <summary>The synopsis of the show.</summary>
        public string? Overview { get; set; }

        /// <summary>The UTC datetime when the first episode of the first season of the show was aired.</summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>The UTC datetime when the show was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The air time of the show. See also <seealso cref="TraktShowAirs" />.</summary>
        public TraktShowAirs? Airs { get; set; }

        /// <summary>The runtime of an show's epsiode.</summary>
        public uint? Runtime { get; set; }

        /// <summary>The content certification of the show.</summary>
        public string? Certification { get; set; }

        /// <summary>The producing network name of the show.</summary>
        public string? Network { get; set; }

        /// <summary>The country code in which the show is produced.</summary>
        public string? Country { get; set; }

        /// <summary>The web address of a trailer for the show.</summary>
        public string? Trailer { get; set; }

        /// <summary>The web address of the homepage of the show.</summary>
        public string? Homepage { get; set; }

        /// <summary>The average user rating of the show.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes for the show.</summary>
        public uint? Votes { get; set; }

        /// <summary>The comment count of the show.</summary>
        public uint? CommentCount { get; set; }

        /// <summary>The language code of the show.</summary>
        public string? Language { get; set; }

        public List<string>? Languages { get; set; }

        /// <summary>The list of translation language codes for the show.</summary>
        public List<string>? AvailableTranslations { get; set; }

        /// <summary>The collection of Trakt genre slugs for the show.</summary>
        public List<string>? Genres { get; set; }

        /// <summary>The absolute number of already aired episodes in all seasons of the show.</summary>
        public uint? AiredEpisodes { get; set; }

        /// <summary>The show's current status. See also <seealso cref="TraktShowStatus" />.</summary>
        public TraktShowStatus? Status { get; set; }

        /// <summary>Gets a string representation of the show.</summary>
        /// <returns>A string representation of the show.</returns>
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
