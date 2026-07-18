using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents accounts and libraries on a Plex server.</summary>
    public record class TraktPlexServerAccountsAndLibraries
    {
        /// <summary>Gets or sets the home accounts on the server.</summary>
        public List<TraktPlexAccount>? Accounts { get; set; }

        /// <summary>Gets or sets the syncable libraries on the server.</summary>
        public List<TraktPlexLibraryInfo>? Libraries { get; set; }
    }

    /// <summary>Represents a Plex account.</summary>
    public record class TraktPlexAccount
    {
        /// <summary>Gets or sets the account ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the account name.</summary>
        public string? Name { get; set; }
    }

    /// <summary>Represents info for a Plex library.</summary>
    public record class TraktPlexLibraryInfo
    {
        /// <summary>Gets or sets the library ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the library UUID.</summary>
        public string? Uuid { get; set; }

        /// <summary>Gets or sets the library type (e.g. movie, show).</summary>
        public string? Type { get; set; }

        /// <summary>Gets or sets the library title.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the library agent.</summary>
        public string? Agent { get; set; }

        /// <summary>Gets or sets the library scanner.</summary>
        public string? Scanner { get; set; }

        /// <summary>Gets or sets whether this library is in the user's current sync selection.</summary>
        public bool Selected { get; set; }

        /// <summary>Gets or sets the library URL.</summary>
        public string? Url { get; set; }
    }
}
