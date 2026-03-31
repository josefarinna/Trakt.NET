namespace TraktNET
{
    /// <summary>Contains information about a watched Trakt season.</summary>
    public record class TraktWatchedShowSeason
    {
        /// <summary>Gets or sets the number of the watched season.</summary>
        public uint? Number { get; set; }

        /// <summary>Gets or sets a list of watched episodes in the watched season. See also <seealso cref="TraktWatchedShowEpisode" />.</summary>
        public List<TraktWatchedShowEpisode>? Episodes { get; set; }
    }
}
