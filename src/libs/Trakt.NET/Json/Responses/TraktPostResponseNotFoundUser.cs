using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user, which was not found.</summary>
    public record class TraktPostResponseNotFoundUser
    {
        /// <summary>Gets or sets the ids of the not found user. See also <seealso cref="TraktUserIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktUserIDs? IDs { get; set; }
    }
}
