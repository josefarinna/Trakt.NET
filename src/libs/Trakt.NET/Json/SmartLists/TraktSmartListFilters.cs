namespace TraktNET
{
    /// <summary>Filter constraints applied to the source of a smart list.</summary>
    public record class TraktSmartListFilters
    {
        /// <summary>Genre slugs.</summary>
        public string[]? Genres { get; set; }

        /// <summary>Subgenre slugs.</summary>
        public string[]? Subgenres { get; set; }

        /// <summary>Content certifications.</summary>
        public string[]? Certifications { get; set; }

        /// <summary>2-character language codes.</summary>
        public string[]? Languages { get; set; }

        /// <summary>2-character country codes.</summary>
        public string[]? Countries { get; set; }

        /// <summary>Collection of show statuses.</summary>
        public string[]? Statuses { get; set; }

        /// <summary>Collection of network names/IDs.</summary>
        public string[]? Networks { get; set; }

        /// <summary>Collection of watchnow streaming service options.</summary>
        public string[]? Watchnow { get; set; }

        /// <summary>Year range [min, max]. Max 2 items.</summary>
        public uint[]? Years { get; set; }

        /// <summary>Ratings range [min, max]. Max 2 items.</summary>
        public uint[]? Ratings { get; set; }

        /// <summary>Runtimes range in minutes [min, max]. Max 2 items.</summary>
        public uint[]? Runtimes { get; set; }

        /// <summary>IMDb ratings range [min, max]. Max 2 items.</summary>
        public float[]? ImdbRatings { get; set; }

        /// <summary>Rotten Tomatoes tomatometer range [min, max]. Max 2 items.</summary>
        public uint[]? RtMeters { get; set; }

        /// <summary>Rotten Tomatoes audience score range [min, max]. Max 2 items.</summary>
        public uint[]? RtUserMeters { get; set; }

        /// <summary>Gets or sets whether watched items should be ignored.</summary>
        public bool? IgnoreWatched { get; set; }

        /// <summary>Gets or sets whether watchlisted items should be ignored.</summary>
        public bool? IgnoreWatchlisted { get; set; }
    }
}
