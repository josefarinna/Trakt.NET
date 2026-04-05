using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public record class TraktPersonMovieCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("costume & make-up")]
        public List<TraktPersonMovieCreditsCrewItem>? CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("visual effects")]
        public List<TraktPersonMovieCreditsCrewItem>? VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonMovieCreditsCrewItem>? Editing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the created by category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("created by")]
        public List<TraktPersonMovieCreditsCrewItem>? CreatedBy { get; set; }
    }
}
