namespace TraktNET
{
    /// <summary>A most collected Trakt show.</summary>
    public record class TraktMostCollectedShow : TraktMostPWCShow
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
