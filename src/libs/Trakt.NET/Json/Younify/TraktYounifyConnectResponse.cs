namespace TraktNET
{
    /// <summary>Represents the response from creating a Younify streaming connection.</summary>
    public record class TraktYounifyConnectResponse
    {
        /// <summary>Gets or sets the signed Younify web-auth URL for the client to open.</summary>
        public string? Url { get; set; }
    }
}
