namespace TraktNET
{
    public record class TraktSyncCollectionShowSeason
    {
        /// <summary>The number count for the season.</summary>
        public uint? Number { get; set; }

        /// <summary>Gets or sets a list of collected episodes in the collected season. See also <seealso cref="TraktSyncCollectionShowEpisode" />.</summary>
        public List<TraktSyncCollectionShowEpisode>? Episodes { get; set; }
    }
}
