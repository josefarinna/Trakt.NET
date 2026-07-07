using System.Collections.Generic;

namespace TraktNET
{
    /// <summary>Represents user's watch now settings.</summary>
    public record class TraktUserWatchnowSettings
    {
        /// <summary>Gets or sets the user's watch now country.</summary>
        public string? Country { get; set; }

        /// <summary>Gets or sets the user's watch now favorite services.</summary>
        public IReadOnlyList<string>? Favorites { get; set; }

        /// <summary>Gets or sets whether to display only favorite services.</summary>
        public bool? OnlyFavorites { get; set; }
    }
}
