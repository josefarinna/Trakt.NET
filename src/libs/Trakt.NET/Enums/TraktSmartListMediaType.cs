namespace TraktNET
{
    /// <summary>Determines the media type of a smart list.</summary>
    [TraktEnum(HasPathSupport = true)]
    public enum TraktSmartListMediaType
    {
        /// <summary>An invalid media type.</summary>
        Unspecified,

        /// <summary>Movies only.</summary>
        Movies,

        /// <summary>Shows only.</summary>
        Shows,

        /// <summary>Movies and shows.</summary>
        Media
    }
}
