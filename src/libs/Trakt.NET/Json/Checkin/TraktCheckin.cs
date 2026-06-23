namespace TraktNET
{
    public abstract record class TraktCheckin
    {
        /// <summary>
        /// Gets or sets the sharing options for the checkin post.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Sharing { get; set; }

        /// <summary>Gets or sets the message for the checkin post.</summary>
        public string? Message { get; set; }

        public abstract void Validate();
    }
}
