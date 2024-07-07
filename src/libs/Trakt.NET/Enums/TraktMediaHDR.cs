namespace TraktNET
{
    /// <summary>Determines the HDR type in a collection item's metadata.</summary>
    [TraktEnum]
    public enum TraktMediaHDR
    {
        /// <summary>An invalid HDR type.</summary>
        Unspecified,

        /// <summary>The collection item supports DolbyVision.</summary>
        DolbyVision,

        /// <summary>The collection item supports HDR10.</summary>
        [TraktEnumMember(JsonValue = "hdr10", DisplayName = "HDR10")]
        HDR10,

        /// <summary>The collection item supports HDR10 Plus.</summary>
        [TraktEnumMember(JsonValue = "hdr10_plus", DisplayName = "HDR10 Plus")]
        HDR10Plus,

        /// <summary>The collection item supports HLG.</summary>
        HLG
    }
}
