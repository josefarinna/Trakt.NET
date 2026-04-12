namespace TraktNET
{
    /// <summary>A collection containing the ids of movies, shows and seasons, which were not found.</summary>
    public record class TraktUserHiddenItemsPostResponseNotFoundGroup
    {
        /// <summary>A list of <see cref="TraktPostResponseNotFoundMovie" />, containing the ids of movies, which were not found.</summary>
        public List<TraktPostResponseNotFoundMovie>? Movies { get; set; }

        /// <summary>A list of <see cref="TraktPostResponseNotFoundShow" />, containing the ids of shows, which were not found.</summary>
        public List<TraktPostResponseNotFoundShow>? Shows { get; set; }

        /// <summary>A list of <see cref="TraktPostResponseNotFoundSeason" />, containing the ids of seasons, which were not found.</summary>
        public List<TraktPostResponseNotFoundSeason>? Seasons { get; set; }

        /// <summary>A list of <see cref="TraktUser" />s, containing users, which were not found.</summary>
        public List<TraktUser>? Users { get; set; }
    }
}
