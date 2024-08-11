namespace TraktNET
{
    /// <summary>A Trakt person.</summary>
    public record class TraktPersonMinimal
    {
        /// <summary>The person name.</summary>
        public string? Name { get; set; }

        /// <summary>
        /// The collection of IDs for the person for various web services.
        /// See also <seealso cref="TraktPersonIds" />.
        /// </summary>
        public TraktPersonIds? Ids { get; set; }
    }
}
