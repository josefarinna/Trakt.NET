namespace TraktNET
{
    /// <summary>Determines the source of a smart list.</summary>
    [TraktEnum]
    public enum TraktSmartListSource
    {
        /// <summary>An invalid source.</summary>
        Unspecified,

        /// <summary>Trending items.</summary>
        Trending,

        /// <summary>Popular items.</summary>
        Popular,

        /// <summary>Anticipated items.</summary>
        Anticipated,

        /// <summary>Recommended items.</summary>
        Recommendations,

        /// <summary>Discover items.</summary>
        Discover
    }
}
