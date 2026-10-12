namespace TraktNET
{
    /// <summary>Information about a tool that kept a list updated but stopped syncing it.</summary>
    public record class TraktListStaleOrigin
    {
        /// <summary>The name of the tool.</summary>
        public string? Name { get; set; }

        /// <summary>The URL of the tool.</summary>
        public string? Url { get; set; }
    }
}
