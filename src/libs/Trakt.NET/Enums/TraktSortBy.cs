namespace TraktNET
{
    /// <summary>Determines how items are ordered.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSortBy
    {
        /// <summary>An invalid sort-by type.</summary>
        Unspecified,

        /// <summary>Items are ordered by rank.</summary>
        Rank,

        /// <summary>Items are ordered by added timestamp.</summary>
        Added,

        /// <summary>Items are ordered by title.</summary>
        Title,

        /// <summary>Items are ordered by released timestamp.</summary>
        Released,

        /// <summary>Items are ordered by runtime.</summary>
        Runtime,

        /// <summary>Items are ordered by popularity.</summary>
        Popularity,

        /// <summary>Items are ordered by percentage.</summary>
        Percentage,

        /// <summary>Items are ordered by imdb rating.</summary>
        [TraktEnumMember(JsonValue = "imdb_rating", DisplayName = "IMDB Rating")]
        IMDBRating,

        /// <summary>Items are ordered by tmdb rating.</summary>
        [TraktEnumMember(JsonValue = "tmdb_rating", DisplayName = "TMDB Rating")]
        TMDBRating,

        /// <summary>Items are ordered by rt tomatometer.</summary>
        [TraktEnumMember(JsonValue = "rt_tomatometer", DisplayName = "RT TomatoMeter")]
        RTTomatoMeter,

        /// <summary>Items are ordered by rt audience.</summary>
        [TraktEnumMember(JsonValue = "rt_audience", DisplayName = "RT Audience")]
        RTAudience,

        /// <summary>Items are ordered by metascore.</summary>
        Metascore,

        /// <summary>Items are ordered by votes.</summary>
        Votes,

        /// <summary>Items are ordered by imdb votes.</summary>
        [TraktEnumMember(JsonValue = "imdb_votes", DisplayName = "IDMB Votes")]
        IMDBVotes,

        /// <summary>Items are ordered by tmdb votes.</summary>
        [TraktEnumMember(JsonValue = "tmdb_votes", DisplayName = "TMDB Votes")]
        TMDBVotes,

        /// <summary>Items are ordered by own user rating.</summary>
        MyRating,

        /// <summary>Items are ordered by random.</summary>
        Random,

        /// <summary>Items are ordered by watched timestamp.</summary>
        Watched,

        /// <summary>Items are ordered by collected timestamp.</summary>
        Collected
    }
}
