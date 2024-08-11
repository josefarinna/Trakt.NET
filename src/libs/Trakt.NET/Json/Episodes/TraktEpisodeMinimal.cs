namespace TraktNET
{
    /// <summary>A Trakt episode.</summary>
    public record class TraktEpisodeMinimal
    {
        /// <summary>The season number in which the episode was aired.</summary>
        public uint? Season { get; set; }

        /// <summary>The episode number within the season to which it belongs.</summary>
        public uint? Number { get; set; }

        /// <summary>The episode title.</summary>
        public string? Title { get; set; }

        /// <summary>
        /// The collection of IDs for the episode for various web services.
        /// See also <seealso cref="TraktEpisodeIds" />.
        /// </summary>
        public TraktEpisodeIds? Ids { get; set; }
    }
}
