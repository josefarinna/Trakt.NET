namespace TraktNET
{
    /// <summary>Determines the audio channel type in a collection item's metadata.</summary>
    [TraktEnum]
    public enum TraktMediaAudioChannel
    {
        /// <summary>An invalid audio channel type.</summary>
        Unspecified,

        /// <summary>The collection item has 1.0 audio channels.</summary>
        [TraktEnumMember("1.0", DisplayName = "Channels 1.0")]
        Channels10,

        /// <summary>The collection item has 2.0 audio channels.</summary>
        [TraktEnumMember("2.0", DisplayName = "Channels 2.0")]
        Channels20,

        /// <summary>The collection item has 2.1 audio channels.</summary>
        [TraktEnumMember("2.1", DisplayName = "Channels 2.1")]
        Channels21,

        /// <summary>The collection item has 3.0 audio channels.</summary>
        [TraktEnumMember("3.0", DisplayName = "Channels 3.0")]
        Channels30,

        /// <summary>The collection item has 3.1 audio channels.</summary>
        [TraktEnumMember("3.1", DisplayName = "Channels 3.1")]
        Channels31,

        /// <summary>The collection item has 4.0 audio channels.</summary>
        [TraktEnumMember("4.0", DisplayName = "Channels 4.0")]
        Channels40,

        /// <summary>The collection item has 4.1 audio channels.</summary>
        [TraktEnumMember("4.1", DisplayName = "Channels 4.1")]
        Channels41,

        /// <summary>The collection item has 5.0 audio channels.</summary>
        [TraktEnumMember("5.0", DisplayName = "Channels 5.0")]
        Channels50,

        /// <summary>The collection item has 5.1 audio channels.</summary>
        [TraktEnumMember("5.1", DisplayName = "Channels 5.1")]
        Channels51,

        /// <summary>The collection item has 5.1.2 audio channels.</summary>
        [TraktEnumMember("5.1.2", DisplayName = "Channels 5.1.2")]
        Channels512,

        /// <summary>The collection item has 5.1.4 audio channels.</summary>
        [TraktEnumMember("5.1.4", DisplayName = "Channels 5.1.4")]
        Channels514,

        /// <summary>The collection item has 6.1 audio channels.</summary>
        [TraktEnumMember("6.1", DisplayName = "Channels 6.1")]
        Channels61,

        /// <summary>The collection item has 7.1 audio channels.</summary>
        [TraktEnumMember("7.1", DisplayName = "Channels 7.1")]
        Channels71,

        /// <summary>The collection item has 7.1.2 audio channels.</summary>
        [TraktEnumMember("7.1.2", DisplayName = "Channels 7.1.2")]
        Channels712,

        /// <summary>The collection item has 7.1.4 audio channels.</summary>
        [TraktEnumMember("7.1.4", DisplayName = "Channels 7.1.4")]
        Channels714,

        /// <summary>The collection item has 9.1 audio channels.</summary>
        [TraktEnumMember("9.1", DisplayName = "Channels 9.1")]
        Channels91,

        /// <summary>The collection item has 10.1 audio channels.</summary>
        [TraktEnumMember("10.1", DisplayName = "Channels 10.1")]
        Channels101,
    }
}
