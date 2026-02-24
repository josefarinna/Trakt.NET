namespace TraktNET
{
    /// <summary>A most watched Trakt show.</summary>
    public record class TraktMostWatchedShow : TraktMostPWCShow
    {
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
