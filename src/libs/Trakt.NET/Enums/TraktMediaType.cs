namespace TraktNET
{
    /// <summary>Determines the media type in a collection item's metadata.</summary>
    [TraktEnum]
    public enum TraktMediaType
    {
        /// <summary>An invalid media type.</summary>
        Unspecified,

        /// <summary>The collection item has Digital media.</summary>
        Digital,

        /// <summary>The collection item has Bluray media.</summary>
        Bluray,

        /// <summary>The collection item has HD DVD media.</summary>
        [TraktEnumMember(JsonValue = "hddvd", DisplayName = "HD DVD")]
        HDDVD,

        /// <summary>The collection item has DVD media.</summary>
        DVD,

        /// <summary>The collection item has VCD media.</summary>
        VCD,

        /// <summary>The collection item has VHS media.</summary>
        VHS,

        /// <summary>The collection item has Betamax media.</summary>
        [TraktEnumMember(JsonValue = "betamax", DisplayName = "BetaMax")]
        BetaMax,

        /// <summary>The collection item has Laserdisc media.</summary>
        [TraktEnumMember(JsonValue = "laserdisc", DisplayName = "LaserDisc")]
        LaserDisc
    }
}
