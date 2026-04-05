namespace TraktNET
{
    /// <summary>Contains all Trakt shows where a Trakt person is in the cast or crew.</summary>
    public record class TraktPersonShowCredits
    {
        /// <summary>
        /// Gets or sets a list of cast positions, in which a person is.
        /// See also <seealso cref="TraktPersonShowCreditsCastItem" />.
        /// </summary>
        public List<TraktPersonShowCreditsCastItem>? Cast { get; set; }

        /// <summary>
        /// Gets or sets a collection of crew positions, which a person has.
        /// See also <seealso cref="TraktPersonShowCreditsCrew" />.
        /// </summary>
        public TraktPersonShowCreditsCrew? Crew { get; set; }
    }
}
