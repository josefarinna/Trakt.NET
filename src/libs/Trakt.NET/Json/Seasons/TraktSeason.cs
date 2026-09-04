namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktSeason : TraktSeasonMinimal
    {
        /// <summary>The average user rating of the season.</summary>
        public float? Rating { get; set; }

        /// <summary>The number of votes for the season.</summary>
        public uint? Votes { get; set; }

        /// <summary>The number of episodes in the season.</summary>
        public uint? EpisodeCount { get; set; }

        /// <summary>The number of aired episodes in the season.</summary>
        public uint? AiredEpisodes { get; set; }

        /// <summary>The total runtime of the season in minutes.</summary>
        public uint? TotalRuntime { get; set; }

        /// <summary>The title of the season.</summary>
        public string? Title { get; set; }

        /// <summary>The synopsis of the season.</summary>
        public string? Overview { get; set; }

        /// <summary>The UTC datetime when the season was first aired.</summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>The UTC datetime when the season was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The network on which the season airs.</summary>
        public string? Network { get; set; }

        /// <summary>The season original title.</summary>
        public string? OriginalTitle { get; set; }

        /// <summary>The collection of Trakt episodes in the season. See also <seealso cref="TraktEpisode" />.</summary>
        /// <remarks>
        /// This property is set automatically if this season is in a collection
        /// of seasons and this collection was returned by
        /// <see cref="TraktSeasonsModule" />
        /// and the optional <see cref="TraktExtendedInfo" /> has
        /// <see cref="TraktExtendedInfo.Episodes" /> set.
        /// </remarks>
        public List<TraktEpisode>? Episodes { get; set; }

        /// <summary>Gets a string representation of the season.</summary>
        /// <returns>A string representation of the season.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Number.HasValue)
            {
                title = $"S{Number.Value.ToInvariantCultureString("D2")}: {title}";
            }

            return title;
        }
    }
}
