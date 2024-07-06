namespace TraktNET
{
    /// <summary>Determines the video resolution type in a collection item's metadata.</summary>
    [TraktEnum]
    public enum TraktMediaResolution
    {
        /// <summary>An invalid video resolution type.</summary>
        Unspecified,

        /// <summary>The collection item has UHD 4k video resolution.</summary>
        [TraktEnumMember("uhd_4k", DisplayName = "Ultra HD 4k")]
        UHD4k,

        /// <summary>The collection item has HD 1080p video resolution.</summary>
        [TraktEnumMember("hd_1080p", DisplayName = "Full HD 1080p")]
        HD1080p,

        /// <summary>The collection item has HD 1080i video resolution.</summary>
        [TraktEnumMember("hd_1080i", DisplayName = "Full HD 1080i")]
        HD1080i,

        /// <summary>The collection item has HD 720p video resolution.</summary>
        [TraktEnumMember("hd_720p", DisplayName = "HD 720p")]
        HD720p,

        /// <summary>The collection item has SD 576p video resolution.</summary>
        [TraktEnumMember("sd_576p", DisplayName = "SD 576p")]
        SD576p,

        /// <summary>The collection item has SD 576i video resolution.</summary>
        [TraktEnumMember("sd_576i", DisplayName = "SD 576i")]
        SD576i,

        /// <summary>The collection item has SD 480p video resolution.</summary>
        [TraktEnumMember("sd_480p", DisplayName = "SD 480p")]
        SD480p,

        /// <summary>The collection item has SD 480i video resolution.</summary>
        [TraktEnumMember("sd_480i", DisplayName = "SD 480i")]
        SD480i
    }
}
