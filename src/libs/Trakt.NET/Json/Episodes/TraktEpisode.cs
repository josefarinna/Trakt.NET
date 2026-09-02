using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt episode of a Trakt season.</summary>
    public record class TraktEpisode : TraktEpisodeMinimal
    {
        /// <summary>The absolute episode number of all episodes in all seasons.</summary>
        [JsonPropertyName("number_abs")]
        public uint? NumberAbsolute { get; set; }

        /// <summary>The synopsis of the episode.</summary>
        public string? Overview { get; set; }

        /// <summary>The average user rating of the episode.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes for the episode.</summary>
        public uint? Votes { get; set; }

        /// <summary>The comment count of the episode.</summary>
        public uint? CommentCount { get; set; }

        /// <summary>The UTC datetime when the episode was first aired.</summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>The UTC datetime when the episode was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The list of translation language codes for the episode.</summary>
        public List<string>? AvailableTranslations { get; set; }

        /// <summary>The runtime of the episode.</summary>
        public uint? Runtime { get; set; }

        /// <summary>The episode type. See also <seealso cref="TraktEpisodeType" />.</summary>
        public TraktEpisodeType? EpisodeType { get; set; }

        /// <summary>Extra scene after the credits.</summary>
        public bool? AfterCredits { get; set; }

        /// <summary>Extra scene during the credits.</summary>
        public bool? DuringCredits { get; set; }

        /// <summary>The episode original title.</summary>
        public string? OriginalTitle { get; set; }

        /// <summary>The list of <see cref="TraktEpisodeTranslation" />s for the episode.</summary>
        /// <seealso cref="TraktSeason.Episodes" />
        /// <remarks>
        /// This property is set automatically if this episode is in a
        /// <see cref="TraktSeason.Episodes" /> collection and the episode's season
        /// is in a collection of seasons returned by
        /// <see cref="TraktSeasonsModule" />
        /// and a translation language code was specified.
        /// This property is also set automatically if this episode is in
        /// a collection returned by <see cref="TraktSeasonsModule" />
        /// and a translation language code was specified.
        /// </remarks>
        public List<TraktEpisodeTranslation>? Translations { get; set; }

        /// <summary>The collection of episodes when grouped (e.g. in calendar feeds with group=day).</summary>
        public List<TraktEpisode>? Episodes { get; set; }

        /// <summary>Gets a string representation of the episode.</summary>
        /// <returns>A string representation of the episode.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Season.HasValue && Number.HasValue)
            {
                title = $"S{Season.Value.ToInvariantCultureString("D2")}E{Number.Value.ToInvariantCultureString("D2")}: {title}";
            }

            return title;
        }
    }
}
