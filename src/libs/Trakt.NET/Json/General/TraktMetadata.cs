using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Contains metadata information for collection items.</summary>
    public record class TraktMetadata
    {
        /// <summary>Gets or sets the media type. See also <seealso cref="TraktMediaType" />.</summary>
        public TraktMediaType? MediaType { get; set; }

        /// <summary>Gets or sets the media resolution. See also <seealso cref="TraktMediaResolution" />.</summary>
        public TraktMediaResolution? Resolution { get; set; }

        /// <summary>Gets or sets the media audio type. See also <seealso cref="TraktMediaAudio" />.</summary>
        public TraktMediaAudio? Audio { get; set; }

        /// <summary>Gets or sets the media audio channels. See also <seealso cref="TraktMediaAudioChannel" />.</summary>
        public TraktMediaAudioChannel? AudioChannels { get; set; }

        /// <summary>Gets or sets the media HDR support. See also <seealso cref="TraktMediaHDR" />.</summary>
        public TraktMediaHDR? HDR { get; set; }

        /// <summary>Gets or sets, whether the media is in 3D.</summary>
        [JsonPropertyName("3d")]
        public bool? ThreeDimensional { get; set; }
    }
}
