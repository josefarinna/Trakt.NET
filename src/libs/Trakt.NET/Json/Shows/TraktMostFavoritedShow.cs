namespace TraktNET
{
    /// <inheritdoc />
    public record class TraktMostFavoritedShow : TraktCollectionShow
    {
        /// <summary>Gets or sets the user count for the <see cref="Show" />.</summary>
        public uint? UserCount { get; set; }

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
