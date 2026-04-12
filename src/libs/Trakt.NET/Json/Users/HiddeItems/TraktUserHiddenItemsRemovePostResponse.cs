namespace TraktNET
{
    /// <summary>
    /// Represents the response for an user hidden items remove post. See also <see cref="TraktUserHiddenItemsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows and seasons.</para>
    /// </summary>
    public record class TraktUserHiddenItemsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows and seasons.
        /// </summary>
        public TraktUserHiddenItemsPostResponseGroup? Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows and seasons, which were not found.
        /// </summary>
        public TraktUserHiddenItemsPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
