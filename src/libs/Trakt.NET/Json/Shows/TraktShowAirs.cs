namespace TraktNET
{
    public record class TraktShowAirs
    {
        public TraktDayOfWeek? Day { get; set; }

#if NET6_0_OR_GREATER
        public TimeOnly? Time { get; set; }
#else
        public string? Time { get; set; }
#endif

        public string? Timezone { get; set; }
    }
}
