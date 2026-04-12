using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>An user personal list items post person, containing the required person ids.</summary>
    public record class TraktUserPersonalListItemsPostPerson
    {
        /// <summary>Gets or sets the required person ids. See also <seealso cref="TraktPersonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktPersonIDs? IDs { get; set; }

        /// <summary>Gets or sets the person notes.</summary>
        public string? Notes { get; set; }
    }
}
