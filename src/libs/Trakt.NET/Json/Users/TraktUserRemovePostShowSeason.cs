namespace TraktNET
{
    /// <summary>A Trakt user post show season, containing the required season number and optional episodes.</summary>
    public record class TraktUserRemovePostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public uint Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserRemovePostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season ratings will be added/removed.
        /// Otherwise, only the specified episodes ratings will be added/removed.
        /// </para>
        /// </summary>
        public List<TraktUserRemovePostShowEpisode>? Episodes { get; set; }
    }
}
