namespace TraktNET
{
    /// <summary>A collection containing the ids of rated movies, shows, seasons and episodes, which were not found.</summary>
    public record class TraktSyncRatingsPostResponseNotFoundGroup
    {
        /// <summary>A list of <see cref="TraktSyncRatingsPostResponseNotFoundMovie" />, containing the ids of rated movies, which were not found.</summary>
        public List<TraktSyncRatingsPostResponseNotFoundMovie>? Movies { get; set; }

        /// <summary>A list of <see cref="TraktSyncRatingsPostResponseNotFoundShow" />, containing the ids of rated shows, which were not found.</summary>
        public List<TraktSyncRatingsPostResponseNotFoundShow>? Shows { get; set; }

        /// <summary>A list of <see cref="TraktSyncRatingsPostResponseNotFoundSeason" />, containing the ids of rated seasons, which were not found.</summary>
        public List<TraktSyncRatingsPostResponseNotFoundSeason>? Seasons { get; set; }

        /// <summary>A list of <see cref="TraktSyncRatingsPostResponseNotFoundEpisode" />, containing the ids of rated episodes, which were not found.</summary>
        public List<TraktSyncRatingsPostResponseNotFoundEpisode>? Episodes { get; set; }
    }
}
