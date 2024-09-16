namespace TraktNET
{
    /// <summary>A most played, watched or collected Trakt movie.</summary>
    public record class TraktMostPWCMovie : TraktCollectionMovie
    {
        /// <summary>The watcher count for the <see cref="Movie" />.</summary>
        public uint? WatcherCount { get; set; }

        /// <summary>The play count for the <see cref="Movie" />.</summary>
        public uint? PlayCount { get; set; }

        /// <summary>The collected count for the <see cref="Movie" />.</summary>
        public uint? CollectedCount { get; set; }
    }
}
