using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents a Plex server.</summary>
    public record class TraktPlexServer
    {
        /// <summary>Gets or sets the Plex server machine identifier.</summary>
        public string? Id { get; set; }

        /// <summary>Gets or sets the Plex server name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the connection count.</summary>
        public int ConnectionCount { get; set; }

        /// <summary>Gets or sets the connection timeout in seconds.</summary>
        public int ConnectionTimeout { get; set; }

        /// <summary>Gets or sets the list of ports.</summary>
        public List<int>? Ports { get; set; }

        /// <summary>Gets or sets whether the user owns the server.</summary>
        public bool Owned { get; set; }

        /// <summary>Gets or sets the resolved remote URL, or null when the server is unreachable.</summary>
        public string? Url { get; set; }
    }

    /// <summary>Represents a response containing a list of Plex servers.</summary>
    public record class TraktPlexServersResponse
    {
        /// <summary>Gets or sets the Plex servers.</summary>
        public List<TraktPlexServer>? Servers { get; set; }
    }
}
