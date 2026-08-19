namespace TraktNET
{
    /// <summary>A streaming Trakt show.</summary>
    public record class TraktStreamingShow : TraktCollectionShow
    {
        /// <summary>The rank for the <see cref="TraktCollectionShow.Show" />.</summary>
        public int? Rank { get; set; }

        /// <summary>The delta / change in ranking for the <see cref="TraktCollectionShow.Show" />.</summary>
        public int? Delta { get; set; }

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
