namespace TraktNET
{
    public record class TraktRateLimitInfo
    {
        public string? Name { get; set; }

        public uint? Period { get; set; }

        public uint? Limit { get; set; }

        public uint? Remaining { get; set; }

        public DateTime? Until { get; set; }
    }
}
