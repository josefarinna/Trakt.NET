namespace TraktNET
{
    /// <summary>Determines the media type for an award ceremony in the award catalog.</summary>
    [TraktEnum]
    public enum TraktAwardMediaType
    {
        /// <summary>An invalid media type.</summary>
        Unspecified,

        /// <summary>The ceremony applies to movies.</summary>
        Movie,

        /// <summary>The ceremony applies to shows.</summary>
        Show
    }
}
