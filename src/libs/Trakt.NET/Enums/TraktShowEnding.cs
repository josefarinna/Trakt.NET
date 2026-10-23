namespace TraktNET
{
    /// <summary>Determines how the story ended for a show.</summary>
    [TraktEnum]
    public enum TraktShowEnding
    {
        /// <summary>An invalid ending.</summary>
        Unspecified,

        /// <summary>The creators finished the story on purpose.</summary>
        Concluded,

        /// <summary>The story was cut off / left open.</summary>
        Open
    }
}
