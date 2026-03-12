namespace TraktNET
{
    /// <summary>Represents Trakt connection options.</summary>
    public record class TraktConnections
    {
        /// <summary>Gets or sets, whether Twitter connection is enabled.</summary>
        public bool? Twitter { get; set; }

        /// <summary>Gets or sets, whether Tumblr connection is enabled.</summary>
        public bool? Tumblr { get; set; }

        /// <summary>Gets or sets, whether Mastodon connection is enabled.</summary>
        public bool? Mastodon { get; set; }
    }
}
