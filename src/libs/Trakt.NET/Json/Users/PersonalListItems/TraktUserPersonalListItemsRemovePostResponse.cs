namespace TraktNET
{
    /// <summary>
    /// Represents the response for an user personal list items remove post. See also <see cref="TraktUserPersonalListItemsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public record class TraktUserPersonalListItemsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons, episodes and people.
        /// </summary>
        public TraktUserPersonalListItemsPostResponseGroup? Deleted { get; set; }

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
