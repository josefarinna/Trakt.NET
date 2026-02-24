namespace TraktNET
{
    /// <summary>A most played, watched or collected Trakt show.</summary>
    public record class TraktMostPWCShow : TraktCollectionShow
    {
        /// <summary>The watcher count for the <see cref="TraktCollectionShow.Show" />.</summary>
        public uint? WatcherCount { get; set; }

        /// <summary>The play count for the <see cref="TraktCollectionShow.Show" />.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>The collected count for the <see cref="TraktCollectionShow.Show" />.</summary>
        public uint? CollectedCount { get; set; }

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
