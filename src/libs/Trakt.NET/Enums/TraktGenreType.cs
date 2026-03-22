namespace TraktNET
{
    /// <summary>Determines the genre type of movie and show genres.</summary>
    [TraktEnum]
    public enum TraktGenreType
    {
        /// <summary>An invalid genre type.</summary>
        Unspecified,

        /// <summary>The genre type for movies.</summary>
        Movies,

        /// <summary>The genre type for shows.</summary>
        Shows
    }
}
