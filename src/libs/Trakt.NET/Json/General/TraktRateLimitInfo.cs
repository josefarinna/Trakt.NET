namespace TraktNET
{
    /// <summary>Rate limit info about an API method.</summary>
    public record class TraktRateLimitInfo
    {
        /// <summary>The name of the rate limit.</summary>
        public string? Name { get; set; }

        /// <summary>The period of the rate limit.</summary>
        public uint? Period { get; set; }

        /// <summary>The total limit of the rate limit.</summary>
        public uint? Limit { get; set; }

        /// <summary>The number of remaining calls of the rate limit.</summary>
        public uint? Remaining { get; set; }

        /// <summary>The UTC datetime until the rate limit is reset.</summary>
        public DateTime? Until { get; set; }
    }
}
