namespace TraktNET
{
    /// <summary>An award ceremony.</summary>
    public record class TraktAwardCeremony : TraktAward
    {
        /// <summary>Gets or sets the ceremony edition.</summary>
        public uint? Edition { get; set; }

#if NET7_0_OR_GREATER
        /// <summary>Gets or sets the date when nominations are announced.</summary>
        public DateOnly? NominationsAt { get; set; }

        /// <summary>Gets or sets the date when the ceremony is held.</summary>
        public DateOnly? HeldAt { get; set; }
#else
        /// <summary>Gets or sets the UTC datetime when nominations are announced.</summary>
        public DateTime? NominationsAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the ceremony is held.</summary>
        public DateTime? HeldAt { get; set; }
#endif
    }
}
