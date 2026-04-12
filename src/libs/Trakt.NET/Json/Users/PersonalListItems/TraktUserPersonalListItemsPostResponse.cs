namespace TraktNET
{
    /// <summary>
    /// Represents the response for an user personal list items post. See also <see cref="TraktUserPersonalListItemsPost" />.
    /// <para>Contains the number of added, existing and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public record class TraktUserPersonalListItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons, episodes and people.
        /// </summary>
        public TraktUserPersonalListItemsPostResponseGroup? Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons, episodes and people.
        /// </summary>
        public TraktUserPersonalListItemsPostResponseGroup? Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// </summary>
        public TraktUserPersonalListItemsPostResponseNotFoundGroup? NotFound { get; set; }

        /// <summary>
        /// Information about the updated list.
        /// </summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
