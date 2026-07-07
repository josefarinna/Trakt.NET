namespace TraktNET
{
    /// <summary>Represents webOS-specific deep link details for a watch now offer.</summary>
    public record class TraktWatchnowWebos
    {
        /// <summary>Gets or sets the webOS application ID.</summary>
        public string? Id { get; set; }

        /// <summary>Gets or sets the parameters for launching the webOS app.</summary>
        public TraktWatchnowWebosParams? Params { get; set; }
    }
}
