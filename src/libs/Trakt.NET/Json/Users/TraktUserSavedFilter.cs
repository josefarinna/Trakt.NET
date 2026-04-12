using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user saved filter.</summary>
    public record class TraktUserSavedFilter
    {
        /// <summary>Gets or sets the id of the saved filter.</summary>
        [JsonPropertyName("id")]
        public uint? ID { get; set; }

        /// <summary>Gets or sets the rank of the saved filter.</summary>
        public uint? Rank { get; set; }

        /// <summary>
        /// Gets or sets the filter section of the saved filter.
        /// See also <seealso cref="TraktFilterSection" />.
        /// </summary>
        public TraktFilterSection? Section { get; set; }

        /// <summary>Gets or sets the name of the saved filter.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the path of the saved filter.</summary>
        public string? Path { get; set; }

        /// <summary>Gets or sets the query of the saved filter.</summary>
        public string? Query { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the saved filter was updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
