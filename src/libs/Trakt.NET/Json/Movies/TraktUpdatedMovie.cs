namespace TraktNET
{
    /// <summary>An updated Trakt movie.</summary>
    public record class TraktUpdatedMovie : TraktCollectionMovie
    {
        /// <summary>The UTC datetime, when the <see cref="TraktCollectionMovie.Movie" /> was updated.</summary>
        public new DateTime? UpdatedAt { get; set; }
    }
}
