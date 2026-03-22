using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt network.</summary>
    public record class TraktNetwork
    {
        /// <summary>Gets or sets the network name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the country code for the network.</summary>
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the network for various web services.
        /// See also <seealso cref="TraktNetworkIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktNetworkIDs? IDs { get; set; }
    }
}
