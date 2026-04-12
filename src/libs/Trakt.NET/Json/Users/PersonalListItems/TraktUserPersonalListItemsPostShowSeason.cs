namespace TraktNET
{
    /// <summary>An user personal list items post season, containing the required season number and optional episodes.</summary>
    public record class TraktUserPersonalListItemsPostShowSeason : TraktUserRemovePostShowSeason
    {
        /// <summary>
        /// An optional list of <see cref="TraktUserPersonalListItemsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the personal list.
        /// Otherwise, only the specified episodes will be added to the personal list.
        /// </para>
        /// </summary>
        public new List<TraktUserPersonalListItemsPostShowEpisode>? Episodes { get; set; }
    }
}
