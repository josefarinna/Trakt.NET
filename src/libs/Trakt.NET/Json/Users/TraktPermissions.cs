namespace TraktNET
{
    /// <summary>Represents Trakt user permissions.</summary>
    public record class TraktPermissions
    {
        /// <summary>Gets or sets the user's permission for commenting on an item.</summary>
        public bool? Commenting { get; set; }

        /// <summary>Gets or sets the user's permission for liking items.</summary>
        public bool? Liking { get; set; }

        /// <summary>Gets or sets the user's permission for following items.</summary>
        public bool? Following { get; set; }
    }
}
