namespace TraktNET
{
    /// <summary>A most played Trakt show.</summary>
    public record class TraktMostPlayedShow : TraktMostPWCShow
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
