using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt studio.</summary>
    public record class TraktStudio
    {
        /// <summary>The studio name.</summary>
        public string? Name { get; set; }

        /// <summary>The two character country code of the studio.</summary>
        public string? Country { get; set; }

        /// <summary>
        /// The collection of IDs for the studio for various web services.
        /// See also <seealso cref="TraktStudioIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktStudioIDs? IDs { get; set; }
    }
}
