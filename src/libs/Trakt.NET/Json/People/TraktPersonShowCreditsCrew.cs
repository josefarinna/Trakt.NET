using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public record class TraktPersonShowCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("costume & make-up")]
        public List<TraktPersonShowCreditsCrewItem>? CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("visual effects")]
        public List<TraktPersonShowCreditsCrewItem>? VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCrewItem>? Editing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the created by category. See also <seealso cref="TraktPersonShowCreditsCrewItem" />.
        /// </summary>
        [JsonPropertyName("created by")]
        public List<TraktPersonShowCreditsCrewItem>? CreatedBy { get; set; }
    }
}
