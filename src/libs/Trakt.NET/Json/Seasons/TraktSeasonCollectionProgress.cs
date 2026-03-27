namespace TraktNET
{
    /// <summary>Represents the collection progress of a Trakt season.</summary>
    public record class TraktSeasonCollectionProgress : TraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the collected episodes. See also <seealso cref="TraktEpisodeCollectionProgress" />.
        /// </summary>
        public List<TraktEpisodeCollectionProgress>? Episodes { get; set; }
    }
}
