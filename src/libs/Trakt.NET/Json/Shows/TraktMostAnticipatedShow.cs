namespace TraktNET
{
    /// <summary>A most anticipated Trakt show.</summary>
    public record class TraktMostAnticipatedShow : TraktCollectionShow
    {
        /// <summary>The list count for the <see cref="TraktCollectionShow.Show" />.</summary>
        public uint? ListCount { get; set; }

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
