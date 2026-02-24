namespace TraktNET
{
    /// <summary>Statistics about a Trakt show.</summary>
    public record class TraktShowStatistics
    {
        /// <summary>The number of watchers.</summary>
        public uint? Watchers { get; set; }

        /// <summary>The number of playes.</summary>
        public uint? Plays { get; set; }

        /// <summary>The number of collectors.</summary>
        public uint? Collectors { get; set; }

        /// <summary>The number of collected episodes.</summary>
        public uint? CollectedEpisodes { get; set; }

        /// <summary>The number of comments.</summary>
        public uint? Comments { get; set; }

        /// <summary>The number of lists.</summary>
        public uint? Lists { get; set; }

        /// <summary>The number of votes.</summary>
        public uint? Votes { get; set; }

        /// <summary>The number of favorites.</summary>
        public uint? Favorited { get; set; }

        /// <summary>The number of recommendations.</summary>
        public uint? Recommended { get; set; }
    }
}
