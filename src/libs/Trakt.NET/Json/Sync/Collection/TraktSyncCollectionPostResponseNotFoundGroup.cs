namespace TraktNET
{
    /// <summary>A collection containing the movies, shows, seasons and episodes, which were not found.</summary>
    public record class TraktSyncCollectionPostResponseNotFoundGroup
    {
        /// <summary>A list of <see cref="TraktSyncCollectionPostMovie" />, containing the movies, which were not found.</summary>
        public List<TraktSyncCollectionPostMovie>? Movies { get; set; }

        /// <summary>A list of <see cref="TraktSyncCollectionPostShow" />, containing the shows, which were not found.</summary>
        public List<TraktSyncCollectionPostShow>? Shows { get; set; }

        /// <summary>A list of <see cref="TraktSyncCollectionPostSeason" />, containing the seasons, which were not found.</summary>
        public List<TraktSyncCollectionPostSeason>? Seasons { get; set; }

        /// <summary>A list of <see cref="TraktSyncCollectionPostEpisode" />, containing the episodes, which were not found.</summary>
        public List<TraktSyncCollectionPostEpisode>? Episodes { get; set; }
    }
}

