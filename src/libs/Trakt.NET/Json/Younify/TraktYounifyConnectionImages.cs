namespace TraktNET
{
    /// <summary>Represents the images for a Younify streaming service connection.</summary>
    public record class TraktYounifyConnectionImages
    {
        /// <summary>Gets or sets the logo URL of the streaming service, or <c>null</c> if unavailable.</summary>
        public string? Logo { get; set; }
    }
}
