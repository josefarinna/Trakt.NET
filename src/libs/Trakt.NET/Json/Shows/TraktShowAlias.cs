namespace TraktNET
{
    /// <summary>An alias for a Trakt show.</summary>
    public record class TraktShowAlias
    {
        /// <summary>The title of the show alias.</summary>
        public string? Title { get; set; }

        /// <summary>The two letter country code for the show alias.</summary>
        public string? Country { get; set; }
    }
}
