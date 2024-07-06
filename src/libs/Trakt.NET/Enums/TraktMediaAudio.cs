namespace TraktNET
{
    /// <summary>Determines the audio type in a collection item's metadata.</summary>
    [TraktEnum]
    public enum TraktMediaAudio
    {
        /// <summary>An invalid audio type.</summary>
        Unspecified,

        /// <summary>The collection item has LPCM audio.</summary>
        LPCM,

        /// <summary>The collection item has MP3 audio.</summary>
        [TraktEnumMember("mp3", DisplayName = "MP3")]
        MP3,

        /// <summary>The collection item has AAC audio.</summary>
        AAC,

        /// <summary>The collection item has OGG audio.</summary>
        OGG,

        /// <summary>The collection item has WMA audio.</summary>
        WMA,

        /// <summary>The collection item has DTS audio.</summary>
        DTS,

        /// <summary>The collection item has DTS Master Audio.</summary>
        [TraktEnumMember("dts_ma", DisplayName = "DTS Master Audio")]
        DTSMA,

        /// <summary>The collection item has DTS X Audio.</summary>
        [TraktEnumMember("dts_x", DisplayName = "DTS X")]
        DTSX,

        /// <summary>The collection item has Dolby Prologic audio.</summary>
        DolbyPrologic,

        /// <summary>The collection item has Dolby Digital audio.</summary>
        DolbyDigital,

        /// <summary>The collection item has Dolby Digital Plus audio.</summary>
        DolbyDigitalPlus,

        /// <summary>The collection item has Dolby True HD audio.</summary>
        [TraktEnumMember("dolby_truehd", DisplayName = "Dolby True HD")]
        DolbyTrueHD,

        /// <summary>The collection item has Dolby Atmos audio.</summary>
        DolbyAtmos,

        /// <summary>The collection item has DTS HR audio.</summary>
        [TraktEnumMember("dts_hr", DisplayName = "DTS HR")]
        DTSHR,

        /// <summary>The collection item has AURO 3D audio.</summary>
        [TraktEnumMember("auro_3d", DisplayName = "AURO 3D")]
        AURO3D
    }
}
