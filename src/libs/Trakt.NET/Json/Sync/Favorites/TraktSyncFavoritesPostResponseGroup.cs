namespace TraktNET
{
    /// <summary>A collection containing the number of movies and shows.</summary>
    public record class TraktSyncFavoritesPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public int? Shows { get; set; }
    }
}
