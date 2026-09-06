namespace TraktNET
{
    public record class TraktSyncCollectionMovie : TraktCollectionMovie
    {
        /// <summary>The object type.</summary>
        public TraktFavoriteObjectType? Type { get; set; }

        /// <summary>The collected date for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>The collected updated at for the <see cref="TraktCollectionMovie.Movie" />.</summary>
        public new DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a list of streaming services where the collected item is available.
        /// See also <seealso cref="TraktSyncCollectionAvailableOn" />.
        /// </summary>
        public List<TraktSyncCollectionAvailableOn>? AvailableOn { get; set; }

        /// <summary>Gets a string representation of the movie.</summary>
        /// <returns>A string representation of the movie.</returns>
        public override string ToString()
        {
            if (Movie != null)
            {
                return Movie.ToString();
            }

            return string.Empty;
        }
    }
}
