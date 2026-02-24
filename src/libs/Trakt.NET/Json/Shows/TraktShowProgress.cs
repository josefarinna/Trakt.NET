namespace TraktNET
{
    /// <summary>Represents the progress of a Trakt show.</summary>
    public record class TraktShowProgress
    {
        /// <summary>Gets or sets the number of episodes, which already aired.</summary>
        public uint? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes already collected or watched.</summary>
        public uint? Completed { get; set; }

        /// <summary>
        /// Gets or sets the hidden seasons. See also <seealso cref="TraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public List<TraktSeason>? HiddenSeasons { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user should collect or watch.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktEpisode? NextEpisode { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user collected or watched last.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktEpisode? LastEpisode { get; set; }
    }
}
