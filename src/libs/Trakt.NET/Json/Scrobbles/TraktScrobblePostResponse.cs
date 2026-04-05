using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktScrobblePostResponse
    {
        /// <summary>Gets or sets the history id for the scrobble response.</summary>
        [JsonPropertyName("id")]
        public ulong ID { get; set; }

        /// <summary>
        /// Gets or sets the action type for the scrobble response.
        /// See also <seealso cref="TraktScrobbleActionType" />.
        /// </summary>
        public TraktScrobbleActionType? Action { get; set; }

        /// <summary>Gets or sets the progress for the scrobble response.</summary>
        public float? Progress { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the scrobble response.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Sharing { get; set; }
    }
}
