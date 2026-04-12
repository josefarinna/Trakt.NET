namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics about an user's network.</summary>
    public record class TraktUserNetworkStatistics
    {
        /// <summary>Gets or sets the number of friends an user has.</summary>
        public uint? Friends { get; set; }

        /// <summary>Gets or sets the number of followers an user has.</summary>
        public uint? Followers { get; set; }

        /// <summary>Gets or sets the number of following users an user has.</summary>
        public uint? Following { get; set; }
    }
}
