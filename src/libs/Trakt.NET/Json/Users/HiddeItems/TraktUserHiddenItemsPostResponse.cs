namespace TraktNET
{
    /// <summary>
    /// Represents the response for an user hidden items post. See also <see cref="TraktUserHiddenItemsPost" />.
    /// <para>Contains the number of added and not found movies, shows and seasons.</para>
    /// </summary>
    public record class TraktUserHiddenItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows and seasons.
        /// </summary>
        public TraktUserHiddenItemsPostResponseGroup? Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows and seasons, which were not found.
        /// </summary>
        public TraktUserHiddenItemsPostResponseNotFoundGroup? NotFound { get; set; }
    }
}
