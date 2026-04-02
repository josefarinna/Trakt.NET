namespace TraktNET
{
    public record class TraktSyncCollectionShow : TraktCollectionShow
    {
        /// <summary>The watcher count for the <see cref="TraktCollectionShow.Show" />.</summary>
        public TraktFavoriteObjectType? Type { get; set; }

        /// <summary>The collected date for the <see cref="TraktCollectionShow.Show" />.</summary>
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>The collected updated at for the <see cref="TraktCollectionShow.Show" />.</summary>
        public DateTime? LastUpdatedAt { get; set; }

        /// <summary>Gets or sets a list of collected seasons in the collected show. See also <seealso cref="TraktSyncCollectionShowSeason" />.</summary>
        public List<TraktSyncCollectionShowSeason>? Seasons { get; set; }

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
