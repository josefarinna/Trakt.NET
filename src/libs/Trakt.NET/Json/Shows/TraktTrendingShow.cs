namespace TraktNET
{
    /// <summary>A trending Trakt show.</summary>
    public record class TraktTrendingShow : TraktCollectionShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets a string representation of the show.</summary>
        /// <returns>A string representation of the show.</returns>
        public override string ToString()
        {
            if (Show != null)
            {
                return Show.ToString();
            }

            return string.Empty;
        }
    }
}
