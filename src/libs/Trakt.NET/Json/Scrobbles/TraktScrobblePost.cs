namespace TraktNET
{
    public record class TraktScrobblePost
    {
        /// <summary>Gets or sets the required progress. Should be a value between 0 and 100.</summary>
        public required float Progress { get; set; }

        /// <summary>Gets or sets the app version for the scrobble post.</summary>
        public string? AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the scrobble post.</summary>
        public string? AppDate { get; set; }

        public void Validate()
        {
            if (Progress.CompareTo(0.0f) < 0 || Progress.CompareTo(100.0f) > 0)
                throw new TraktPostValidationException(nameof(Progress), "progress value not valid - value must be between 0 and 100");
        }
    }
}
