namespace TraktNET
{
    /// <summary>A collection containing the movies, shows, seasons and episodes, which were not found.</summary>
    public record class TraktSyncCollectionRemovePostResponseNotFoundGroup
    {
        /// <summary>A list of <see cref="TraktSyncRemovePostMovie" />, containing the movies, which were not found.</summary>
        public List<TraktSyncRemovePostMovie>? Movies { get; set; }

        /// <summary>A list of <see cref="TraktSyncRemovePostShow" />, containing the shows, which were not found.</summary>
        public List<TraktSyncRemovePostShow>? Shows { get; set; }

        /// <summary>A list of <see cref="TraktSyncRemovePostSeason" />, containing the seasons, which were not found.</summary>
        public List<TraktSyncRemovePostSeason>? Seasons { get; set; }

        /// <summary>A list of <see cref="TraktSyncRemovePostEpisode" />, containing the episodes, which were not found.</summary>
        public List<TraktSyncRemovePostEpisode>? Episodes { get; set; }
    }
}

