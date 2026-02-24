namespace TraktNET
{
    /// <summary>An updated Trakt show.</summary>
    public record class TraktUpdatedShow : TraktCollectionShow
    {
        /// <summary>The UTC datetime, when the <see cref="TraktCollectionShow.Show" /> was updated.</summary>
        public new DateTime? UpdatedAt { get; set; }

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
